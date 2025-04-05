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
using DevExpress.DataAccess.Native;
using static Mihoyo_Tools.lib.JsonHelper;
using System.Windows.Input;
using DevExpress.XtraSpreadsheet.Model;
using System.IO;
using System.Diagnostics;
using Mihoyo_Tools.lib;
using DevExpress.Data.ExpressionEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static DevExpress.Utils.Frames.FrameHelper;
using System.Threading;

namespace Mihoyo_Tools
{
    public partial class Genshin_usm : DevExpress.XtraEditors.XtraUserControl
    {
        string SettingFile = lib.VarHelper.Var.Setting;

        public Action<MemoEdit> ScrollMemoToEnd { get; private set; }

        public Genshin_usm()
        {
            InitializeComponent();
            var JsonData = new lib.JsonHelper.JsonData();
            Gutscenes_path.Text = lib.VarHelper.Var.GICutscents_path;
            FFmpeg_path.Text = lib.VarHelper.Var.Ffmpeg_path;
            buttonEdit_Game_path.Text = lib.JsonHelper.ReadJson(SettingFile, JsonData).Games_path;
            lib.VarHelper.Var.Games_path = lib.JsonHelper.ReadJson(SettingFile, JsonData).Games_path;
            buttonEdit_usm_path.Text = lib.JsonHelper.ReadJson(SettingFile, JsonData).USM_path;
            lib.VarHelper.Var.USM_path = lib.JsonHelper.ReadJson(SettingFile, JsonData).USM_path;
            buttonEdit_Out_path.Text = lib.JsonHelper.ReadJson(SettingFile, JsonData).Output_path;
            lib.VarHelper.Var.Output_path = lib.JsonHelper.ReadJson(SettingFile, JsonData).Output_path;
            simpleButton_Stop.Enabled = false;
            simpleButton_Out.Text = "普通话音轨导出";
            lib.JsonHelper.MergeJson(SettingFile, new { GICutscennts_path = Gutscenes_path.Text });
            lib.JsonHelper.MergeJson(SettingFile, new { FFmpeg_path = FFmpeg_path.Text });
        }

        private void radioButton_CN_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "普通话音轨导出";
            lib.VarHelper.Var.Language = 0;
            simpleButton_Stop.Enabled = false;
        }

