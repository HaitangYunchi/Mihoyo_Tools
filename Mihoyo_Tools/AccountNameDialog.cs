using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using System.Xml.Linq;

namespace Mihoyo_Tools
{
	public partial class AccountNameDialog: DevExpress.XtraEditors.XtraForm
	{
        public string AccountName => txtAcctName.Text;
        public AccountNameDialog()
		{
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            btnOK.Click += (s, e) => DialogResult = DialogResult.OK;
            btnCance.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
    }
}