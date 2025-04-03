using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Text.RegularExpressions;


namespace Mihoyo_Tools
{
    public partial class Lrc_srt : DevExpress.XtraEditors.XtraUserControl
    {
        public Lrc_srt()
        {
            InitializeComponent();
        }

        private void txtLRCFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "LRC Files (*.lrc)|*.lrc|All Files (*.*)|*.*",
                Title = "选择LRC歌词文件"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLRCFilePath.Text = openFileDialog.FileName;
                try
                {
                    // 使用更可靠的编码检测和读取方式
                    string fileContent = File.ReadAllText(openFileDialog.FileName, GetFileEncoding(openFileDialog.FileName));
                    memoEdit_Lrc.Text = fileContent;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"读取文件失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLRCFilePath.Text) || !File.Exists(txtLRCFilePath.Text))
            {
                XtraMessageBox.Show("请选择一个有效的LRC文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string lrcFilePath = txtLRCFilePath.Text;
                string srtContent = ConvertLRCtoSRT(lrcFilePath);
                memoEdit_str.Text = srtContent;

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "SRT Files (*.srt)|*.srt|All Files (*.*)|*.*",
                    DefaultExt = ".srt",
                    Title = "保存SRT字幕文件"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 强制使用带BOM的UTF-8编码保存
                    File.WriteAllText(saveFileDialog.FileName, srtContent, new UTF8Encoding(true));
                    XtraMessageBox.Show("转换完成并保存成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"转换过程中出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ConvertLRCtoSRT(string lrcFilePath)
        {
            StringBuilder srtBuilder = new StringBuilder();

            // 使用确定的编码读取文件
            Encoding encoding = GetFileEncoding(lrcFilePath);
            string[] lrcLines = File.ReadAllLines(lrcFilePath, encoding);

            List<(TimeSpan StartTime, string Lyrics)> lyricsList = new List<(TimeSpan, string)>();

            // 改进的正则表达式，匹配LRC时间标签和歌词
            // 支持以下格式：[mm:ss.xx] 或 [mm:ss:xx] 或 [mm:ss]
            Regex regex = new Regex(@"^\[(\d+):(\d+)(?:[:\.](\d+))?\](.*)$");

            foreach (string line in lrcLines)
            {
                // 跳过元数据行（如[ar:...]、[ti:...]等）
                if (line.StartsWith("[") && line.Contains(":") && !line.Contains("]"))
                    continue;

                Match match = regex.Match(line);
                if (match.Success)
                {
                    string minutes = match.Groups[1].Value;
                    string seconds = match.Groups[2].Value;
                    string milliseconds = match.Groups[3].Value;
                    string lyrics = match.Groups[4].Value.Trim();

                    // 跳过空歌词行和元数据
                    if (string.IsNullOrWhiteSpace(lyrics))
                        continue;

                    TimeSpan startTime = ParseLrcTime(minutes, seconds, milliseconds);
                    lyricsList.Add((startTime, lyrics));
                }
            }

            // 按时间排序
            lyricsList.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));

            // 生成SRT内容
            for (int i = 0; i < lyricsList.Count; i++)
            {
                TimeSpan startTime = lyricsList[i].StartTime;
                // 结束时间：如果是最后一句，则延长5秒；否则使用下一句的开始时间
                TimeSpan endTime = (i < lyricsList.Count - 1) ? lyricsList[i + 1].StartTime : startTime.Add(TimeSpan.FromSeconds(5));

                srtBuilder.AppendLine((i + 1).ToString());
                srtBuilder.AppendLine($"{FormatTimeSpan(startTime)} --> {FormatTimeSpan(endTime)}");
                srtBuilder.AppendLine(lyricsList[i].Lyrics);
                srtBuilder.AppendLine(); // SRT要求字幕块之间有空行
            }

            return srtBuilder.ToString();
        }

        // 格式化TimeSpan为SRT时间格式 (hh:mm:ss,fff)
        private string FormatTimeSpan(TimeSpan time)
        {
            return $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00},{time.Milliseconds:000}";
        }

        private TimeSpan ParseLrcTime(string minutes, string seconds, string milliseconds)
        {
            int min = int.Parse(minutes);
            int sec = int.Parse(seconds);

            // 处理毫秒部分：
            // 1. 如果未提供毫秒部分，默认为0
            // 2. 如果提供的是2位数（如LRC常见的.xx格式），乘以10转换为毫秒
            // 3. 如果提供的是3位数，直接使用
            int ms = 0;
            if (!string.IsNullOrEmpty(milliseconds))
            {
                ms = int.Parse(milliseconds);
                if (milliseconds.Length == 2) // LRC文件通常使用2位小数表示百分秒
                {
                    ms *= 10; // 将"27"转换为270毫秒
                }
                else if (milliseconds.Length > 3)
                {
                    ms = int.Parse(milliseconds.Substring(0, 3));
                }
            }

            return new TimeSpan(0, 0, min, sec, ms);
        }

        // 更可靠的编码检测方法
        private Encoding GetFileEncoding(string filename)
        {
            // 读取BOM头
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // 根据BOM判断编码
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode;
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode;
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;

            // 如果没有BOM，尝试用常见中文编码读取
            try
            {
                // 注册编码提供程序以支持GB18030
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // 先尝试GB18030（兼容GB2312和GBK）
                var gb18030 = Encoding.GetEncoding("GB18030");
                string content = File.ReadAllText(filename, gb18030);
                if (IsValidText(content)) return gb18030;
            }
            catch { }

            // 尝试UTF-8无BOM
            try
            {
                string content = File.ReadAllText(filename, new UTF8Encoding(false));
                if (IsValidText(content)) return new UTF8Encoding(false);
            }
            catch { }

            // 默认返回系统当前ANSI编码（中文Windows通常是GBK）
            return Encoding.Default;
        }

        // 辅助方法：检查文本是否有效（不含过多乱码）
        private bool IsValidText(string text)
        {
            if (string.IsNullOrEmpty(text)) return true;

            // 统计无效字符（控制字符，除了常见的\t \r \n）
            int invalidCount = 0;
            foreach (char c in text)
            {
                if (c == '\r' || c == '\n' || c == '\t') continue;
                if (char.IsControl(c)) invalidCount++;
            }

            // 如果无效字符超过5%，认为不是有效文本
            return (double)invalidCount / text.Length < 0.05;
        }
    }
}
