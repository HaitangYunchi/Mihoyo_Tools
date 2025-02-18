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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Mihoyo_Tools
{
    public partial class Control_Genshin_usm : DevExpress.XtraEditors.XtraUserControl
    {
        public Control_Genshin_usm()
        {
            InitializeComponent();
        }
        static StringBuilder sortOutput = null;
        Process sortProcess;

        private void Control_Genshin_usm_Load(object sender, EventArgs e)
        {
            textEdit1.Text = GlobalVar.StrPath + @"\data\GICutscenes.exe";
            textEdit2.Text = GlobalVar.StrPath + @"\data\ffmpeg.exe";
            INIFile.writeString("Config", "Cutscenes", textEdit1.Text, GlobalVar.IniName);
            INIFile.writeString("Config", "Ffmpeg", textEdit2.Text, GlobalVar.IniName);

        }

        private void buttonEdit_Game_path_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // 游戏目录
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择 YuanShen.exe";
            openFileDialog.Filter = "程序文件|YuanShen.exe";
            openFileDialog.InitialDirectory = @"D:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                GlobalVar.SelectedFolder = System.IO.Path.GetDirectoryName(selectedFile);
                buttonEdit_Game_path.Text = GlobalVar.SelectedFolder;
                GlobalVar.Games_path = GlobalVar.SelectedFolder;
                INIFile.writeString("Config", "Games_path", GlobalVar.Games_path, GlobalVar.IniName);
                // XtraMessageBox.Show("选择的文件夹为：" +  GlobalVar.SelectedFolder);
            }
            else
            {
                buttonEdit_Game_path.Text = "";
                GlobalVar.Games_path = buttonEdit_Game_path.Text;
            }

        }

        private void buttonEdit_usm_path_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_usm_path.Text = f.SelectedPath;
                INIFile.writeString("Config", "USM_path", buttonEdit_usm_path.Text, GlobalVar.IniName);
            }
        }

        private void buttonEdit_Out_path_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            // 输出目录
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                GlobalVar.Output_path = f.SelectedPath;
                buttonEdit_Out_path.Text = GlobalVar.Output_path;//返回文件夹路径
                INIFile.writeString("Config", "Output_path", GlobalVar.Output_path, GlobalVar.IniName);
            }
        }

        private void buttonEdit_usm_Name_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //USM 文件
            //

            if (buttonEdit_Game_path.Text == "")
            {
                XtraMessageBox.Show("游戏目录不能为！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Title = "选择 USM文件";
                file.Filter = "USM文件（*.usm）|*.usm";
                file.InitialDirectory = GlobalVar.Games_path + @"\YuanShen_Data\StreamingAssets\VideoAssets\StandaloneWindows64";
                file.Multiselect = false;
                if (file.ShowDialog() == DialogResult.Cancel)
                {
                    this.buttonEdit_usm_Name.Text = "";
                }
                else
                {
                    GlobalVar.USM_Files = file.FileName;//会返回 USM 文件全路径，包含了文件名和后缀
                    string _temp = Path.GetFileName(GlobalVar.USM_Files);
                    this.buttonEdit_usm_Name.Text = _temp;//返回 USM 文件名和后缀
                    GlobalVar.Video_Name = Path.GetFileNameWithoutExtension(_temp);
                    //XtraMessageBox.Show(GlobalVar.Video_Name);
                }
            }
        }

        private void button_LoadIni_Click(object sender, EventArgs e)
        {
            GlobalVar.GICutscents_path = GlobalVar.StrPath + @"\data\GICutscenes.exe";
            GlobalVar.Ffmpeg_path = GlobalVar.StrPath + @"\data\ffmpeg.exe";
            GlobalVar.Output_path = INIFile.getString("Config", "Output_path", "", GlobalVar.IniName);
            GlobalVar.Games_path = INIFile.getString("Config", "Games_path", "", GlobalVar.IniName);
            textEdit1.Text = GlobalVar.GICutscents_path;
            textEdit2.Text = GlobalVar.Ffmpeg_path;
            buttonEdit_Out_path.Text = GlobalVar.Output_path;
            buttonEdit_Game_path.Text = GlobalVar.Games_path;
            buttonEdit_usm_path.Text = INIFile.getString("Config", "USM_path", "", GlobalVar.IniName);
        }
   
        private void simpleButton_Out_Click(object sender, EventArgs e)
        {
            progressBar.Value = 100;
            backgroundWorker_Game_path.RunWorkerAsync();

        }

        private void backgroundWorker_Game_path_DoWork(object sender, DoWorkEventArgs e)
        {
            string GICutscenes = GlobalVar.StrPath + @"\data\GICutscenes.exe";
            string ffmpeg = GlobalVar.StrPath + @"\data\ffmpeg.exe";
            string ffplay = GlobalVar.StrPath + @"\data\ffplay.exe";
            string version = GlobalVar.StrPath + @"\data\versions.json";
            bool fileGICutscenes = File.Exists(GICutscenes);
            bool fileffmpeg = File.Exists(ffmpeg);
            bool fileffplay = File.Exists(ffplay);
            bool fileversion = File.Exists(version);
            if (fileGICutscenes == false)
            {
                XtraMessageBox.Show("GICutscenes 文件不存在！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (fileffmpeg == false)
            {
                XtraMessageBox.Show("FFmpge 文件不存在！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (fileffplay == false)
            {
                XtraMessageBox.Show("FFplay 文件不存在！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (fileversion == false)
            {
                XtraMessageBox.Show("versions.json 文件不存在！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radioButton_Game_path.Checked == true)
            {
                if (buttonEdit_Game_path.Text == "")
                {
                    XtraMessageBox.Show("游戏目录不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if(buttonEdit_Out_path.Text == "")
                {
                    XtraMessageBox.Show("输出目录不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                GlobalVar.USM_dir = GlobalVar.Games_path + @"\YuanShen_Data\StreamingAssets\VideoAssets\StandaloneWindows64";
                GlobalVar.Command_cmd = "GICutscenes batchDemux " + "\"" + GlobalVar.USM_dir + "\"" + " -o " + "\"" + GlobalVar.Output_path + "\"" + " -m  -e ffmpeg &&exit";
                WriteToTextBox("--------------------------");
                BatchDemuxe();
                Process.Start("explorer.exe", GlobalVar.Output_path);
            }
            else if (radioButton_usm_path.Checked == true)
            {
                if (buttonEdit_usm_path.Text == "")
                {
                    XtraMessageBox.Show("自定义usm目录不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (buttonEdit_Out_path.Text == "")
                {
                    XtraMessageBox.Show("输出目录不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                GlobalVar.USM_dir = buttonEdit_usm_path.Text;
                INIFile.writeString("Config", "usm_path", buttonEdit_usm_path.Text, GlobalVar.IniName);
                GlobalVar.Command_cmd = "GICutscenes batchDemux " + "\"" + GlobalVar.USM_dir + "\"" + " -o " + "\"" + GlobalVar.Output_path + "\"" + " -m  -e ffmpeg &&exit";
                WriteToTextBox("--------------------------");
                BatchDemuxe();
                Process.Start("explorer.exe", GlobalVar.Output_path);
            }
            else
            {
                if (textEdit1.Text == "")
                {
                    XtraMessageBox.Show("GICutscenes 程序不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textEdit2.Text == "")
                {
                    XtraMessageBox.Show("Ffmpeg 程序不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (buttonEdit_Out_path.Text == "")
                {
                    XtraMessageBox.Show("输出目录不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (buttonEdit_Game_path.Text == "")
                {
                    XtraMessageBox.Show("游戏目录不能为空！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (buttonEdit_usm_Name.Text == "")
                {
                    XtraMessageBox.Show("请选择要转换的文件！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (radioButton_CN.Checked == true)
                    {
                        GlobalVar.Out_Language = "0";
                    }
                    else if (radioButton_EN.Checked == true)
                    {
                        GlobalVar.Out_Language = "1";
                    }
                    else if (radioButton_JP.Checked == true)
                    {
                        GlobalVar.Out_Language = "2";
                    }
                    else if (radioButton_KR.Checked == true)
                    {
                        GlobalVar.Out_Language = "3";
                    }
                    else
                    {
                        GlobalVar.Out_Language = "0";
                    }
                    INIFile.writeString("Config", "Language", GlobalVar.Out_Language, GlobalVar.IniName);
                    // MessageBox.Show("选择的语言：" + GlobalVar.Out_Language);
                    GlobalVar.Audio_Name = GlobalVar.Video_Name + "_" + GlobalVar.Out_Language + ".wav";
                    GlobalVar._tempVideo_Name = GlobalVar.Output_path + "\\" + GlobalVar.Video_Name + "\\" + GlobalVar.Video_Name + "_" + GlobalVar.Out_Language + ".mkv";
                    WriteToTextBox("--------------------------");
                    WriteToTextBox("正在导出：" + GlobalVar.Video_Name);
                    WriteToTextBox(" ");
                    WriteToTextBox(RunUsm(" demuxUsm " + "\"" + GlobalVar.USM_Files + "\"" + " -o " + GlobalVar.Output_path + "\\" + GlobalVar.Video_Name));
                    WriteToTextBox(RunMpeg(" -i " + GlobalVar.Output_path + "\\" + GlobalVar.Video_Name + "\\" + GlobalVar.Video_Name + ".ivf" + " -i " + GlobalVar.Output_path + "\\" + GlobalVar.Video_Name + "\\" + GlobalVar.Audio_Name + " -c:v copy -c:a copy " + GlobalVar.Output_path + "\\" + GlobalVar.Video_Name + "\\" + GlobalVar.Video_Name + "_" + GlobalVar.Out_Language + ".mkv"));
                    WriteToTextBox(" ");
   
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(GlobalVar.Output_path + "\\" + GlobalVar.Video_Name);
                        FileInfo[] dii = di.GetFiles();
                        if (dii.Length != 0)
                        {
                            foreach (FileInfo fi in dii)
                            {
                                if (fi.Extension == ".ivf" || fi.Extension == ".hca" || fi.Extension == ".wav")
                                {
                                    fi.Delete();
                                }
                            }
                            XtraMessageBox.Show("导出完成！\n点击确定预览视频！", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start("explorer.exe", GlobalVar.Output_path + @"\" + GlobalVar.Video_Name);
                            WriteToTextBox("完成");
                            GlobalVar.Command_Play = Application.StartupPath + @"\data\ffplay.exe";
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = GlobalVar.Command_Play;
                            startInfo.Arguments = $"-autoexit {GlobalVar._tempVideo_Name}"; // -autoexit播放完成后自动退出
                            startInfo.UseShellExecute = false;
                            startInfo.RedirectStandardOutput = true;
                            startInfo.CreateNoWindow = true; // 不创建新窗口（后台运行）
                            using (Process process = Process.Start(startInfo))
                            {
                                string output = process.StandardOutput.ReadToEnd();
                                Console.WriteLine(output);
                                process.WaitForExit(); // 等待进程结束
                            }
                        }

                    }
                    catch
                    {
                        //XtraMessageBox.Show("删除失败", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }

        private void backgroundWorker_Game_path_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = (int)(e.ProgressPercentage);
            this.Invoke((MethodInvoker)delegate
            {
                progressBar.Value = progress;
            });
        }

        private void backgroundWorker_Game_path_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        public void WriteToTextBox(string info)
        {
            if (string.IsNullOrWhiteSpace(info))
            {
                info = "";
            }

            if (this.txtInfo.InvokeRequired)
            {
                this.txtInfo.Invoke(new Action<string>(WriteToTextBox), info);
            }
            else
            {
                this.txtInfo.Text += info + "\r\n";

                // 滚到最后
                this.txtInfo.SelectionStart = this.txtInfo.Text.Length;
                this.txtInfo.ScrollToCaret();
            }
        }
        public void BatchDemuxe()
        {
            if (sortProcess != null)
            {
                sortProcess.Close();
            }
            sortProcess = new Process();
            sortOutput = new StringBuilder("");
            sortProcess.StartInfo.FileName = "cmd.exe";
            sortProcess.StartInfo.UseShellExecute = false;
            sortProcess.StartInfo.RedirectStandardOutput = true;
            sortProcess.StartInfo.RedirectStandardError = true;
            sortProcess.StartInfo.CreateNoWindow = true;
            sortProcess.StartInfo.RedirectStandardInput = true;
            sortProcess.StartInfo.Arguments = "/c " + "cd "+GlobalVar.StrPath+@"\data &&"+ GlobalVar.Command_cmd;
            sortProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8; // 指定输出流编码为 UTF-8
            sortProcess.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            sortProcess.Start();
            sortProcess.BeginOutputReadLine();
            sortProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
        }
        private void SortOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                this.txtInfo.Text += outLine.Data + Environment.NewLine;
                txtInfo.SelectionStart = txtInfo.TextLength;
                txtInfo.ScrollToCaret();
            }
        }
        public string RunUsm(string arguments)
        {
            GlobalVar.Command_Usm = GlobalVar.StrPath + @"\data\GICutscenes.exe";
            Process usm = new Process();
            usm.StartInfo.FileName = GlobalVar.Command_Usm;           //设定程序名  
            usm.StartInfo.Arguments = arguments;    //设定执行参数  
            usm.StartInfo.UseShellExecute = false;        //关闭Shell的使用  
            usm.StartInfo.RedirectStandardInput = true;   //重定向标准输入  
            usm.StartInfo.RedirectStandardOutput = true;  //重定向标准输出  
            usm.StartInfo.RedirectStandardError = true;   //重定向错误输出  
            usm.StartInfo.CreateNoWindow = true;          //设置不显示窗口  
            usm.StartInfo.StandardOutputEncoding = Encoding.UTF8; // 指定输出流编码为 UTF-8
            usm.StartInfo.StandardErrorEncoding = Encoding.UTF8; // 指定错误输出流编码为 UTF-8
            usm.Start();

            string result = usm.StandardOutput.ReadToEnd(); // 正确输出
            var errOuput = usm.StandardError.ReadToEnd(); // 错误输出
            usm.Close();

            return result + "\r\n" + errOuput;
        }
        public string RunMpeg(string arguments)
        {
            GlobalVar.Command_Mpeg = GlobalVar.StrPath + @"\data\ffmpeg.exe";
            Process mpeg = new Process();
            mpeg.StartInfo.FileName = GlobalVar.Command_Mpeg;           //设定程序名  
            mpeg.StartInfo.Arguments = arguments;    //设定执行参数  
            mpeg.StartInfo.UseShellExecute = false;        //关闭Shell的使用  
            mpeg.StartInfo.RedirectStandardInput = true;   //重定向标准输入  
            mpeg.StartInfo.RedirectStandardOutput = true;  //重定向标准输出  
            mpeg.StartInfo.RedirectStandardError = true;   //重定向错误输出  
            mpeg.StartInfo.CreateNoWindow = true;          //设置不显示窗口  
            mpeg.StartInfo.StandardOutputEncoding = Encoding.UTF8; // 指定输出流编码为 UTF-8
            mpeg.StartInfo.StandardErrorEncoding = Encoding.UTF8; // 指定错误输出流编码为 UTF-8
            mpeg.Start();

            string result1 = mpeg.StandardOutput.ReadToEnd(); // 正确输出
            var errOuput1 = mpeg.StandardError.ReadToEnd(); // 错误输出
            mpeg.Close();

            return result1 + "\r\n" + errOuput1;
        }
        private void radioButton_CN_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "国语配音";
            GlobalVar.Out_Language = "0";
        }

        private void radioButton_EN_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "英语配音";
            GlobalVar.Out_Language = "1";
        }

        private void radioButton_JP_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "日语配音";
            GlobalVar.Out_Language = "2";
        }

        private void radioButton_KR_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "韩语配音";
            GlobalVar.Out_Language = "3";
        }

        private void radioButton_Game_path_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVar.Outdir = "1";
        }

        private void radioButton_usm_path_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVar.Outdir = "2";
        }
    }
}
