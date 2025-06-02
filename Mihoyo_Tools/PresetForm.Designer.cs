namespace Mihoyo_Tools
{
    partial class PresetForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            gridControl = new DevExpress.XtraGrid.GridControl();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            colVideoCodec = new DevExpress.XtraGrid.Columns.GridColumn();
            colResolution = new DevExpress.XtraGrid.Columns.GridColumn();
            colBitrate = new DevExpress.XtraGrid.Columns.GridColumn();
            colAdditionalArgs = new DevExpress.XtraGrid.Columns.GridColumn();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnOK = new DevExpress.XtraEditors.SimpleButton();
            btnDelete = new DevExpress.XtraEditors.SimpleButton();
            btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            SuspendLayout();
            // 
            // gridControl
            // 
            gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gridControl.Location = new System.Drawing.Point(0, 0);
            gridControl.MainView = gridView;
            gridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gridControl.Name = "gridControl";
            gridControl.Size = new System.Drawing.Size(748, 319);
            gridControl.TabIndex = 0;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            // 
            // gridView
            // 
            gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colName, colVideoCodec, colResolution, colBitrate, colAdditionalArgs });
            gridView.DetailHeight = 272;
            gridView.GridControl = gridControl;
            gridView.Name = "gridView";
            gridView.OptionsEditForm.PopupEditFormWidth = 700;
            gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            colName.Caption = "预设名称";
            colName.FieldName = "Name";
            colName.MinWidth = 22;
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 0;
            colName.Width = 225;
            // 
            // colVideoCodec
            // 
            colVideoCodec.Caption = "视频编码";
            colVideoCodec.FieldName = "VideoCodec";
            colVideoCodec.MinWidth = 22;
            colVideoCodec.Name = "colVideoCodec";
            colVideoCodec.Visible = true;
            colVideoCodec.VisibleIndex = 1;
            colVideoCodec.Width = 116;
            // 
            // colResolution
            // 
            colResolution.Caption = "分辨率";
            colResolution.FieldName = "Resolution";
            colResolution.MinWidth = 22;
            colResolution.Name = "colResolution";
            colResolution.Visible = true;
            colResolution.VisibleIndex = 2;
            colResolution.Width = 131;
            // 
            // colBitrate
            // 
            colBitrate.Caption = "质量模式";
            colBitrate.FieldName = "Bitrate";
            colBitrate.MinWidth = 22;
            colBitrate.Name = "colBitrate";
            colBitrate.Visible = true;
            colBitrate.VisibleIndex = 3;
            colBitrate.Width = 121;
            // 
            // colAdditionalArgs
            // 
            colAdditionalArgs.Caption = "视频帧率";
            colAdditionalArgs.FieldName = "fps";
            colAdditionalArgs.MinWidth = 22;
            colAdditionalArgs.Name = "colAdditionalArgs";
            colAdditionalArgs.Visible = true;
            colAdditionalArgs.VisibleIndex = 4;
            colAdditionalArgs.Width = 123;
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(btnCancel);
            panelControl1.Controls.Add(btnOK);
            panelControl1.Controls.Add(btnDelete);
            panelControl1.Controls.Add(btnAdd);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelControl1.Location = new System.Drawing.Point(0, 319);
            panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(748, 47);
            panelControl1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(653, 14);
            btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(82, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "取消";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(566, 14);
            btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(82, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "保存";
            btnOK.Click += btnOK_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(98, 14);
            btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(82, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "删除";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(10, 14);
            btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(82, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "添加";
            btnAdd.Click += btnAdd_Click;
            // 
            // PresetForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(748, 366);
            Controls.Add(gridControl);
            Controls.Add(panelControl1);
            IconOptions.Image = Properties.Resources.hutao;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(750, 400);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(750, 400);
            Name = "PresetForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "管理预设";
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            ResumeLayout(false);

        }

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVideoCodec;
        private DevExpress.XtraGrid.Columns.GridColumn colResolution;
        private DevExpress.XtraGrid.Columns.GridColumn colBitrate;
        private DevExpress.XtraGrid.Columns.GridColumn colAdditionalArgs;
    }
}