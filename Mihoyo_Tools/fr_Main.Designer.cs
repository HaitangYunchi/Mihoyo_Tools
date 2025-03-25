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
            this.Element_LrcToSrt = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.lElement_Rex = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_mihoyo_rex = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_about = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_guanyu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.skinBarSubItem = new DevExpress.XtraBars.SkinBarSubItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_Time = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_Ver = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fr_Main_Container
            // 
            this.fr_Main_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fr_Main_Container.Location = new System.Drawing.Point(260, 33);
            this.fr_Main_Container.Name = "fr_Main_Container";
            this.fr_Main_Container.Size = new System.Drawing.Size(1263, 740);
            this.fr_Main_Container.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_Tools,
            this.lElement_Rex,
            this.Element_about});
            this.accordionControl1.Location = new System.Drawing.Point(0, 33);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 740);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // Element_Tools
            // 
            this.Element_Tools.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_ys_usm,
            this.Element_Account,
            this.Element_LrcToSrt});
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
            this.Element_Account.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_Account.ImageOptions.Image")));
            this.Element_Account.Name = "Element_Account";
            this.Element_Account.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Element_Account.Text = "账号管理";
            this.Element_Account.Click += new System.EventHandler(this.Element_Account_Click);
            // 
            // Element_LrcToSrt
            // 
            this.Element_LrcToSrt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_LrcToSrt.ImageOptions.Image")));
            this.Element_LrcToSrt.Name = "Element_LrcToSrt";
            this.Element_LrcToSrt.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Element_LrcToSrt.Text = "LRC 转 SRT";
            this.Element_LrcToSrt.Click += new System.EventHandler(this.Element_LrcToSrt_Click);
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
            this.skinDropDownButtonItem1,
            this.barButtonItem,
            this.skinBarSubItem});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1523, 33);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barButtonItem);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.skinBarSubItem);
            // 
            // skinDropDownButtonItem1
            // 
            this.skinDropDownButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.skinDropDownButtonItem1.Id = 16;
            this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            this.skinDropDownButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem
            // 
            this.barButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem.Caption = "保存皮肤设置";
            this.barButtonItem.Id = 17;
            this.barButtonItem.Name = "barButtonItem";
            this.barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ItemClick);
            // 
            // skinBarSubItem
            // 
            this.skinBarSubItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.skinBarSubItem.Caption = "Skin";
            this.skinBarSubItem.Id = 18;
            this.skinBarSubItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("skinBarSubItem.ImageOptions.Image")));
            this.skinBarSubItem.Name = "skinBarSubItem";
            this.skinBarSubItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinDropDownButtonItem1,
            this.barButtonItem,
            this.skinBarSubItem});
            this.fluentFormDefaultManager1.MaxItemId = 19;
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
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.barHeaderItem1,
            this.barStaticItem2,
            this.barStaticItem_Time,
            this.barStaticItem_Ver});
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_Time),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_Ver)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "米哈游工具箱";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStaticItem1_ItemClick);
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "软件开发：海棠云螭（B站） 海棠云螭（抖音）";
            this.barStaticItem2.Id = 2;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStaticItem2_ItemClick);
            // 
            // barStaticItem_Time
            // 
            this.barStaticItem_Time.Caption = "  当前时间：";
            this.barStaticItem_Time.Id = 3;
            this.barStaticItem_Time.Name = "barStaticItem_Time";
            // 
            // barStaticItem_Ver
            // 
            this.barStaticItem_Ver.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem_Ver.Caption = "版本：1.0";
            this.barStaticItem_Ver.Id = 4;
            this.barStaticItem_Ver.Name = "barStaticItem_Ver";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 33);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1523, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 773);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1523, 36);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 740);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1523, 33);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 740);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "barHeaderItem1";
            this.barHeaderItem1.Id = 1;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 3";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 3";
            // 
            // fr_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 809);
            this.ControlContainer = this.fr_Main_Container;
            this.Controls.Add(this.fr_Main_Container);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fr_Main_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_Tools;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_ys_usm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement lElement_Rex;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_mihoyo_rex;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_about;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_guanyu;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_Account;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_LrcToSrt;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Time;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Ver;
        private DevExpress.XtraBars.Bar bar1;
    }
}