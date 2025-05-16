/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools.Services
 * 唯一标识：61056a0a-892b-45c7-bd3e-21d4cd7d42b7
 * 文件名：FFmpegService
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/5/15 17:35:56
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/

// Services/FFmpegService.cs
using Mihoyo_Tools.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mihoyo_Tools.Services
{
    public class FFmpegService
    {
        private string _ffmpegPath;
        private string _ffprobePath;

        public string FFmpegPath { get; internal set; }

        public FFmpegService(string ffmpegPath)
        {
            _ffmpegPath = ffmpegPath;
            _ffprobePath = Path.Combine(Path.GetDirectoryName(ffmpegPath), "ffprobe.exe");
        }

        /// <summary>
        /// 获取视频信息
        /// </summary>
        public VideoInfo GetVideoInfo(string filePath)
        {
            if (!File.Exists(_ffprobePath))
                throw new FileNotFoundException("没找到 FFprobe.exe 程序");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = _ffprobePath,
                    Arguments = $"-v error -select_streams v:0 -show_entries stream=codec_name,width,height,r_frame_rate,bit_rate -show_entries format=duration -of default=noprint_wrappers=1 \"{filePath}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var info = new VideoInfo { FilePath = filePath };

            // 解析输出
            var durationMatch = Regex.Match(output, @"duration=([\d.]+)");
            if (durationMatch.Success)
                info.Duration = TimeSpan.FromSeconds(double.Parse(durationMatch.Groups[1].Value));

            var resolutionMatch = Regex.Match(output, @"width=(\d+)\s+height=(\d+)");
            if (resolutionMatch.Success)
                info.Resolution = $"{resolutionMatch.Groups[1].Value}x{resolutionMatch.Groups[2].Value}";

            var codecMatch = Regex.Match(output, @"codec_name=(\w+)");
            if (codecMatch.Success)
                info.VideoCodec = codecMatch.Groups[1].Value;

            var frameRateMatch = Regex.Match(output, @"r_frame_rate=(\d+)/(\d+)");
            if (frameRateMatch.Success)
            {
                double num = double.Parse(frameRateMatch.Groups[1].Value);
                double den = double.Parse(frameRateMatch.Groups[2].Value);
                info.FrameRate = num / den;
            }

            var bitrateMatch = Regex.Match(output, @"bit_rate=(\d+)");
            if (bitrateMatch.Success)
                info.Bitrate = $"{int.Parse(bitrateMatch.Groups[1].Value) / 1000}k";

            return info;
        }

        /// <summary>
        /// 转换视频文件
        /// </summary>
        public async Task<FFmpegProcessResult> ConvertVideoAsync(
            string inputFile,
            string outputFile,
            string videoCodec,
            string resolution,
            string bitrate,
            string fps,
            IProgress<(int progress, string output)> progress = null)
        {
            if (!File.Exists(_ffmpegPath))
                throw new FileNotFoundException("FFmpeg not found");
            //{resolution}
            var result = new FFmpegProcessResult();
            var startInfo = new ProcessStartInfo
            {
                //Arguments = $" -i \"{inputFile}\" -c:v {videoCodec} -preset slow -crf 18 -s {resolution} -vf \"scale={resolution}:flags=lanczos:minterpolate=fps={additionalArgs}:mi_mode=mci:mc_mode=aobmc:me_mode=bidir:vsbmc=1\" -b:v {bitrate} -c:a aac -b:a 256k -bufsize 30000k -movflags +faststart \"{outputFile}\"",
                FileName = _ffmpegPath,
                Arguments = $"-y -i {inputFile} -vf \"scale={resolution}:flags=lanczos,minterpolate='fps={fps}:mi_mode=mci:mc_mode=aobmc:vsbmc=1'\" -c:v {videoCodec} -preset medium -crf {bitrate} -c:a copy {outputFile}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();

                // 读取输出和错误流
                var outputReader = Task.Run(() => process.StandardOutput.ReadToEnd());
                var errorReader = Task.Run(() => process.StandardError.ReadToEnd());

                // 处理进度报告
                if (progress != null)
                {
                    while (!process.HasExited)
                    {
                        string line = await process.StandardError.ReadLineAsync();
                        if (line != null)
                        {
                            var timeMatch = Regex.Match(line, @"time=(\d+):(\d+):(\d+).(\d+)");
                            if (timeMatch.Success)
                            {
                                var hours = int.Parse(timeMatch.Groups[1].Value);
                                var minutes = int.Parse(timeMatch.Groups[2].Value);
                                var seconds = int.Parse(timeMatch.Groups[3].Value);
                                var ms = int.Parse(timeMatch.Groups[4].Value);
                                var currentTime = new TimeSpan(0, hours, minutes, seconds, ms);

                                var inputInfo = GetVideoInfo(inputFile);
                                if (inputInfo.Duration.TotalSeconds > 0)
                                {
                                    int currentProgress = (int)((currentTime.TotalSeconds / inputInfo.Duration.TotalSeconds) * 100);
                                    progress.Report((currentProgress, line));
                                }
                            }
                        }
                    }
                }

                await Task.WhenAll(outputReader, errorReader);
                process.WaitForExit();

                result.Success = process.ExitCode == 0;
                result.Output = outputReader.Result;
                result.Error = errorReader.Result;
            }

            return result;
        }

        /// <summary>
        /// 批量转换视频
        /// </summary>
        public async Task BatchConvertAsync(
            string[] inputFiles,
            string outputFolder,
            string videoCodec,
            string resolution,
            string bitrate,
            string fps,
            IProgress<(int fileIndex, int progress, string output)> progress = null)
        {
            char oldChar = ':';
            char newChar = 'x';
            string vedioname = new string(resolution.Select(c => c == oldChar ? newChar : c).ToArray());
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputFile = inputFiles[i];
                string outputFile = Path.Combine(outputFolder,
                    $"{Path.GetFileNameWithoutExtension(inputFile)}_{vedioname}_{fps}fps{Path.GetExtension(inputFile)}");

                var fileProgress = new Progress<(int progress, string output)>(p =>
                {
                    progress?.Report((i, p.progress, p.output));
                });

                await ConvertVideoAsync(inputFile, outputFile, videoCodec, resolution, bitrate, fps, fileProgress);
            }
        }
    }
}

