namespace Mihoyo_Tools
{
    partial class Control_Account
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageGenshin = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageSatrRail = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageHonkaiImpact3 = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageGenshinCloud = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageGenshinOversea = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageSatrRailOversea = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageZZZ = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtGenshinPath = new DevExpress.XtraEditors.TextEdit();
            this.txtGenshinStartParam = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lvwGenshinAcct = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnGenshinSwitch = new DevExpress.XtraEditors.SimpleButton();
            this.chkGenshinAutoStart = new System.Windows.Forms.CheckBox();
            this.btnGenshinAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenshinDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabPageGenshin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenshinPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenshinStartParam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwGenshinAcct)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(29, 63);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabPageGenshin;
            this.xtraTabControl1.Size = new System.Drawing.Size(1263, 741);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageGenshin,
            this.tabPageSatrRail,
            this.tabPageHonkaiImpact3,
            this.tabPageGenshinCloud,
            this.tabPageGenshinOversea,
            this.tabPageSatrRailOversea,
            this.tabPageZZZ});
            // 
            // tabPageGenshin
            // 
            this.tabPageGenshin.Controls.Add(this.groupControl1);
            this.tabPageGenshin.Name = "tabPageGenshin";
            this.tabPageGenshin.Size = new System.Drawing.Size(1261, 715);
            this.tabPageGenshin.Text = " 原神 ";
            // 
            // tabPageSatrRail
            // 
            this.tabPageSatrRail.Name = "tabPageSatrRail";
            this.tabPageSatrRail.Size = new System.Drawing.Size(1261, 674);
            this.tabPageSatrRail.Text = "崩坏:星穹铁道";
            // 
            // tabPageHonkaiImpact3
            // 
            this.tabPageHonkaiImpact3.Name = "tabPageHonkaiImpact3";
            this.tabPageHonkaiImpact3.Size = new System.Drawing.Size(0, 0);
            this.tabPageHonkaiImpact3.Text = "崩坏3";
            // 
            // tabPageGenshinCloud
            // 
            this.tabPageGenshinCloud.Name = "tabPageGenshinCloud";
            this.tabPageGenshinCloud.Size = new System.Drawing.Size(0, 0);
            this.tabPageGenshinCloud.Text = "云 原神";
            // 
            // tabPageGenshinOversea
            // 
            this.tabPageGenshinOversea.Name = "tabPageGenshinOversea";
            this.tabPageGenshinOversea.Size = new System.Drawing.Size(0, 0);
            this.tabPageGenshinOversea.Text = "原神（国际服）";
            // 
            // tabPageSatrRailOversea
            // 
            this.tabPageSatrRailOversea.Name = "tabPageSatrRailOversea";
            this.tabPageSatrRailOversea.Size = new System.Drawing.Size(0, 0);
            this.tabPageSatrRailOversea.Text = "崩坏:星穹铁道（国际服）";
            // 
            // tabPageZZZ
            // 
            this.tabPageZZZ.Name = "tabPageZZZ";
            this.tabPageZZZ.Size = new System.Drawing.Size(0, 0);
            this.tabPageZZZ.Text = "绝区零";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnGenshinDelete);
            this.groupControl1.Controls.Add(this.btnGenshinAdd);
            this.groupControl1.Controls.Add(this.chkGenshinAutoStart);
            this.groupControl1.Controls.Add(this.btnGenshinSwitch);
            this.groupControl1.Controls.Add(this.lvwGenshinAcct);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtGenshinStartParam);
            this.groupControl1.Controls.Add(this.txtGenshinPath);
            this.groupControl1.Location = new System.Drawing.Point(28, 27);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1205, 659);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "帐号切换";
            // 
            // txtGenshinPath
            // 
            this.txtGenshinPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenshinPath.Location = new System.Drawing.Point(19, 67);
            this.txtGenshinPath.Name = "txtGenshinPath";
            this.txtGenshinPath.Size = new System.Drawing.Size(1044, 20);
            this.txtGenshinPath.TabIndex = 0;
            // 
            // txtGenshinStartParam
            // 
            this.txtGenshinStartParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenshinStartParam.Location = new System.Drawing.Point(19, 128);
            this.txtGenshinStartParam.Name = "txtGenshinStartParam";
            this.txtGenshinStartParam.Size = new System.Drawing.Size(1157, 20);
            this.txtGenshinStartParam.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "【原神】游戏路径：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "启动参数";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(1079, 65);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(97, 28);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "选择...";
            // 
            // lvwGenshinAcct
            // 
            this.lvwGenshinAcct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwGenshinAcct.Location = new System.Drawing.Point(19, 192);
            this.lvwGenshinAcct.Name = "lvwGenshinAcct";
            this.lvwGenshinAcct.Size = new System.Drawing.Size(1044, 436);
            this.lvwGenshinAcct.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(19, 172);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "账号保存列表";
            // 
            // btnGenshinSwitch
            // 
            this.btnGenshinSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenshinSwitch.Location = new System.Drawing.Point(1079, 192);
            this.btnGenshinSwitch.Name = "btnGenshinSwitch";
            this.btnGenshinSwitch.Size = new System.Drawing.Size(97, 44);
            this.btnGenshinSwitch.TabIndex = 5;
            this.btnGenshinSwitch.Text = "切换账号";
            // 
            // chkGenshinAutoStart
            // 
            this.chkGenshinAutoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGenshinAutoStart.AutoSize = true;
            this.chkGenshinAutoStart.Location = new System.Drawing.Point(1079, 316);
            this.chkGenshinAutoStart.Name = "chkGenshinAutoStart";
            this.chkGenshinAutoStart.Size = new System.Drawing.Size(86, 18);
            this.chkGenshinAutoStart.TabIndex = 6;
            this.chkGenshinAutoStart.Text = "切换时重启";
            this.chkGenshinAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnGenshinAdd
            // 
            this.btnGenshinAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenshinAdd.Location = new System.Drawing.Point(1079, 351);
            this.btnGenshinAdd.Name = "btnGenshinAdd";
            this.btnGenshinAdd.Size = new System.Drawing.Size(86, 23);
            this.btnGenshinAdd.TabIndex = 7;
            this.btnGenshinAdd.Text = "保存当前账号";
            // 
            // btnGenshinDelete
            // 
            this.btnGenshinDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenshinDelete.Location = new System.Drawing.Point(1079, 392);
            this.btnGenshinDelete.Name = "btnGenshinDelete";
            this.btnGenshinDelete.Size = new System.Drawing.Size(86, 23);
            this.btnGenshinDelete.TabIndex = 7;
            this.btnGenshinDelete.Text = "删除当前账号";
            // 
            // Control_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Control_Account";
            this.Size = new System.Drawing.Size(1314, 843);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabPageGenshin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenshinPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenshinStartParam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwGenshinAcct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabPageGenshin;
        private DevExpress.XtraTab.XtraTabPage tabPageSatrRail;
        private DevExpress.XtraTab.XtraTabPage tabPageHonkaiImpact3;
        private DevExpress.XtraTab.XtraTabPage tabPageGenshinCloud;
        private DevExpress.XtraTab.XtraTabPage tabPageGenshinOversea;
        private DevExpress.XtraTab.XtraTabPage tabPageSatrRailOversea;
        private DevExpress.XtraTab.XtraTabPage tabPageZZZ;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtGenshinStartParam;
        private DevExpress.XtraEditors.TextEdit txtGenshinPath;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ListBoxControl lvwGenshinAcct;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnGenshinSwitch;
        private DevExpress.XtraEditors.SimpleButton btnGenshinDelete;
        private DevExpress.XtraEditors.SimpleButton btnGenshinAdd;
        private System.Windows.Forms.CheckBox chkGenshinAutoStart;
    }
}
