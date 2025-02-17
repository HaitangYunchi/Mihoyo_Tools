using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
