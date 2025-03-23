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
using System.Text.RegularExpressions;
using System.IO;

namespace Mihoyo_Tools
{
	public partial class Control_LrcToSrt: DevExpress.XtraEditors.XtraUserControl
	{
        public Control_LrcToSrt()
		{
            InitializeComponent();
		}

        private void btnSelectLRC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "LRC Files (*.lrc)|*.lrc|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLRCFilePath.Text = openFileDialog.FileName;
                // 使用StreamReader读取文件内容，并自动检测编码
                using (StreamReader reader = new StreamReader(openFileDialog.FileName, Encoding.Default, true))
                {
                    // 将文件内容读取到RichTextBox中
                    richTextBox1.Text = reader.ReadToEnd();
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

            string lrcFilePath = txtLRCFilePath.Text;
            string srtContent = ConvertLRCtoSRT(lrcFilePath);

            rtbSRTContent.Text = srtContent;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SRT Files (*.srt)|*.srt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 以UTF-8编码保存SRT文件
                File.WriteAllText(saveFileDialog.FileName, srtContent, Encoding.UTF8);
                XtraMessageBox.Show("转换完成并保存成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string ConvertLRCtoSRT(string lrcFilePath)
        {
            StringBuilder srtBuilder = new StringBuilder();
            string[] lrcLines;

            // 检测文件编码并读取文件
            Encoding encoding = DetectFileEncoding(lrcFilePath);
            lrcLines = File.ReadAllLines(lrcFilePath, encoding);

            // 用于存储歌词和时间标签
            List<(TimeSpan StartTime, string Lyrics)> lyricsList = new List<(TimeSpan, string)>();

            // 正则表达式匹配时间标签和歌词
            Regex regex = new Regex(@"\[(\d+:\d+\.\d+)\](.*)");

            foreach (string line in lrcLines)
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    string timeTag = match.Groups[1].Value; // 时间标签
                    string lyrics = match.Groups[2].Value.Trim(); // 歌词

                    if (string.IsNullOrEmpty(lyrics)) continue;

                    // 将时间标签转换为TimeSpan
                    TimeSpan startTime = ParseLrcTime(timeTag);

                    // 添加到歌词列表
                    lyricsList.Add((startTime, lyrics));
                }
            }

            // 按时间排序
            lyricsList.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));

            // 生成SRT内容
            for (int i = 0; i < lyricsList.Count; i++)
            {
                TimeSpan startTime = lyricsList[i].StartTime;
                TimeSpan endTime = (i < lyricsList.Count - 1) ? lyricsList[i + 1].StartTime : startTime.Add(TimeSpan.FromSeconds(5)); // 如果最后一句，默认持续5秒

                srtBuilder.AppendLine((i + 1).ToString());
                srtBuilder.AppendLine($"{startTime:hh\\:mm\\:ss\\,fff} --> {endTime:hh\\:mm\\:ss\\,fff}");
                srtBuilder.AppendLine(lyricsList[i].Lyrics);
                srtBuilder.AppendLine();
            }

            return srtBuilder.ToString();
        }

        private TimeSpan ParseLrcTime(string timeTag)
        {
            // LRC时间格式为 [mm:ss.ff]，需要转换为 TimeSpan
            string[] parts = timeTag.Split(':', '.');
            int minutes = int.Parse(parts[0]);
            int seconds = int.Parse(parts[1]);
            //int milliseconds = int.Parse(parts[2]*10); 
            int milliseconds = int.Parse(parts[2]); // 修复后的时间

            return new TimeSpan(0, 0, minutes, seconds, milliseconds);
        }

        private Encoding DetectFileEncoding(string filePath)
        {
            // 读取文件的前几个字节来检测编码
            byte[] buffer = new byte[5];
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                file.Read(buffer, 0, buffer.Length);
            }

            // 检测UTF-8 BOM
            if (buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)
            {
                return Encoding.UTF8;
            }

            // 检测UTF-16 (Little Endian) BOM
            if (buffer[0] == 0xFF && buffer[1] == 0xFE)
            {
                return Encoding.Unicode;
            }

            // 检测UTF-16 (Big Endian) BOM
            if (buffer[0] == 0xFE && buffer[1] == 0xFF)
            {
                return Encoding.BigEndianUnicode;
            }

            // 默认使用系统默认编码（通常为GB2312或UTF-8）
            return Encoding.Default;
        }
    }
}
