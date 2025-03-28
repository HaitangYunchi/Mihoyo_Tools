﻿using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UpdateHaiTang;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mihoyo_Tools {
    public partial class fr_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm 
    {
        UpdateHaiTang.Update up = new UpdateHaiTang.Update();
        // private WebClient client;
        private Control_Genshin_usm _Genshin_usm;
        private Control_Mihoyo_resources _Mihoyo;
        private Control_About _About;
        private Control_Account _Account;
        private UserLookAndFeel userLookAndFeel;
        private Control_LrcToSrt _LrcToSrt;

        
        public fr_Main() 
        {

            InitializeComponent();
            HideSkins(_skinsToHide);
            // 创建 UserLookAndFeel 实例
            userLookAndFeel = new UserLookAndFeel(this);

            _Genshin_usm = new Control_Genshin_usm();
            _Genshin_usm.Dock = DockStyle.Fill;

            _Mihoyo = new Control_Mihoyo_resources();
            _Mihoyo.Dock = DockStyle.Fill;

            _About = new Control_About();
            _About.Dock = DockStyle.Fill;

            _Account = new Control_Account();
            _Account.Dock = DockStyle.Fill;

            _LrcToSrt = new Control_LrcToSrt();
            _LrcToSrt.Dock= DockStyle.Fill;

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
        private void Element_Account_Click(object sender, EventArgs e)
        {
            fr_Main_Container.Controls.Clear();
            _Account.Show();
            fr_Main_Container.Controls.Add(_Account);
        }
        private void Element_LrcToSrt_Click(object sender, EventArgs e)
        {
            fr_Main_Container.Controls.Clear();
            _LrcToSrt.Show();
            fr_Main_Container.Controls.Add(_LrcToSrt);
        }
        private void fr_Main_Load(object sender, EventArgs e)
        {
           
            string savedSkinName = Properties.Settings.Default.SkinName;

            if (!string.IsNullOrEmpty(savedSkinName))
            {
                UserLookAndFeel.Default.SetSkinStyle(savedSkinName);
            }
            Assembly assembly = typeof(Program).Assembly;
            AssemblyName name = new AssemblyName(assembly.FullName);
            int majorVersion = (int)name.Version.Major;
            int minorVersion = (int)name.Version.Minor;

            //根据GlobalVar对应变量值，修改显示版本信息；如需修改，请打开GlobalVar.cs文件，修改 Release 的值，注意类型是int;//  0  Alpha 内测版      1  bate 公测版      2  Release 正式版
            if (GlobalVar.Release == 0)
            {
                //toolStripStatusLabel4.Text = "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
                barStaticItem_Ver.Caption = "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + GlobalVar.VersionNo;
            }
            else if (GlobalVar.Release == 1)
            {
                //toolStripStatusLabel4.Text = "    版本：" + GlobalVar.VersionNo + "_bate（公测版）";
                barStaticItem_Ver.Caption = "    版本：" + GlobalVar.VersionNo + "_bate（公测版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + GlobalVar.VersionNo ;
            }
            else if (GlobalVar.Release == 2)
            {
                //toolStripStatusLabel4.Text = "    版本：" + $"{majorVersion}." + $"{minorVersion}" + "_Release（正式版）";
                barStaticItem_Ver.Caption = "    版本：" + $"{majorVersion}." + $"{minorVersion}" + "_Release（正式版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + GlobalVar.VersionNo;
            }
            else
            {
                //toolStripStatusLabel4.Text = "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
                barStaticItem_Ver.Caption = "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
                this.Text = GlobalVar.SoftTitle + "    版本：" + GlobalVar.VersionNo + "_Alpha（内测版）";
            }
            fr_Main_Container.Controls.Clear();
            _About.Show();
            fr_Main_Container.Controls.Add(_About);
            string path = GlobalVar.StrPath + @"\data\versions.json";
            string SaveFilesName = GlobalVar.StrPath + @"\data\versions.json.back";// 新增备份老 version.json
            if (System.IO.File.Exists(path))//检查文件是否存在 true = 存在 flase = 不存在
            {
                if (System.IO.File.Exists(SaveFilesName))
                {
                    return;
                }
                else
                {
                    System.IO.File.Copy(path, SaveFilesName, true);// 备份老 version.json
                }

            }
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
            //toolStripStatusLabel3.Text = $" 当前时间：{now:yyyy-MM-dd HH:mm:ss}  {week}   " + ChinaDate.GetChinaDate(DateTime.Now); 
            barStaticItem_Time.Caption = $" 当前时间：{now:yyyy-MM-dd HH:mm:ss}  {week}   " + ChinaDate.GetChinaDate(DateTime.Now)+"      ";
        }
      

        private void fr_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            string processName = "GICutscenes"; // 查找的程序进程名称
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                process.Kill();
            }
            Thread.Sleep(1000);
            try
            {
                DirectoryInfo di = new DirectoryInfo(GlobalVar.Output_path);
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
                //XtraMessageBox.Show("删除失败", GlobalVar.AuthorName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Process.GetCurrentProcess().Kill();
        }

        private void fr_Main_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        

        private void barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            string skinName = userLookAndFeel.ActiveSkinName;
            Properties.Settings.Default.SkinName = skinName;
            Properties.Settings.Default.Save();
            XtraMessageBox.Show($"当前皮肤：{userLookAndFeel.ActiveSkinName}","成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        string[] _skinsToHide = { "DevExpress Style", "DevExpress Dark Style" };
        private void HideSkins(string[] skinsToHide)
        {
  
            for (var i = 0; i < skinBarSubItem.ItemLinks.Count; i++)
            {
                //Check regular button items
                if (skinBarSubItem.ItemLinks[i] is BarButtonItemLink)
                {
                    var item = skinBarSubItem.ItemLinks[i];
                    foreach (var skin in skinsToHide)
                    {
                        if (item.Caption.Contains(skin))
                        {
                            item.Visible = false;
                        }
                    }
                }
                //Check buttons nested in the "Bonus Skins" sub-menu
                if (skinBarSubItem.ItemLinks[i] is BarSubItemLink && skinBarSubItem.ItemLinks[i].Caption == "Bonus Skins")
                {
                    BarSubItemLink group = (BarSubItemLink)skinBarSubItem.ItemLinks[i];
                    for (var j = 0; j < group.Item.ItemLinks.Count; j++)
                    {
                        var item = group.Item.ItemLinks[j];
                        foreach (var skin in skinsToHide)
                        {
                            if (item.Caption.Contains(skin))
                            {
                                item.Visible = false;
                            }
                        }
                    }
                }
                //Hide theme skins
                if (skinBarSubItem.ItemLinks[i] is BarSubItemLink && skinBarSubItem.ItemLinks[i].Caption == "Theme Skins")
                {
                    skinBarSubItem.ItemLinks[i].Visible = false;
                }
            }
        }

        private void barStaticItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HaitangYunchi/Mihoyo_Tools");
        }

        private void barStaticItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/3493128132626725");//海棠云螭的B站
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /**
             string ver_url = "";
            //ver_url = "https://gitee.com/haitangyunchi/Mihoyo_Tools/raw/master/Mihoyo_Tools/Upgrade/VerContrast.sdb"; // 发布使用这个地址
            ver_url = "https://gitee.com/haitangyunchi/Mihoyo_Tools/raw/Test/Mihoyo_Tools/Upgrade/VerContrast.sdb"; //自己测试使用这个地址
            string save_VerContrast = Path.GetTempPath() + @"\VerContrast.sdb";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(ver_url), save_VerContrast);
                GlobalVar.Upgrade_ver = INIFile.getString("VerContrast", "VerContrast", GlobalVar.VerContrast, save_VerContrast);
                GlobalVar.New_Info = INIFile.getString("VerContrast", "Verinfo", "", save_VerContrast);
            }
            Thread.Sleep(3000);
            //XtraMessageBox.Show(GlobalVar.Upgrade_ver);
            byte[] bytesToDecode = Convert.FromBase64String(GlobalVar.New_Info);
            string UTF8_Code = Encoding.UTF8.GetString(bytesToDecode);
            string base64String = UTF8_Code;

            if (GlobalVar.Upgrade_ver == GlobalVar.VerContrast)
            {
                return;
            }
            else
            {
                //DialogResult result = XtraMessageBox.Show(base64String, GlobalVar.AuthorName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                DialogResult result = XtraMessageBox.Show(base64String, "发现新版本", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                // 判断用户的点击结果
                if (result == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("https://www.123912.com/s/b6X3jv-wNtU3");
                    //System.Diagnostics.Process.Start("https://www.123865.com/s/b6X3jv-wNtU3");
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }

            }
             * **/
            //AE72DEEE2BDF489DACC17D39D8D2C65E
            //XtraMessageBox.Show(up.GetUpdateVer("AE72DEEE2BDF489DACC17D39D8D2C65E"));
            string ver = up.GetUpdateVer("AE72DEEE2BDF489DACC17D39D8D2C65E");
            if (ver == GlobalVar.VerContrast)
            {
                return;
            }
            else
            {
                DialogResult result = XtraMessageBox.Show(up.GetUpdateInformation("AE72DEEE2BDF489DACC17D39D8D2C65E"), "发现新版本", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                // 判断用户的点击结果
                if (result == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start("https://www.123912.com/s/b6X3jv-wNtU3");
                    //System.Diagnostics.Process.Start("https://www.123865.com/s/b6X3jv-wNtU3");
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            
        }
    }

}
