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
	public partial class Web_Browser: DevExpress.XtraEditors.XtraUserControl
	{
        public Web_Browser()
		{
            InitializeComponent();
            webView21.Source = new Uri("http://files.hk4e.com");
        }
	}
}
