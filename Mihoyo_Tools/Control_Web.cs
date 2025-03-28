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
    public partial class Control_Web : DevExpress.XtraEditors.XtraUserControl
    {

        public Control_Web()
        {
            InitializeComponent();
        }

        private async void EnsureCoreWebView2Async()
        {
            await webView21.EnsureCoreWebView2Async();
        }
        private void Control_Mihoyo_resources_Load(object sender, EventArgs e)
        {
            webView21.Source = new Uri(GlobalVar.Control_Web);
            
        }
    }
}
