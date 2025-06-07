using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;


namespace upgrade
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                MessageBox.Show("更新程序需要以下参数:\n1. 更新包路径\n2. 主程序路径\n3. 工作目录",
                    "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updatePackagePath = args[0];
            string appPath = args[1];
            string workingDir = args[2];

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 显示简单的更新进度窗口
                var progressForm = new ProgressForm();
                progressForm.Show();
                Application.DoEvents();

                // 解压更新包
                progressForm.UpdateStatus("正在解压更新包...");
                string extractDir = Path.Combine(Path.GetTempPath(), "UpdateExtract");
   
                if (Directory.Exists(extractDir))
                    Directory.Delete(extractDir, true);

                Directory.CreateDirectory(extractDir);
                ZipFile.ExtractToDirectory(updatePackagePath, extractDir);

                // 等待主程序退出
                progressForm.UpdateStatus("等待主程序关闭...");
                string processName = Path.GetFileNameWithoutExtension(appPath);

                // 最多等待10秒
                for (int i = 0; i < 10; i++)
                {
                    if (Process.GetProcessesByName(processName).Length == 0)
                        break;

                    Thread.Sleep(1000);
                }

                // 强制关闭主程序（如果还在运行）
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                    process.WaitForExit(5000);
                }
                //MessageBox.Show($"{extractDir}\n{workingDir}");
                // 复制文件
                progressForm.UpdateStatus("正在应用更新...");
                CopyAllFiles(extractDir, workingDir);
                

                // 清理临时文件
                progressForm.UpdateStatus("正在清理临时文件...");
                Directory.Delete(extractDir, true);
                File.Delete(updatePackagePath);

                // 启动更新后的程序
                progressForm.UpdateStatus("启动新版本...");
                Process.Start("Mihoyo_Tools.exe");

                // 关闭更新程序
                progressForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新过程中出错: {ex.Message}", "更新错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CopyAllFiles(string sourceDir, string targetDir)
        {
            // 复制所有子目录
            foreach (string dirPath in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourceDir, targetDir));
            }

            // 复制所有文件
            foreach (string filePath in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                string destPath = filePath.Replace(sourceDir, targetDir);

                try
                {
                    // 确保目录存在
                    Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                    // 覆盖现有文件
                    File.Copy(filePath, destPath, true);
                    //MessageBox.Show($"源路径: {filePath}, 目标路径: {destPath}");
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"IO异常: {ex.Message}");
                    // 如果文件正在使用，等待后重试
                    Thread.Sleep(1000);
                    File.Copy(filePath, destPath, true);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"权限不足: {ex.Message}");
                }
            }
        }
    }

    // 简单的进度显示窗体
    public class ProgressForm : Form
    {
        private Label statusLabel;

        public ProgressForm()
        {
            this.Text = "正在更新...";
            this.Width = 400;
            this.Height = 150;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;

            statusLabel = new Label
            {
                Text = "正在准备更新...",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10)
            };

            this.Controls.Add(statusLabel);
        }

        public void UpdateStatus(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateStatus), message);
                return;
            }

            statusLabel.Text = message;
            this.Refresh();
        }
    }
}
