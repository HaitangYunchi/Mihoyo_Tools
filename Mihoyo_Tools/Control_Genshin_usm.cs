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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mihoyo_Tools
{
	public partial class Control_Genshin_usm: DevExpress.XtraEditors.XtraUserControl
	{
        public Control_Genshin_usm()
		{
            InitializeComponent();
		}

        private void Control_Genshin_usm_Load(object sender, EventArgs e)
        {
            textEdit1.Text = GlobalVar.StrPath + @"\data\GICutscenes.exe";
            textEdit2.Text = GlobalVar.StrPath + @"\data\ffmpeg.exe";
            INIFile.writeString("Config", "Cutscenes", textEdit1.Text, GlobalVar.IniName);
            INIFile.writeString("Config", "Ffmpegr", textEdit2.Text, GlobalVar.IniName);

        }
    }
}
