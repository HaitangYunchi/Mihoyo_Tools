using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Windows.Forms;

namespace Mihoyo_Tools {
    public partial class fr_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm 
    {
        private Control_Genshin_usm _Genshin_usm;
        private Control_Mihoyo_resources _Mihoyo;
        private Control_About _About;
        public fr_Main() 
        {
            InitializeComponent();
            _Genshin_usm = new Control_Genshin_usm();
            _Genshin_usm.Dock = DockStyle.Fill;
            _Mihoyo = new Control_Mihoyo_resources();
            _Mihoyo.Dock = DockStyle.Fill;
            _About = new Control_About();
            _About.Dock = DockStyle.Fill;
        }

        private void Element_ys_usm_Click(object sender, EventArgs e)
        {
            fr_Main_Container.Controls.Clear();
            _Genshin_usm.Show();
            fr_Main_Container.Controls.Add(_Genshin_usm);
        }

        private void Element_mihoyo_rex_Click(object sender, EventArgs e)
        {
            fr_Main_Container.Controls.Clear();
            _Mihoyo.Show();
            fr_Main_Container.Controls.Add(_Mihoyo);
        }

        private void fr_Main_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel4.Text = GlobalVar.VersionNo;

            Assembly assembly = typeof(Program).Assembly;
            AssemblyName name = new AssemblyName(assembly.FullName);
            int majorVersion = (int)name.Version.Major;
            int minorVersion = (int)name.Version.Minor;

            //根据GlobalVar对应变量值，修改显示版本信息；如需修改，请打开GlobalVar.cs文件，修改 Release 的值，注意类型是int;//  0  Alpha 内测版      1  bate 公测版      2  Release 正式版
            if (GlobalVar.Release == 0)
            {
                toolStripStatusLabel4.Text = "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
            }
            else if (GlobalVar.Release == 1)
            {
                toolStripStatusLabel4.Text = "    版本：" + GlobalVar.VersionNo + "_bate（公测版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + GlobalVar.VersionNo + "_bate（公测版）";
            }
            else if (GlobalVar.Release == 2)
            {
                toolStripStatusLabel4.Text = "    版本：" + $"{majorVersion}." + $"{minorVersion}" + "_Release（正式版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + $"{majorVersion}." + $"{minorVersion}" + "_Release（正式版）";
            }
            else
            {
                toolStripStatusLabel4.Text = "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
            }

            fr_Main_Container.Controls.Clear();
            _About.Show();
            fr_Main_Container.Controls.Add(_About);
        }

        private void Element_guanyu_Click(object sender, EventArgs e)
        {
            fr_Main_Container.Controls.Clear();
            _About.Show();
            fr_Main_Container.Controls.Add(_About);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();
            DateTime now = DateTime.Now;
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            var week = Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
            toolStripStatusLabel3.Text = $" 当前时间：{now:yyyy-MM-dd HH:mm:ss}  {week} ";
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/3493128132626725");//海棠云螭的B站
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HaitangYunchi/Mihoyo_Tools");
        }

        private void fr_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            string processName = "GICutscenes"; // 查找的程序进程名称
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                process.Kill();
            }
            Process.GetCurrentProcess().Kill();
        }
    }
}
