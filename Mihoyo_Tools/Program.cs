using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace Mihoyo_Tools {
    static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
        [STAThread]
        static void Main() {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fr_Main());
        }
    }
}