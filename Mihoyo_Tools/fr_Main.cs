using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
            // 获取农历日期信息
            int leapMonth = ChineseCalendar.GetLeapMonth(now.Year);
            string date = string.Format("农历  {0}{1}（{2}）年  {3}{4}月{5}{6}"
             , "甲乙丙丁戊己庚辛壬癸"[(now.Year - 4) % 10]
             , "子丑寅卯辰巳午未申酉戌亥"[(now.Year - 4) % 12]
             , "鼠牛虎兔龙蛇马羊猴鸡狗猪"[(now.Year - 4) % 12]
            , now.Month == leapMonth ? "闰" : ""
            , "无正二三四五六七八九十冬腊"[leapMonth > 0 && leapMonth <= now.Month ? now.Month - 1 : now.Month]
            , "初十廿三"[now.Day / 10]
            , "十一二三四五六七八九"[now.Day % 10]);
            toolStripStatusLabel3.Text = $" 当前时间：{now:yyyy-MM-dd HH:mm:ss}  {week}  {date}";
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/3493128132626725");//海棠云螭的B站
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HaitangYunchi/Mihoyo_Tools");
        }
    }
}
