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

namespace Mihoyo_Tools
{
	public partial class FormInput: DevExpress.XtraEditors.XtraForm
	{
        private string gameNameEN;
        public FormInput(string gameNameEN)
		{
            InitializeComponent();
            this.gameNameEN = gameNameEN;
           }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAcctName.Text))
            {
                XtraMessageBox.Show("请输入账号备注", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MiHoYoAccount acct = null;
                if (gameNameEN == "Genshin")
                {
                    acct = new GenshinAccount();
                }
                else if (gameNameEN == "GenshinOversea")
                {
                    acct = new GenshinOverseaAccount();
                }
                else if (gameNameEN == "GenshinCloud")
                {
                    acct = new GenshinCloudAccount();
                }
                else if (gameNameEN == "StarRail")
                {
                    acct = new StarRailAccount();
                }
                else if (gameNameEN == "ZZZ")
                {
                    acct = new ZZZAccount();
                }
                else if (gameNameEN == "StarRailOversea")
                {
                    acct = new StarRailOverseaAccount();
                }
                else if (gameNameEN == "HonkaiImpact3")
                {
                    acct = new HonkaiImpact3Account();
                }
                else
                {
                    XtraMessageBox.Show("未知的游戏账户类型", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                acct.ReadFromRegistry();
                acct.Name = txtAcctName.Text;
                acct.WriteToDisk();
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}