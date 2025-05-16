using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Mihoyo_Tools.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mihoyo_Tools
{
    public partial class PresetForm : XtraForm
    {
        public List<Preset> Presets { get; private set; }

        public PresetForm(List<Preset> presets)
        {
            InitializeComponent();
            Presets = new List<Preset>(presets);
            gridControl.DataSource = Presets;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Presets.Add(new Preset { Name = "新预设" });
            gridView.RefreshData();
            gridView.FocusedRowHandle = gridView.RowCount - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRowsCount > 0)
            {
                if (XtraMessageBox.Show("确定要删除选中的预设吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gridView.DeleteSelectedRows();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}