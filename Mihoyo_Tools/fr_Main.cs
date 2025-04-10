using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using DevExpress.CodeParser;
using System.Net;
using System.Windows.Input;
using System.Threading;
using System.Globalization;
using System.Security.Policy;
using Mihoyo_Tools.lib;

namespace Mihoyo_Tools {
    public partial class fr_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private const string TempUpdateFolder = "TempUpdate";
        HaiTangUpdate.Update up = new();
        string SettingFile = VarHelper.Var.Setting;
        string id = VarHelper.Var.id;
        string key = VarHelper.Var.key;
        public fr_Main()
        {
            InitializeComponent();
            Check_SettingFile();


        }
        private async void Check_SettingFile()
        {
            string SettingFile = VarHelper.Var.Setting;
            bool exists = await Task.Run(() => File.Exists(SettingFile));
            if (File.Exists(SettingFile) == true)
            {
                return;
            }
            else
            {
                // 创建数据并写入文件
                var JsonData = new JsonHelper.JsonData
                {
                    UsmKey = VarHelper.Var.usmkey,
                    GICutscennts_path = VarHelper.Var.GICutscents_path,
                    FFmpeg_path = VarHelper.Var.Ffmpeg_path,
                    Output_path = VarHelper.Var.Output_path,
                    Games_path = VarHelper.Var.Games_path,
                    USM_path = VarHelper.Var.USM_path,
                    Language = VarHelper.Var.Language
                };

                JsonHelper.WriteJson(SettingFile, JsonData);
            }
        }
        public void _home()
        {
            Home _home;
            _home = new Home();
            _home.Dock = DockStyle.Fill;
            fr_Main_Container.Controls.Clear();
            _home.Show();
            fr_Main_Container.Controls.Add(_home);
        }
        public void GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            //获取程序集版本
            Version version = assembly.GetName().Version;
            string time1 = lib.DateHelper.ChinaDate.GetChinaDate(DateTime.Now);
            //XtraMessageBox.Show($"程序集版本：{version.ToString()}\n{time1}");
            XtraMessageBox.Show($"项目运行目录：{VarHelper.Var.StrPath}");

        }

        private async void fr_Main_Shown(object sender, EventArgs e)
        {
            var ipService = new IpApiService();

            try
            {
                var currentIpInfo = await ipService.GetIpDetailsAsync();
                await up.MessageSend(id, currentIpInfo.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n错误: {ex.Message}");
                Console.WriteLine(ex.GetType().Name);

                // 如果是 HttpClient 异常，可访问内部异常详情
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"内部错误: {ex.InnerException.Message}");
                }
            }

        }

        private async void fr_Main_Load(object sender, EventArgs e)
        {

            _home();
            Assembly assembly = typeof(Program).Assembly;
            AssemblyName name = new AssemblyName(assembly.FullName);
            int majorVersion = (int)name.Version.Major;
            int minorVersion = (int)name.Version.Minor;

            //根据VarHelper.Var对应变量值，修改显示版本信息；如需修改，请打开VarHelper.Var.cs文件，修改 Release 的值，注意类型是int;//  0  Alpha 内测版      1  bate 公测版      2  Release 正式版
            if (VarHelper.Var.Release == 0)
            {
                //toolStripStatusLabel4.Text = "    版本：" + VarHelper.Var.VersionNo + "_Alpha（内测版）";
                barStaticItem_Ver.Caption = "    版本：" + VarHelper.Var.VersionNo + "_Alpha（内测版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo;
            }
            else if (VarHelper.Var.Release == 1)
            {
                //toolStripStatusLabel4.Text = "    版本：" + VarHelper.Var.VersionNo + "_bate（公测版）";
                barStaticItem_Ver.Caption = "    版本：" + VarHelper.Var.VersionNo + "_bate（公测版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo;
            }
            else if (VarHelper.Var.Release == 2)
            {
                //toolStripStatusLabel4.Text = "    版本：" + $"{majorVersion}." + $"{minorVersion}" + "_Release（正式版）";
                barStaticItem_Ver.Caption = "    版本：" + $"{majorVersion}." + $"{minorVersion}" + "_Release（正式版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo;
            }
            else
            {
                //toolStripStatusLabel4.Text = "    版本：" + VarHelper.Var.VersionNo + "_Alpha（内测版）";
                barStaticItem_Ver.Caption = "    版本：" + VarHelper.Var.VersionNo + "_Alpha（内测版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo + "_Alpha（内测版）";
            }

            await CheckNumberOfVisits(true);

            string VersionFile = VarHelper.Var.VersionPath;
            string Jsonback = VarHelper.Var.StrPath + @"\data\versions.json.back";// 新增备份老 version.json
            if (System.IO.File.Exists(VersionFile))//检查文件是否存在 true = 存在 flase = 不存在
            {
                if (!System.IO.File.Exists(Jsonback))
                {
                    System.IO.File.Copy(VersionFile, Jsonback, true);// 备份老 version.json
                }
                else
                {
                    return;
                }

            }
        }
        private async Task CheckNumberOfVisits(bool silent = false)//检查versions.json文件是否有更新
        {
            try
            {
                string _Number = await Task.Run(() => up.GetUpdateNumberOfVisits(id, key));
                int NumberOfVisits = int.Parse(_Number);
                Soft_Number.Caption = $"  软件访问次数： {NumberOfVisits} （非实时数据） ";
            }
            catch (Exception)
            {

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            string[] Day = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
            var week = Day[Convert.ToInt16(Now.DayOfWeek)];
            barStaticItem_Time.Caption = $" 当前时间：{Now:yyyy-MM-dd HH:mm:ss}  {week}   " + DateHelper.ChinaDate.GetChinaDate(Now) + "      ";
        }
        private void Home_Click(object sender, EventArgs e)
        {
            Home _home;
            _home = new Home();
            _home.Dock = DockStyle.Fill;
            fr_Main_Container.Controls.Clear();
            _home.Show();
            fr_Main_Container.Controls.Add(_home);
        }

        private void fr_Main_FormClosed(object sender, FormClosedEventArgs e)
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
                DirectoryInfo di = new DirectoryInfo(VarHelper.Var.Output_path);
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
                //XtraMessageBox.Show("删除失败", VarHelper.Var.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Process.GetCurrentProcess().Kill();
        }

        private void Genshin_tools_Click(object sender, EventArgs e)
        {
            Genshin_usm _genshinusm;
            _genshinusm = new Genshin_usm
            {
                Dock = DockStyle.Fill
            };
            fr_Main_Container.Controls.Clear();
            _genshinusm.Show();
            fr_Main_Container.Controls.Add(_genshinusm);

        }

        private void Lrc_srt_Click(object sender, EventArgs e)
        {
            Lrc_srt _Lrc_srt;
            _Lrc_srt = new Lrc_srt
            {
                Dock = DockStyle.Fill
            };
            fr_Main_Container.Controls.Clear();
            _Lrc_srt.Show();
            fr_Main_Container.Controls.Add(_Lrc_srt);
        }

        private void Soft_Rex_Click(object sender, EventArgs e)
        {
            Web_Browser _Web_Browser;
            _Web_Browser = new Web_Browser
            {
                Dock = DockStyle.Fill
            };
            fr_Main_Container.Controls.Clear();
            _Web_Browser.Show();
            fr_Main_Container.Controls.Add(_Web_Browser);
        }

        private void barStaticItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            string url = "http://space.bilibili.com/3493128132626725";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void barStaticItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            string url = "http://gitee.com/haitangyunchi/mihoyo_tools";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
