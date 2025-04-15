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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using DevExpress.XtraRichEdit.Layout;
using DevExpress.XtraCharts;
using static Mihoyo_Tools.lib.JsonHelper;
using System.Reflection;
using static System.Net.WebRequestMethods;
using DevExpress.XtraEditors.Controls;
using Mihoyo_Tools.lib;

namespace Mihoyo_Tools
{
    public partial class Home : DevExpress.XtraEditors.XtraUserControl
    {
        private const string TempUpdateFolder = "TempUpdate";
        HaiTangUpdate.Update up = new();
        string SettingFile = VarHelper.Var.Setting;
        string userJsonFiles = VarHelper.Var.userJson;
        string id = VarHelper.Var.id;
        string key = VarHelper.Var.key;
        string VersionName = VarHelper.Var.StrPath + @"data\versions.json";
        string Versionback = VarHelper.Var.StrPath + @"data\versions.json.back";
        private readonly string data = Path.Combine(Application.StartupPath, "data");
        private static string BackgroundFolderPath = VarHelper.Var.StrPath + @"background"; // 背景图片文件夹路径

        public bool AllowTransparency { get; private set; }

        public Home()
        {
            InitializeComponent();
            InitializeStaticBackground();
            
            
        }
        private async void InitializeStaticBackground()
        {
            pictureEdit.BackColor = Color.Transparent;
            pictureEdit.Properties.Appearance.BackColor = Color.Transparent;
            pictureEdit.Properties.Appearance.Options.UseBackColor = true;
            pictureEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            // 加载背景图片
            await LoadBackgroundImage();
        }

