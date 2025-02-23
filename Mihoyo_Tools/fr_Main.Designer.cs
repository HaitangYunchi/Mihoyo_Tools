namespace Mihoyo_Tools
{
    partial class fr_Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_Main));
            this.fr_Main_Container = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.Element_Tools = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_ys_usm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_Account = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.lElement_Rex = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_mihoyo_rex = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_about = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_guanyu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fr_Main_Container
            // 
            this.fr_Main_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fr_Main_Container.Location = new System.Drawing.Point(260, 31);
            this.fr_Main_Container.Name = "fr_Main_Container";
            this.fr_Main_Container.Size = new System.Drawing.Size(1263, 778);
            this.fr_Main_Container.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_Tools,
            this.lElement_Rex,
            this.Element_about});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 778);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // Element_Tools
            // 
            this.Element_Tools.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_ys_usm,
            this.Element_Account});
            this.Element_Tools.Expanded = true;
            this.Element_Tools.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_Tools.ImageOptions.Image")));
            this.Element_Tools.Name = "Element_Tools";
            this.Element_Tools.Text = "工具";
            // 
            // Element_ys_usm
            // 
            this.Element_ys_usm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_ys_usm.ImageOptions.Image")));
            this.Element_ys_usm.Name = "Element_ys_usm";
            this.Element_ys_usm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Element_ys_usm.Text = "原神USM导出工具";
            this.Element_ys_usm.Click += new System.EventHandler(this.Element_ys_usm_Click);
            // 
            // Element_Account
            // 
            this.Element_Account.Name = "Element_Account";
            this.Element_Account.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Element_Account.Text = "账号管理";
            this.Element_Account.Click += new System.EventHandler(this.Element_Account_Click);
            // 
            // lElement_Rex
            // 
            this.lElement_Rex.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_mihoyo_rex});
            this.lElement_Rex.Expanded = true;
            this.lElement_Rex.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lElement_Rex.ImageOptions.Image")));
            this.lElement_Rex.Name = "lElement_Rex";
            this.lElement_Rex.Text = "米哈游资源";
            // 
            // Element_mihoyo_rex
            // 
            this.Element_mihoyo_rex.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_mihoyo_rex.ImageOptions.Image")));
            this.Element_mihoyo_rex.Name = "Element_mihoyo_rex";
            this.Element_mihoyo_rex.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Element_mihoyo_rex.Text = "米哈游游戏资源";
            this.Element_mihoyo_rex.Click += new System.EventHandler(this.Element_mihoyo_rex_Click);
            // 
            // Element_about
            // 
            this.Element_about.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_guanyu});
            this.Element_about.Expanded = true;
            this.Element_about.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_about.ImageOptions.Image")));
            this.Element_about.Name = "Element_about";
            this.Element_about.Text = "关于";
            // 
            // Element_guanyu
            // 
            this.Element_guanyu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_guanyu.ImageOptions.Image")));
            this.Element_guanyu.Name = "Element_guanyu";
            this.Element_guanyu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Element_guanyu.Text = "关于";
            this.Element_guanyu.Click += new System.EventHandler(this.Element_guanyu_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinDropDownButtonItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1523, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.skinDropDownButtonItem1);
            // 
            // skinDropDownButtonItem1
            // 
            this.skinDropDownButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.skinDropDownButtonItem1.Id = 0;
            this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinDropDownButtonItem1});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(260, 787);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1263, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel1.Text = "米哈游工具箱";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(300, 17);
            this.toolStripStatusLabel2.Text = "软件开发：海棠云螭（B站） 海棠云螭（抖音）";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.AutoSize = false;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(550, 17);
            this.toolStripStatusLabel3.Text = "当前时间：";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabel5.Spring = true;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel4.Text = "版本：1.0";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // fr_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 809);
            this.ControlContainer = this.fr_Main_Container;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fr_Main_Container);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("fr_Main.IconOptions.Image")));
            this.MinimumSize = new System.Drawing.Size(1525, 810);
            this.Name = "fr_Main";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 米哈游工具箱";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fr_Main_FormClosed);
            this.Load += new System.EventHandler(this.fr_Main_Load);
            this.Shown += new System.EventHandler(this.fr_Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fr_Main_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_Tools;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_ys_usm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement lElement_Rex;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_mihoyo_rex;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_about;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_guanyu;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_Account;
    }
}