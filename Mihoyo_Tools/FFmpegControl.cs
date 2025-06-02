using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Mihoyo_Tools.lib;
using Mihoyo_Tools.Models;
using Mihoyo_Tools.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Mihoyo_Tools
{
    public partial class FFmpegControl : XtraUserControl
    {
        private FFmpegService _ffmpegService;
        private PresetService _presetService;
        private List<Preset> _presets;
        private BindingList<string> _fileList = new BindingList<string>();

        public FFmpegControl(string ffmpegPath)
        {
            InitializeComponent();
            _ffmpegService = new FFmpegService(ffmpegPath);
            _presetService = new PresetService();
            SetupControls();
            LoadPresets();
        }

        private void SetupControls()
        {
            // 初始化UI控件
            _ffmpegService = new FFmpegService(VarHelper.Var.Ffmpeg_path);
            txtFFmpegPath.Text = VarHelper.Var.Ffmpeg_path;
            btnAddFiles.Click += BtnAddFiles_Click;
            btnRemoveFile.Click += BtnRemoveFile_Click;
            btnClearFiles.Click += BtnClearFiles_Click;
            btnAnalyze.Click += BtnAnalyze_Click;
            btnConvert.Click += BtnConvert_Click;
            btnPresetSave.Click += BtnPresetSave_Click;
            btnPresetManage.Click += BtnPresetManage_Click;

            // 设置文件列表
            lstFiles.DataSource = _fileList;
            //lstFiles.DisplayMember = "FileName";
            // 初始化编码器下拉框
            cboVideoCodec.Properties.Items.AddRange(new[] { "libx264", "libx265", "h264_nvenc", "mpeg4", "vp9" });
            cboVideoCodec.SelectedIndex = 0;
            // 初始化分辨率下拉框
            cboResolution.Properties.Items.AddRange(new[] { "1920:1080", "2560:1440", "3840:2160", "5120:2880" });
            cboResolution.SelectedIndex = 1;
            // 初始化比特率下拉框
            cboBitrate.Properties.Items.AddRange(new[] { "18", "20" });
            cboBitrate.SelectedIndex = 0;
            // 初始化帧率下拉框
            fps.Properties.Items.AddRange(new[] { "30", "60" });
            fps.SelectedIndex = 1;
        }

        private void LoadPresets()
        {
            _presets = _presetService.LoadPresets();
            cboPreset.Properties.Items.Clear();
            foreach (var preset in _presets)
            {
                cboPreset.Properties.Items.Add(preset.Name);
            }
            if (cboPreset.Properties.Items.Count > 0)
                cboPreset.SelectedIndex = 0;
        }

        private void ApplyPreset(Preset preset)
        {
            if (preset == null) return;

            cboVideoCodec.Text = preset.VideoCodec;
            cboResolution.Text = preset.Resolution;
            cboBitrate.Text = preset.Bitrate;
            fps.Text = preset.fps;
        }

        #region 事件处理

        private void BtnAddFiles_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.mov;*.flv|All Files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in dialog.FileNames)
                    {
                        if (!_fileList.Contains(file))
                            _fileList.Add(file);
                    }
                }
            }
        }

        private void BtnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null)
            {
                _fileList.Remove(lstFiles.SelectedItem.ToString());
            }
        }

        private void BtnClearFiles_Click(object sender, EventArgs e)
        {
            _fileList.Clear();
        }

        private async void BtnAnalyze_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null)
            {
                XtraMessageBox.Show("请先选择一个文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filePath = lstFiles.SelectedItem.ToString();
            try
            {
                var info = _ffmpegService.GetVideoInfo(filePath);
                txtVideoInfo.Text = $"文件: {info.FilePath}\r\n" +
                                   $"格式: {info.Format}\r\n" +
                                   $"时长: {info.Duration}\r\n" +
                                   $"分辨率: {info.Resolution}\r\n" +
                                   $"视频编码: {info.VideoCodec}\r\n" +
                                   $"音频编码: {info.AudioCodec}\r\n" +
                                   $"帧率: {info.FrameRate}\r\n" +
                                   $"比特率: {info.Bitrate}";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"分析视频失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnConvert_Click(object sender, EventArgs e)
        {
            if (_fileList.Count == 0)
            {
                XtraMessageBox.Show("请先添加要转换的文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputFolder = folderDialog.SelectedPath;
                    progressBar.Properties.Step = 1;
                    progressBar.Properties.Minimum = 0;
                    progressBar.Properties.Maximum = _fileList.Count * 100;
                    progressBar.Position = 0;

                    try
                    {
                        btnConvert.Enabled = false;
                        txtLog.Clear();

                        await _ffmpegService.BatchConvertAsync(
                            _fileList.ToArray(),
                            outputFolder,
                            cboVideoCodec.Text,
                            cboResolution.Text,
                            cboBitrate.Text,
                            fps.Text,
                            new Progress<(int fileIndex, int progress, string output)>((p) =>
                            {
                                this.Invoke(new Action(() =>
                                {
                                    int totalProgress = (p.fileIndex * 100) + p.progress;
                                    progressBar.Position = totalProgress;
                                    txtLog.AppendText($"[文件 {p.fileIndex + 1}/{_fileList.Count}] {p.output}\r\n");
                                }));
                            }));

                        XtraMessageBox.Show("所有文件转换完成", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"转换过程中出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        btnConvert.Enabled = true;
                    }
                }
            }
        }

        private void BtnPresetSave_Click(object sender, EventArgs e)
        {
            string presetName = txtPresetName.Text.Trim();
            if (string.IsNullOrEmpty(presetName))
            {
                XtraMessageBox.Show("请输入预设名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var preset = new Preset
            {
                Name = presetName,
                VideoCodec = cboVideoCodec.Text,
                Resolution = cboResolution.Text,
                Bitrate = cboBitrate.Text,
                fps = fps.Text
            };

            // 检查是否已存在同名预设
            var existingIndex = _presets.FindIndex(p => p.Name.Equals(presetName, StringComparison.OrdinalIgnoreCase));
            if (existingIndex >= 0)
            {
                _presets[existingIndex] = preset;
            }
            else
            {
                _presets.Add(preset);
            }

            _presetService.SavePresets(_presets);
            LoadPresets();
            XtraMessageBox.Show("预设保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnPresetManage_Click(object sender, EventArgs e)
        {
            using (var form = new PresetForm(_presets))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _presetService.SavePresets(form.Presets);
                    LoadPresets();
                }
            }
        }

        private void cboPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPreset.SelectedIndex >= 0)
            {
                var selectedPreset = _presets[cboPreset.SelectedIndex];
                ApplyPreset(selectedPreset);
            }
        }

        #endregion


        private void StopButton_Click(object sender, EventArgs e)
        {
            string processFFmpeg = "ffmpeg"; // 查找的程序进程名称
            Process[] processesffmpeg = Process.GetProcessesByName(processFFmpeg);
            foreach (Process process in processesffmpeg)
            {
                process.Kill();
            }
        }

    }
}
