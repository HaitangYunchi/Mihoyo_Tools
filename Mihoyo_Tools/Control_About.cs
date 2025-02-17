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

namespace Mihoyo_Tools
{
    public partial class Control_About : DevExpress.XtraEditors.XtraUserControl
    {
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
    }
}