        private void radioButton_EN_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "English Audio Track";
            lib.VarHelper.Var.Language = 1;
            simpleButton_Stop.Enabled = false;
        }

        private void radioButton_JP_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "日本語トラック";
            lib.VarHelper.Var.Language = 2;
            simpleButton_Stop.Enabled = false;
        }

        private void radioButton_KR_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "한국어 더빙 트랙";
            lib.VarHelper.Var.Language = 3;
            simpleButton_Stop.Enabled = false;
        }

        private void radioButton_Game_path_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "游戏目录导出(多轨)";
            lib.VarHelper.Var.Language = 0;
            simpleButton_Stop.Enabled = true;
        }

        private void radioButton_usm_path_CheckedChanged(object sender, EventArgs e)
        {
            simpleButton_Out.Text = "自定义目录导出(多轨)";
            lib.VarHelper.Var.Language = 0;
            simpleButton_Stop.Enabled = true;
        }

        private void buttonEdit_Game_path_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var JsonData = new lib.JsonHelper.JsonData();
            // 游戏目录
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择 YuanShen.exe";
            openFileDialog.Filter = "程序文件|YuanShen.exe";
            openFileDialog.InitialDirectory = @"D:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                lib.VarHelper.Var.SelectedFolder = System.IO.Path.GetDirectoryName(selectedFile);
                buttonEdit_Game_path.Text = lib.VarHelper.Var.SelectedFolder;
                lib.VarHelper.Var.Games_path = lib.VarHelper.Var.SelectedFolder;
                lib.JsonHelper.MergeJson(SettingFile, new { Games_path = lib.VarHelper.Var.Games_path });
            }
            else
            {
                buttonEdit_Game_path.Text = "";
                lib.VarHelper.Var.Games_path = buttonEdit_Game_path.Text;
            }
        }

        private void buttonEdit_usm_path_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // 自定义目录
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                buttonEdit_usm_path.Text = f.SelectedPath;
                lib.VarHelper.Var.USM_path = buttonEdit_usm_path.Text;
                lib.JsonHelper.MergeJson(SettingFile, new { USM_path = buttonEdit_usm_path.Text });
            }
        }

        private void buttonEdit_Out_path_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // 输出目录
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                lib.VarHelper.Var.Output_path = f.SelectedPath;
                buttonEdit_Out_path.Text = lib.VarHelper.Var.Output_path;//返回文件夹路径
                lib.JsonHelper.MergeJson(SettingFile, new { Output_path = lib.VarHelper.Var.Output_path });
            }
        }

        private void buttonEdit_usm_Name_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // 选择USM 文件
            if (buttonEdit_Game_path.Text == "")
            {
                XtraMessageBox.Show("游戏目录不能为！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Title = "选择 USM文件";
                file.Filter = "USM文件（*.usm）|*.usm";
                file.InitialDirectory = lib.VarHelper.Var.Games_path + @"\YuanShen_Data\StreamingAssets\VideoAssets\StandaloneWindows64";
                file.Multiselect = false;
                if (file.ShowDialog() == DialogResult.Cancel)
                {
                    this.buttonEdit_usm_Name.Text = "";
                }
                else
                {
                    lib.VarHelper.Var.USM_Files = file.FileName;//会返回 USM 文件全路径，包含了文件名和后缀
                    string _temp = Path.GetFileName(lib.VarHelper.Var.USM_Files);
                    this.buttonEdit_usm_Name.Text = _temp;//返回 USM 文件名和后缀
                    lib.VarHelper.Var.Video_Name = Path.GetFileNameWithoutExtension(_temp);
                    //XtraMessageBox.Show(lib.VarHelper.Var.Video_Name);
                }
            }
        }

        private async void simpleButton_Out_Click(object sender, EventArgs e)
        {
            var JsonData = new lib.JsonHelper.JsonData();
            ScrollToEnd(memoEdit_out); // 初始滚动到底部
            simpleButton_Out.Enabled = false;
            string GICutscenes = lib.VarHelper.Var.GICutscents_path;
            string ffmpeg = lib.VarHelper.Var.Ffmpeg_path;
            string ffplay = lib.VarHelper.Var.StrPath + @"\data\ffplay.exe";
            string version = lib.VarHelper.Var.VersionPath;
            bool fileGICutscenes = File.Exists(GICutscenes);
            bool fileffmpeg = File.Exists(ffmpeg);
            bool fileffplay = File.Exists(ffplay);
            bool fileversion = File.Exists(version);
            if (fileGICutscenes == false)
            {
                XtraMessageBox.Show("GICutscenes 文件不存在！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (fileffmpeg == false)
            {
                XtraMessageBox.Show("FFmpge 文件不存在！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (fileffplay == false)
            {
                XtraMessageBox.Show("FFplay 文件不存在！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (fileversion == false)
            {
                XtraMessageBox.Show("versions.json 文件不存在！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radioButton_Game_path.Checked == true)
            {
                if (buttonEdit_Game_path.Text == "")
                {
                    XtraMessageBox.Show("游戏目录不能为空！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (buttonEdit_Out_path.Text == "")
                {
                    XtraMessageBox.Show("输出目录不能为空！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string usm_path = lib.VarHelper.Var.Games_path + @"\YuanShen_Data\StreamingAssets\VideoAssets\StandaloneWindows64";
                lib.VarHelper.Var.Command_cmd = $"batchDemux \"{usm_path}\" -o \"{lib.VarHelper.Var.Output_path}\" -m -e ffmpeg";
                try
                {
                    // 异步执行命令并实时输出
                    await CommandHelper.ExecuteGutscenesAsync(
                        lib.VarHelper.Var.Command_cmd.Trim(),
                        output =>
                        {
                            // 跨线程更新UI
                            this.Invoke((Action)(() =>
                            {
                                memoEdit_out.AppendText(output + Environment.NewLine);
                                ScrollToEnd(memoEdit_out);
                            }));
                        },
                        error =>
                        {
                            // 跨线程更新UI
                            this.Invoke((Action)(() =>
                            {
                                memoEdit_out.AppendText($"{error}" + Environment.NewLine);
                                ScrollToEnd(memoEdit_out);
                            }));
                        });
                }
                catch (Exception)
                {
                    ScrollToEnd(memoEdit_out);
                }
                finally
                {
                    // 显示完成消息
                    memoEdit_out.AppendText("\n[全部处理完成]\n");
                    ScrollToEnd(memoEdit_out);
                    // 重新启用按钮
                    simpleButton_Out.Enabled = true;
                }
                XtraMessageBox.Show($"全部处理完成！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("explorer.exe", lib.VarHelper.Var.Output_path);
            }
            else if (radioButton_usm_path.Checked == true)
            {
                if (buttonEdit_usm_path.Text == "")
                {
                    XtraMessageBox.Show("自定义usm目录不能为空！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (buttonEdit_Out_path.Text == "")
                {
                    XtraMessageBox.Show("输出目录不能为空！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string _usm_path = lib.JsonHelper.ReadJson(SettingFile, JsonData).USM_path;
                lib.VarHelper.Var.Command_cmd = $"batchDemux \"{_usm_path}\" -o \"{lib.VarHelper.Var.Output_path}\" -m -e ffmpeg";
                try
                {
                    // 异步执行命令并实时输出
                    await CommandHelper.ExecuteGutscenesAsync(
                        lib.VarHelper.Var.Command_cmd.Trim(),
                        output =>
                        {
                            // 跨线程更新UI
                            this.Invoke((Action)(() =>
                            {
                                memoEdit_out.AppendText(output + Environment.NewLine);
                                ScrollToEnd(memoEdit_out);
                            }));
                        },
                        error =>
                        {
                            // 跨线程更新UI
                            this.Invoke((Action)(() =>
                            {
                                memoEdit_out.AppendText($"{error}" + Environment.NewLine);
                                ScrollToEnd(memoEdit_out);
                            }));
                        });

                }
                catch (Exception)
                {
                    ScrollToEnd(memoEdit_out);
                }
                finally
                {
                    // 显示完成消息
                    memoEdit_out.AppendText("\n[全部处理完成]\n");
                    ScrollToEnd(memoEdit_out);
                    // 重新启用按钮
                    simpleButton_Out.Enabled = true;
                }

                XtraMessageBox.Show($"全部处理完成！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("explorer.exe", lib.VarHelper.Var.Output_path);

            }
            else
            {
                simpleButton_Stop.Enabled = false;
                if (buttonEdit_Out_path.Text == "")
                {
                    XtraMessageBox.Show("输出目录不能为空！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (buttonEdit_Game_path.Text == "")
                {
                    XtraMessageBox.Show("游戏目录不能为空！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (buttonEdit_usm_Name.Text == "")
                {
                    XtraMessageBox.Show("请选择要转换的文件！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string SetLanguage = "";
                    if (radioButton_CN.Checked == true)
                    {
                        lib.VarHelper.Var.Language = 0;
                        SetLanguage = "CN";

                    }
                    else if (radioButton_EN.Checked == true)
                    {
                        lib.VarHelper.Var.Language = 1;
                        SetLanguage = "EN";
                    }
                    else if (radioButton_JP.Checked == true)
                    {
                        lib.VarHelper.Var.Language = 2;
                        SetLanguage = "Jpn";
                    }
                    else if (radioButton_KR.Checked == true)
                    {
                        lib.VarHelper.Var.Language = 3;
                        SetLanguage = "Kro";
                    }
                    else
                    {
                        lib.VarHelper.Var.Language = 0;
                        SetLanguage = "CN";
                    }
                    int _Language = lib.VarHelper.Var.Language;
                    lib.JsonHelper.MergeJson(SettingFile, new { Language = _Language });

                    // MessageBox.Show("选择的语言：" + lib.VarHelper.Var.Out_Language);
                    lib.VarHelper.Var.Audio_Name = lib.VarHelper.Var.Video_Name + "_" + lib.VarHelper.Var.Language + ".wav";
                    string playName = $"{lib.VarHelper.Var.Output_path}\\{lib.VarHelper.Var.Video_Name}\\{lib.VarHelper.Var.Video_Name}_{SetLanguage}.mkv";
                    //string demuxUsm = " demuxUsm " + "\"" + lib.VarHelper.Var.USM_Files + "\"" + " -o " + lib.VarHelper.Var.Output_path + "\\" + lib.VarHelper.Var.Video_Name;
                    //string mpegcommand = " -i " + lib.VarHelper.Var.Output_path + "\\" + lib.VarHelper.Var.Video_Name + "\\" + lib.VarHelper.Var.Video_Name + ".ivf" + " -i " + lib.VarHelper.Var.Output_path + "\\" + lib.VarHelper.Var.Video_Name + "\\" + lib.VarHelper.Var.Audio_Name + " -c:v copy -c:a copy " + lib.VarHelper.Var.Output_path + "\\" + lib.VarHelper.Var.Video_Name + "\\" + lib.VarHelper.Var.Video_Name + "_" + SetLanguage + ".mkv";
                    string demuxUsm = $"demuxUsm \"{lib.VarHelper.Var.USM_Files}\" -o {lib.VarHelper.Var.Output_path}\\{lib.VarHelper.Var.Video_Name}";

                    string mpegcommand = $"-i {lib.VarHelper.Var.Output_path}\\{lib.VarHelper.Var.Video_Name}\\{lib.VarHelper.Var.Video_Name}.ivf -i {lib.VarHelper.Var.Output_path}\\{lib.VarHelper.Var.Video_Name}\\{lib.VarHelper.Var.Audio_Name} -c:v copy -c:a copy {lib.VarHelper.Var.Output_path}\\{lib.VarHelper.Var.Video_Name}\\{lib.VarHelper.Var.Video_Name}_{SetLanguage}.mkv";
                    try
                    {
                        // 异步执行命令并实时输出
                        await lib.CommandHelper.ExecuteGutscenesAsync(demuxUsm.Trim(), output =>
                            {
                                // 跨线程更新UI
                                this.Invoke((Action)(() =>
                                {
                                    memoEdit_out.AppendText(output + Environment.NewLine);
                                    ScrollToEnd(memoEdit_out);
                                }));
                            },
                            error =>
                            {
                                // 跨线程更新UI
                                this.Invoke((Action)(() =>
                                {
                                    memoEdit_out.AppendText($"{error}" + Environment.NewLine);
                                    ScrollToEnd(memoEdit_out);
                                }));
                            });

                    }
                    catch (Exception)
                    {
                        ScrollToEnd(memoEdit_out);
                    }
                    finally
                    {
                        // 显示完成消息
                        memoEdit_out.AppendText("\n[提取完成]\n");
                        ScrollToEnd(memoEdit_out);
                    }
                    try
                    {
                        // 异步执行命令并实时输出
                        await lib.CommandHelper.ExecuteFFmpegAsync(mpegcommand.Trim(), output =>
                            {
                                // 跨线程更新UI
                                this.Invoke((Action)(() =>
                                {
                                    memoEdit_out.AppendText(output + Environment.NewLine);
                                    ScrollToEnd(memoEdit_out);
                                }));
                            },
                            error =>
                            {
                                // 跨线程更新UI
                                this.Invoke((Action)(() =>
                                {
                                    memoEdit_out.AppendText($"{error}" + Environment.NewLine);
                                    ScrollToEnd(memoEdit_out);
                                }));
                            });

                    }
                    catch (Exception)
                    {
                        ScrollToEnd(memoEdit_out);
                    }
                    finally
                    {
                        // 显示完成消息
                        memoEdit_out.AppendText("\n[合并完成]\n");
                        ScrollToEnd(memoEdit_out);
                        // 重新启用按钮
                        simpleButton_Out.Enabled = true;
                    }
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(lib.VarHelper.Var.Output_path + "\\" + lib.VarHelper.Var.Video_Name);
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
                            XtraMessageBox.Show("导出完成！\n点击确定预览视频！", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start("explorer.exe", lib.VarHelper.Var.Output_path + @"\" + lib.VarHelper.Var.Video_Name);
                            //完成
                            lib.VarHelper.Var.Command_Play = Application.StartupPath + @"\data\ffplay.exe";
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = lib.VarHelper.Var.Command_Play;
                            startInfo.Arguments = $"-autoexit {playName}"; // -autoexit播放完成后自动退出
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
                        //XtraMessageBox.Show("删除失败", lib.VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        //滚动到最后
        private void ScrollToEnd(MemoEdit memoEdit_out)
        {
            if (memoEdit_out.InvokeRequired)
            {
                memoEdit_out.Invoke(new Action<MemoEdit>(ScrollMemoToEnd), memoEdit_out);
                return;
            }
            memoEdit_out.SelectionStart = memoEdit_out.SelectionLength;
            memoEdit_out.ScrollToCaret();
        }

        private void simpleButton_Stop_Click(object sender, EventArgs e)
        {
            string processName = "GICutscenes"; // 查找的程序进程名称
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                process.Kill();
            }
            Thread.Sleep(1000);
            try
            {
                DirectoryInfo di = new DirectoryInfo(lib.VarHelper.Var.Output_path);
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
                }

            }
            catch
            {
                //XtraMessageBox.Show("删除失败", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
