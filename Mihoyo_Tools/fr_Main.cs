using DevExpress.CodeParser;
using DevExpress.DataAccess.Native.Web;
using DevExpress.Internal;
using DevExpress.Map.Kml.Model;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Json.Path;
using Mihoyo_Tools.lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static Mihoyo_Tools.lib.JsonHelper;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using File = System.IO.File;


namespace Mihoyo_Tools {
    public partial class fr_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private const string TempUpdateFolder = "TempUpdate";
        HaiTangUpdate.Update up = new();
        string SettingFile = VarHelper.Var.Setting;
        string SoftJsonFiles = VarHelper.Var.SoftJson;
        string id = VarHelper.Var.id;
        string key = VarHelper.Var.key;
        string _activestate;
        public fr_Main()
        {
            InitializeComponent();
            Check_SettingFile();
            Check_FFMpegChanger();
        }
        private async void Check_SettingFile()
        {
            string Code = up.GetMachineCode();
            var timestamp = await up.GetRemainingUsageTime(id, key, Code);
            string _time;
            if (timestamp == -1)
            {
                _time = $"永久";
            }
            else if (timestamp == 0)
            {
                _time = $"已过期";
            }
            else if (timestamp == 1)
            {
                _time = $"未激活";
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(timestamp);

                int days = timeSpan.Days;
                int hours = timeSpan.Hours;
                int minutes = timeSpan.Minutes;
                int seconds = timeSpan.Seconds;

                _time = $"剩余时间：{days}天{hours}小时{minutes}分钟{seconds}秒";
            }
            try
            {
                string _isItEffective;
                string _mandatoryUpdate;
                var _softInfoJson = await up.GetUpdate(id, key, Code);
                var soft = JsonConvert.DeserializeObject<SoftInfo>(_softInfoJson);
                if (soft.isItEffective == "y")
                {
                    _isItEffective = "True";
                }
                else
                {
                    _isItEffective = "False";
                }
                if(soft.mandatoryUpdate == "y")
                {
                    _mandatoryUpdate = "True";
                }
                else
                {
                    _mandatoryUpdate = "False";
                }
                    var softInfo = new JsonHelper.SoftInfo
                    {
                        author = "海棠云螭",
                        mandatoryUpdate = _mandatoryUpdate,
                        softwareMd5 = soft.softwareMd5,
                        softwareName = soft.softwareName,
                        usmkeyInfo = soft.notice,
                        downloadLink = "https://www.123912.com/s/b6X3jv-wNtU3",
                        versionInformation = soft.versionInformation,
                        versionNumber = soft.versionNumber,
                        numberOfVisits = soft.numberOfVisits,
                        miniVersion = soft.miniVersion,
                        timeStamp = soft.timeStamp,
                        networkVerificationId = soft.networkVerificationId,
                        isItEffective = _isItEffective,
                        numberOfDays = soft.numberOfDays,
                        networkVerificationRemarks = soft.networkVerificationRemarks,
                        expirationDate = _time,
                        bilibiliLink = "https://space.bilibili.com/3493128132626725"
                    };
                JsonHelper.WriteJson(SoftJsonFiles, softInfo);
            }
            catch
            {

            }

            string SettingFile = VarHelper.Var.Setting;
            bool exists = await Task.Run(() => File.Exists(SettingFile));
            if (File.Exists(SettingFile) == true)
            {
                return;
            }
            else
            {
                // 创建数据并写入文件
                var appConfig = new JsonHelper.AppConfig
                {
                    UsmKey = VarHelper.Var.usmkey,
                    GICutscennts_path = VarHelper.Var.GICutscents_path,
                    FFmpeg_path = VarHelper.Var.Ffmpeg_path,
                    Output_path = VarHelper.Var.Output_path,
                    Games_path = VarHelper.Var.Games_path,
                    USM_path = VarHelper.Var.USM_path,
                    Language = VarHelper.Var.Language
                };
                JsonHelper.WriteJson(SettingFile, appConfig);

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
        public async void Check_FFMpegChanger()
        {
            string FFMpegChanger = await up.GetCloudVariables(id,key,"FFMpegChanger");
            string Soft_RexChanger = await up.GetCloudVariables(id, key, "Soft_Rex");
            if (FFMpegChanger == "True")
            {
                Video_size.Visible = true;      //  视频转换页面开关
            }
            else
            {
                Video_size.Visible = false;
            }
            if (Soft_RexChanger == "True")
            {
                Soft_Rex.Visible = true;      //  游戏资源页面开关
            }
            else
            {
                Soft_Rex.Visible = false;
            }
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
                ActiveState();
                var currentIpInfo = await ipService.GetIpDetailsAsync();
                string _Message = $"{currentIpInfo.ToString()}\n机器码： {up.GetMachineCode()}  状态：{_activestate}\n版本号：{VarHelper.Var.VersionNo}";
                await up.MessageSend(id, _Message);

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
        private async void ActiveState()
        {
            string Code = up.GetMachineCode();
            var timestamp = await up.GetRemainingUsageTime(id, key, Code);
            if (timestamp == -1)
            {
                _activestate = $"永久激活";
            }
            else if (timestamp == 0)
            {
                _activestate = $"已过期";
            }
            else if (timestamp == 1)
            {
                _activestate = $"未激活";
            }
            else
            {
                _activestate = $"限时激活";
            }
        }
        private async void fr_Main_Load(object sender, EventArgs e)
        {
            //this.Cursor = new(VarHelper.Var.StrPath + @"Genshin.cur");
            _home();
            Assembly assembly = typeof(Program).Assembly;
            AssemblyName name = new AssemblyName(assembly.FullName);
            int majorVersion = (int)name.Version.Major;
            int minorVersion = (int)name.Version.Minor;

            //根据VarHelper.Var对应变量值，修改显示版本信息；如需修改，请打开VarHelper.Var.cs文件，修改 Release 的值，注意类型是int;//  0  Alpha 内测版      1  bate 公测版      2  Release 正式版
            if (VarHelper.Var.Release == 0)
            {
                barStaticItem_Ver.Caption = $"    版本： {VarHelper.Var.VersionNo}_Alpha（内测版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo;
            }
            else if (VarHelper.Var.Release == 1)
            {
                barStaticItem_Ver.Caption = $"    版本： {VarHelper.Var.VersionNo}_bate（公测版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo;
            }
            else if (VarHelper.Var.Release == 2)
            {
                barStaticItem_Ver.Caption = $"    版本：{majorVersion}.{minorVersion}_Release（正式版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo;
            }
            else
            {
                barStaticItem_Ver.Caption = $"    版本： {VarHelper.Var.VersionNo}_Alpha（内测版）";
                this.Text = VarHelper.Var.SoftTitle + "    版本：" + VarHelper.Var.VersionNo + "_Alpha（内测版）";
            }
            await GetServerData(true);
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
        private async Task GetServerData(bool silent = false)
        {
            string Code = up.GetMachineCode();
            try
            {
                //ActiveState();
                string _Number = await Task.Run(() => up.GetNumberOfVisits(id, key, Code));
                int NumberOfVisits = int.Parse(_Number);
                Soft_Number.Caption = $" 软件访问次数： {NumberOfVisits} （非实时数据）";
                string _SerialNumberID = await Task.Run(() => up.GetNetworkVerificationId(id, key, Code));
                SerialNumberID.Caption = $" 序列号： {_SerialNumberID}  ";
                //SerialNumberID.Caption = $" 序列号： {_SerialNumberID}   ({_activestate})";
            }
            catch (Exception)
            {

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string Code = up.GetMachineCode();
            DateTime Now = DateTime.Now;
            string[] Day = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"];
            var week = Day[Convert.ToInt16(Now.DayOfWeek)];
            //barStaticItem_Time.Caption = $" 当前时间：{Now:yyyy-MM-dd HH:mm:ss}  {week}  " + DateHelper.ChinaDate.GetChinaDate(Now) + "  ";
            barStaticItem_Time.Caption = $" 当前时间：{Now:yyyy-MM-dd HH:mm:ss}  {week}  ";

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
            string processFFmpeg = "ffmpeg"; // 查找的程序进程名称
            Process[] processesffmpeg = Process.GetProcessesByName(processFFmpeg);
            foreach (Process process in processesffmpeg)
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
        private void Video_size_Click(object sender, EventArgs e)
        {
            string ffmpegPath = VarHelper.Var.Ffmpeg_path;
            var ffmpegControl = new FFmpegControl(ffmpegPath);
            ffmpegControl.Dock = DockStyle.Fill;
            fr_Main_Container.Controls.Clear();
            ffmpegControl.Show();
            fr_Main_Container.Controls.Add(ffmpegControl);
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
