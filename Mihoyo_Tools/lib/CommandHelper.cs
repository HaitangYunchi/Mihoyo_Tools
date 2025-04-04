#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools
 * 唯一标识：2d6c0f9c-05c8-456b-81fd-87582c2d4059
 * 文件名：CmdHelper
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/3/31 16:56:00
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
#endregion << 版 本 注 释 >>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools.lib
{
    //lib.VarHelper.Var.GICutscents_path
    class CommandHelper
    {
        /// <summary>
        /// Gutscenes程序命令
        /// </summary>
        /// <param name="command">要执行的命令</param>
        /// <param name="outputHandler">实时输出处理委托</param>
        /// <param name="errorHandler">错误输出处理委托</param>
        /// <param name="workingDirectory">工作目录（可选）</param>
        /// <returns>表示异步操作的任务</returns>
        public static async Task ExecuteGutscenesAsync(
            string command,
            Action<string> outputHandler,
            Action<string> errorHandler = null,
            string workingDirectory = null)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException("命令不能为空", nameof(command));
            }

            var processStartInfo = new ProcessStartInfo
            {
                FileName = lib.VarHelper.Var.GICutscents_path,
                Arguments = $"{command}",  // /C 表示执行后关闭
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            if (!string.IsNullOrEmpty(workingDirectory))
            {
                processStartInfo.WorkingDirectory = workingDirectory;
            }

            using (var process = new Process { StartInfo = processStartInfo })
            {
                // 使用TaskCompletionSource来等待进程退出
                var tcs = new TaskCompletionSource<bool>();

                // 进程退出事件处理
                process.EnableRaisingEvents = true;
                process.Exited += (sender, args) =>
                {
                    tcs.TrySetResult(true);
                    process.Dispose();
                };

                // 输出数据处理
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        outputHandler?.Invoke(e.Data);
                    }
                };

                // 错误数据处理
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        if (errorHandler != null)
                        {
                            errorHandler(e.Data);
                        }
                        else
                        {
                            outputHandler?.Invoke($"[ERROR] {e.Data}");
                        }
                    }
                };

                // 启动进程
                if (!process.Start())
                {
                    throw new InvalidOperationException("无法启动进程");
                }

                // 开始异步读取输出
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // 异步等待进程退出
                await tcs.Task;

                // 确保进程已完全退出
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
        }
        /// <summary>
        /// Gutscenes程序命令
        /// </summary>
        /// <param name="command">要执行的命令</param>
        /// <param name="outputHandler">实时输出处理委托</param>
        /// <param name="errorHandler">错误输出处理委托</param>
        /// <param name="workingDirectory">工作目录（可选）</param>
        /// <returns>表示异步操作的任务</returns>
        public static async Task ExecuteFFmpegAsync(
            string command,
            Action<string> outputHandler,
            Action<string> errorHandler = null,
            string workingDirectory = null)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException("命令不能为空", nameof(command));
            }

            var processStartInfo = new ProcessStartInfo
            {
                FileName = lib.VarHelper.Var.Ffmpeg_path,
                Arguments = $"{command}",  // /C 表示执行后关闭
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            if (!string.IsNullOrEmpty(workingDirectory))
            {
                processStartInfo.WorkingDirectory = workingDirectory;
            }

            using (var process = new Process { StartInfo = processStartInfo })
            {
                // 使用TaskCompletionSource来等待进程退出
                var tcs = new TaskCompletionSource<bool>();

                // 进程退出事件处理
                process.EnableRaisingEvents = true;
                process.Exited += (sender, args) =>
                {
                    tcs.TrySetResult(true);
                    process.Dispose();
                };

                // 输出数据处理
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        outputHandler?.Invoke(e.Data);
                    }
                };

                // 错误数据处理
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        if (errorHandler != null)
                        {
                            errorHandler(e.Data);
                        }
                        else
                        {
                            outputHandler?.Invoke($"[ERROR] {e.Data}");
                        }
                    }
                };

                // 启动进程
                if (!process.Start())
                {
                    throw new InvalidOperationException("无法启动进程");
                }

                // 开始异步读取输出
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // 异步等待进程退出
                await tcs.Task;

                // 确保进程已完全退出
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
        }
    }
}
