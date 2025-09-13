using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using HaiTangUpdate;
using Mihoyo_Tools.lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mihoyo_Tools {
    static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
        [STAThread]
        static void Main() {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI");
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("Mihoyo_Tools");

            if (myProcesses.Length > 1) //如果可以获取到的进程名大于一个，则说明在此之前已经启动过
            {
                XtraMessageBox.Show("程序已经运行！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Process.GetCurrentProcess().Kill();             //关闭
            }
            else
            {
                Logger.Log("应用程序启动", Logger.LogLevel.INFO);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);              
                Application.Run(new fr_Main());
            }
        }
       
    }
}