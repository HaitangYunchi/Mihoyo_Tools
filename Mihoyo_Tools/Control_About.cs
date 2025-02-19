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

namespace Mihoyo_Tools
{
    public partial class Control_About : DevExpress.XtraEditors.XtraUserControl
    {
        private WebClient client;
        public Control_About()
        {
            InitializeComponent();
            
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
            this.Invoke((MethodInvoker)delegate
            {
                if (e.Error != null)
                {
                    XtraMessageBox.Show("错误:\n\n" + e.Error.Message);
                }
                else if (e.Cancelled)
                {
                    XtraMessageBox.Show("更新被取消");
                }
                else
                {
                    XtraMessageBox.Show("已更新 Key 到最新版");
                }
                //progressBar1.Value = 0;
            });
        }

        
    }
}
