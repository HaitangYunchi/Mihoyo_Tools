using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Diagnostics;
using DevExpress.XtraEditors;

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
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名大于一个，则说明在此之前已经启动过
            {
                XtraMessageBox.Show("程序已经运行！");
                Process.GetCurrentProcess().Kill();             //关闭
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new fr_Main());
            }

        }
    }
}