        private async Task LoadBackgroundImage()
        {
            try
            {
                // 获取文件夹中第一个支持的图片文件
                var imageFile = await Task.Run(() => Directory.GetFiles(BackgroundFolderPath).FirstOrDefault(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase)));

                if (imageFile != null)
                {
                    pictureEdit.Image = Image.FromFile(imageFile);
                }
                else
                {
                    XtraMessageBox.Show("未找到背景图片，请检查文件夹路径");
                }
            }
            catch (DirectoryNotFoundException)
            {
                XtraMessageBox.Show($"背景图片文件夹不存在: {BackgroundFolderPath}");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"加载背景图片时出错: {ex.Message}");
            }
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            string url = "https://space.bilibili.com/3493128132626725";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {
            string url = "https://qm.qq.com/q/JXvmG0lyGQ";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {
            string url = "mailto:haitangyunchi@126.com";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/ToaHartor/GI-cutscenes";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/orilights/hoyo-files";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        private void labelControl10_Click(object sender, EventArgs e)
        {
            string url = "https://www.devexpress.com";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        private void labelControl11_Click(object sender, EventArgs e)
        {
            string url = "https://www.pixiv.net/users/17156250";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            await CheckVersionUpdate();

        }
        private async Task CheckVersionUpdate(bool silent = false)//检查versions.json文件是否有更新
        {
            var JsonData = new JsonHelper.AppConfig();
            try
            {
                // 确保data目录存在
                if (!Directory.Exists(data))
                {
                    Directory.CreateDirectory(data);
                }

                // 获取当前本地版本
                Version localVersion = new(JsonHelper.ReadJson(SettingFile, JsonData).UsmKey); // 当前usm版本

                // 获取服务器版本
                Version lastVersion = new(await Task.Run(() => up.GetCloudVariables(id, key, "UsmKeyVer")));

                if (lastVersion > localVersion)
                {
                    var result = XtraMessageBox.Show($"服务端有新的 Key，请更新 Key", "发现新版本", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        Update_Key.Position = 0;
                        await DownloadVersion();
                    }
                    
                }
                else if(!silent)
                {
                    MessageBox.Show("当前已是最新 Key", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"更新失败: 无法访问服务器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task DownloadVersion()
        {
            try
            {
                string downloadUrl = await Task.Run(() => up.GetCloudVariables(id, key, "VersionsPath"));
                string fileName = Path.GetFileName(downloadUrl);
                Debug.WriteLine(fileName);
                VersionName = Path.Combine(data, fileName);

                using WebClient client = new();
                client.DownloadProgressChanged += (s, e) =>
                {
                    Update_Key.Position = e.ProgressPercentage;
                    //labelStatus.Text = $"下载中: {e.ProgressPercentage}%";
                };

                await client.DownloadFileTaskAsync(new Uri(downloadUrl), VersionName);

                // 更新本地版本号
                string lastUsmKeyVersion = await Task.Run(() => up.GetCloudVariables(id, key, "UpdateUsmKeyVer"));
                if (lastUsmKeyVersion != null)
                {
                    JsonHelper.MergeJson(SettingFile, new { UsmKey = lastUsmKeyVersion });
                    string VersionFile = VarHelper.Var.VersionPath;
                    string Jsonback = VarHelper.Var.StrPath + @"\data\versions.json.back";// 新增备份老 version.json
                    if (System.IO.File.Exists(VersionFile))//检查文件是否存在 true = 存在 flase = 不存在
                    {
                        System.IO.File.Copy(VersionFile, Jsonback, true);// 备份老 version.json
                    }
                    XtraMessageBox.Show("已更新 Key 到最新版", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                string VersionFile = VarHelper.Var.VersionPath;
                string Jsonback = VarHelper.Var.StrPath + @"\data\versions.json.back";
                if (System.IO.File.Exists(Jsonback))
                {
                    System.IO.File.Copy(Jsonback, VersionFile, true);// 更新失败回滚 version.json
                }
                MessageBox.Show($"更新失败: 无法访问服务器！\n                 请检查网络是否畅通。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //progressBar1.Visible = false;
                //labelStatus.Visible = false;
            }
        }

        private async void Check_update_Click(object sender, EventArgs e)
        {
            await CheckForUpdatesAsync();
        }
        // 检查更新（异步）
        public async Task CheckForUpdatesAsync(bool silent = false)
        {
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            try
            {
                // 获取服务器版本信息
                string serverVersion = await Task.Run(() => up.GetVersionNumber(id, key));

                // 获取当前程序版本
                Version localVersion = assembly.GetName().Version;
                Version latestVersion = new(serverVersion);

                if (latestVersion > localVersion)
                {
                    // 获取下载链接
                    string downloadUrl = await Task.Run(() => up.GetDownloadLink(id, key));
                    string verInfo = await Task.Run(() => up.GetVersionInformation(id, key));
                    //string downloadUrl = "http://172.16.227.100:8080/updata/updata.zip";

                    // 显示更新对话框
                    var result = XtraMessageBox.Show($"发现新版: {serverVersion} 是否立即更新？\n\n当前版本: {localVersion}\n\n\n更新内容：\n\n{verInfo}", 
                        "发现新版本", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        Update_Key.Position = 0;
                        await DownloadAndUpdateAsync(downloadUrl);
                    }
                }
                else if (!silent)
                {
                    XtraMessageBox.Show("当前已是最新版本。", "更新检查", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CheckVersionUpdate();
                }
                await CheckVersionUpdate(true);
            }
            catch (Exception)
            {
                if (!silent)
                {
                    XtraMessageBox.Show($"检查更新时出错:无法访问服务器！", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 下载并执行更新
        private async Task DownloadAndUpdateAsync(string downloadUrl)
        {
            try
            {
                string fileName = Path.GetFileName(new Uri(downloadUrl).LocalPath);
                string tempDir = Path.Combine(Path.GetTempPath(), TempUpdateFolder);

                // 创建临时目录
                if (!Directory.Exists(tempDir))
                    Directory.CreateDirectory(tempDir);

                string tempFile = Path.Combine(tempDir, fileName);

                // 使用WebClient下载文件（支持进度报告）
                using WebClient client = new();
                // 进度更新事件
                client.DownloadProgressChanged += (s, e) =>
                {
                    Update_Key.Position = e.ProgressPercentage;
                };

                // 创建TaskCompletionSource用于await
                var tcs = new TaskCompletionSource<bool>();

                client.DownloadFileCompleted += (s, e) =>
                {
                    if (e.Error != null)
                    {
                        tcs.SetException(e.Error);
                        return;
                    }
                    tcs.SetResult(true);
                };

                // 开始下载
                client.DownloadFileAsync(new Uri(downloadUrl), tempFile);

                // 等待下载完成
                await tcs.Task;

                // 下载完成后启动更新程序
                StartUpdateProcess(tempFile);
            }
            catch (Exception)
            {
                XtraMessageBox.Show($"下载更新失败: 网络错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 启动更新程序
        private void StartUpdateProcess(string updatePackagePath)
        {
            try
            {
                string currentExePath = Assembly.GetExecutingAssembly().Location;
                string updaterExePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Update.exe");

                // 检查更新程序是否存在
                if (!System.IO.File.Exists(updaterExePath))
                {
                    XtraMessageBox.Show("更新程序 Update.exe 未找到。", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 启动更新程序并传递参数
                Process.Start(updaterExePath, $"\"{updatePackagePath}\" \"{currentExePath}\" {AppDomain.CurrentDomain.BaseDirectory}");

                // 退出当前应用程序
                Application.Exit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"启动更新程序失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            await CheckForUpdatesAsync(true);
        }
    }
}
