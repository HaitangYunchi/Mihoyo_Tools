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
using System.Net;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Diagnostics;
using System.IO;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System.Threading;
using System.Management;
using Timer = System.Windows.Forms.Timer;
using SharpDX.DXGI;
using Microsoft.Win32;
using HaiTangUpdate;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Mihoyo_Tools
{
    public partial class Control_About : DevExpress.XtraEditors.XtraUserControl
    {
        HaiTangUpdate.Update up = new HaiTangUpdate.Update();

        private readonly PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private readonly Timer updateTimer = new Timer();
        private WebClient client;
        public Control_About()
        {
            InitializeComponent();
            InitializeHardwareInfo();
            SetupTimer();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/3493128132626725");
        }

        private void hyperlinkLabelControl2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://qm.qq.com/q/JXvmG0lyGQ");
        }

        private void hyperlinkLabelControl3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:haitangyunchi@126.com");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string url = "";
            progressBar1.Value = 0;
            if (radioButton_gitee.Checked == true)
            {
                url = "https://gitee.com/haitangyunchi/Mihoyo_Tools/raw/master/Mihoyo_Tools/data/versions.json";
            }
            else if (radioButto_github.Checked == true)
            {
                url = "https://raw.githubusercontent.com/HaitangYunchi/Mihoyo_Tools/master/Mihoyo_Tools/data/versions.json";
            }
            else
            {
                url = "https://gitee.com/haitangyunchi/Mihoyo_Tools/raw/master/Mihoyo_Tools/data/versions.json";
            }
            string savePath = Application.StartupPath + @"\data\versions.json"; // 替换为实际保存路径

            client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(url), savePath);
        }

        void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int progress = (int)(e.ProgressPercentage);
            this.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = progress;
            });
        }

        void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string path = GlobalVar.StrPath + @"\data\versions.json";
            string SaveFilesName = GlobalVar.StrPath + @"\data\versions.json.back";
            this.Invoke((MethodInvoker)delegate
            {
                if (e.Error != null)
                {
                    
                    if (System.IO.File.Exists(SaveFilesName))
                    {
                        System.IO.File.Copy(SaveFilesName, path, true);
                        progressBar1.Value = 100;
                        XtraMessageBox.Show("错误:\n\n无法访问更新服务器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else if (e.Cancelled)
                {
                    if (System.IO.File.Exists(SaveFilesName))
                    {
                        System.IO.File.Copy(SaveFilesName, path, true);
                        progressBar1.Value = 100;
                        XtraMessageBox.Show("更新被取消", "取消", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    
                }
                else
                {
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Copy(path, SaveFilesName, true);
                    }
                    string CloudVariables = up.GetUpdateCloudVariables(GlobalVar.id, GlobalVar.key);
                    JArray jsonArray = JArray.Parse(CloudVariables);// 动态解析JSON
                    List<KeyValuePair<string, string>> configList = new List<KeyValuePair<string, string>>();

                    foreach (JObject item in jsonArray)
                    {
                        string CloudKey = item["key"].ToString();
                        string CloudValue = item["value"].ToString();
                        configList.Add(new KeyValuePair<string, string>(CloudKey, CloudValue));
                    }
                    var _UsmKey = configList.FirstOrDefault(p => p.Key == "UpdateUsmKeyVer");
                    if (_UsmKey.Value != null)
                    {
                        INIFile.writeString("Ver", "version", _UsmKey.Value, GlobalVar.UsmVer);
                        XtraMessageBox.Show("已更新 Key 到最新版", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        return;
                    }
                }
                //progressBar1.Value = 0;
            });
        }

        private void hyperlinkLabelControl_ToaHartor_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ToaHartor/GI-cutscenes");
        }

        private void hyperlinkLabelControl_orilights_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/orilights/hoyo-files");
        }

        private void hyperlinkLabelControl_DevExpress_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.devexpress.com");
        }

        private void InitializeHardwareInfo()
        {
            // CPU 信息
            GetCpuInfo();
            // 内存信息
            GetMemoryInfo();
            // 显卡信息
            GetGpuInfo();
            GetSystemSummary();
        }

        private void GetCpuInfo()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    lblCpuName.Text = $"CPU型号: {obj["Name"]}";
                    double currentGHz = Convert.ToDouble(obj["CurrentClockSpeed"]) / 1000;
                    lblCpuSpeed.Text = $"基本频率: {currentGHz:F2} GHz";

                    // 获取并转换L2缓存
                    uint l2KB = obj["L2CacheSize"] != null ? Convert.ToUInt32(obj["L2CacheSize"]) : 0;
                    string l2Display = l2KB > 0 ? $"{l2KB / 1024.0:F1} MB" : "未启用";

                    // 获取并转换L3缓存
                    uint l3KB = obj["L3CacheSize"] != null ? Convert.ToUInt32(obj["L3CacheSize"]) : 0;
                    string l3Display = l3KB > 0 ? $"{l3KB / 1024.0:F1} MB" : "未启用";

                    lblCpuCache.Text = $"L2缓存: {l2Display} | L3缓存: {l3Display}";
                }
            }
        }

        private void GetMemoryInfo()
        {
            ulong totalMemory = 0;
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    totalMemory += Convert.ToUInt64(obj["Capacity"]);
                    lblMemSpeed.Text = $"内存频率: {obj["Speed"]} MHz";

                    // 添加内存品牌转换逻辑
                    string manufacturerCode = obj["Manufacturer"]?.ToString() ?? "";
                    //lblMemBrand.Text = $"内存品牌: {TranslateMemoryBrand(manufacturerCode)}";
                }
            }
            lblMemSize.Text = $"系统总内存: {totalMemory / (1024 * 1024 * 1024)} GB";
            UpdateMemoryUsage();
        }

        // 内存品牌编码转换字典
        private static readonly Dictionary<string, string> MemoryBrandMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
{
            // 主要DRAM制造商（JEDEC标准编码）
            {"0198", "Micron"},
            {"029E", "Samsung"},
            {"04CD", "SK Hynix"},
            {"04CB", "Elpida"},
            {"8541", "Nanya"},
            {"AD00", "Hynix (旧编码)"},
            {"AD80", "Hynix"},
            {"2C00", "Corsair"},
            {"7F7F", "Kingston (OEM)"},
            {"04C5", "Ramaxel"},
            {"859B", "Team Group"},
            {"9E9E", "ADATA"},
            {"04D4", "Smart Modular"},
            {"04C3", "Powerchip"},

            // 模块制造商（自定义编码）
            {"7F7F7F7F7F7F0000", "G.Skill"},
            {"534D", "SMART"},
            {"4D48", "Mushkin"},
            {"4850", "HP"},
            {"4445", "Dell"},
            {"4C45", "Lenovo"},
            {"5645", "V-Color"},
            {"4F43", "OCZ"},
            {"4742", "GeIL"},
            {"4241", "Ballistix"},
            {"4B56", "Klevv"},
            {"5451", "T-Force"},
            {"4743", "Galaxy"},

            // 中国品牌
            {"04C9", "Tigo"},
            {"04C7", "Biostar"},
            {"04C8", "Asgard"},
            {"04C6", "Gloway"},
            {"04CA", "Colorful"},
    
            // 特殊编码
            {"0000", "Generic"},
            {"FFFF", "Unbuffered"},
            {"AAAA", "Test Pattern"}
            //{"AAAA", "Test Pattern"}
};

        private string TranslateMemoryBrand(string code)
        {
            // 处理空值
            if (string.IsNullOrWhiteSpace(code)) return "未知品牌";

            // 尝试完整匹配
            if (MemoryBrandMap.TryGetValue(code, out var brand))
                return brand;

            // 尝试部分匹配（有些代码可能带前缀）
            foreach (var pair in MemoryBrandMap)
            {
                if (code.StartsWith(pair.Key, StringComparison.OrdinalIgnoreCase))
                    return pair.Value;
            }



            return $"未知品牌 ({code})";
        }

        private void GetGpuInfo()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    lblGpuBrand.Text = $"显卡品牌: {obj["AdapterCompatibility"]}";
                    lblGpuName.Text = $"显卡型号: {obj["Name"]}";
                    //lblGpuMemory.Text = $"显存大小: {Convert.ToUInt64(obj["AdapterRAM"]) / (1024 * 1024)} MB";
                    lblGpuMemory.Text = $"显存大小:"+GetActualVRAM();
                    
                }
            }
        }
        public static string GetActualVRAM()
        {
            try
            {
                using (var factory = new Factory1())
                {
                    foreach (var adapter in factory.Adapters)
                    {
                        if (adapter.GetOutputCount() == 0) continue;
                        double vramGB = adapter.Description.DedicatedVideoMemory / 1024.0 / 1024 / 1024;
                        return $"{vramGB:F2} GB (通过DirectX检测)";
                    }
                }
            }
            catch { /* 忽略错误 */ }
            return "无法通过DirectX获取显存";
        }
      
        private void SetupTimer()
        {
            updateTimer.Interval = 1000;
            updateTimer.Tick += (s, e) => UpdateDynamicInfo();
            updateTimer.Start();
        }

        private void UpdateDynamicInfo()
        {
            // CPU使用率
            lblCpuUsage.Text = $"CPU使用率: {cpuCounter.NextValue().ToString("0.00")}%";

            // 更新内存使用率
            UpdateMemoryUsage();
        }

        private void UpdateMemoryUsage()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    var total = Convert.ToUInt64(obj["TotalVisibleMemorySize"]);
                    var free = Convert.ToUInt64(obj["FreePhysicalMemory"]);
                    var used = total - free;
                    var usagePercentage = (used * 100) / (double)total;
                    lblMemUsage.Text = $"内存使用率: {usagePercentage.ToString("0.00")}%";
                }
            }
        }

        private void GetSystemSummary()
        {
            // 操作系统信息
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    lblOSName.Text = $"操作系统: {obj["Caption"]}";
                    lblOSVersion.Text = $"系统版本: {obj["Version"]}";
                }
            }

            // 系统型号
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    lblSystemModel.Text = $"主板型号: {obj["Name"]}";
                    lblUUID.Text = $"系统UUID: {obj["UUID"]}";
                }
            }

            // BIOS信息
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    lblBIOSVersion.Text = $"BIOS版本: {obj["SMBIOSBIOSVersion"]}";
                    lblBIOSDate.Text = $"发布日期: {obj["ReleaseDate"]?.ToString().Substring(0, 8)}";
                }
            }
        }

        private void ChecUpde_Click(object sender, EventArgs e)
        {
            backgroundWorker_ChecUpde.RunWorkerAsync();   
        }

        private void backgroundWorker_ChecUpde_DoWork(object sender, DoWorkEventArgs e)
        {
            string DowwnloadLink = up.GetUpdateDownloadLink(GlobalVar.id, GlobalVar.key);
            Version UpdateVer = new Version(up.GetUpdateVersionNumber(GlobalVar.id, GlobalVar.key));
            Version loaclVer = new Version(GlobalVar.VerContrast);
            if (UpdateVer > loaclVer)
            {
                DialogResult result = XtraMessageBox.Show(up.GetUpdateVersionInformation(GlobalVar.id, GlobalVar.key), "发现新版本", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                // 判断用户的点击结果
                if (result == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(DowwnloadLink);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }

            }
            else
            {
                DialogResult result = XtraMessageBox.Show("当前版本已是最新版", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void backgroundWorker_ChecUpde_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (e.Error != null)
                {
                    XtraMessageBox.Show("网络不可用，请检查网络后重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (e.Cancelled)
                {
                    XtraMessageBox.Show("用户已取消", "取消", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    return;
                }

            });
        }
    }
}
