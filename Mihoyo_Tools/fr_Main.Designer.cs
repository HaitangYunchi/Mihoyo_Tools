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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_Main));
            fr_Main_Container = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            Home = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            Genshin_tools = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            Lrc_srt = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            Soft_Rex = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar3 = new DevExpress.XtraBars.Bar();
            barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            barStaticItem_Time = new DevExpress.XtraBars.BarStaticItem();
            Soft_Number = new DevExpress.XtraBars.BarStaticItem();
            barStaticItem_Ver = new DevExpress.XtraBars.BarStaticItem();
            SerialNumberID = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            timer1 = new System.Windows.Forms.Timer(components);
            Video_size = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // fr_Main_Container
            // 
            resources.ApplyResources(fr_Main_Container, "fr_Main_Container");
            fr_Main_Container.Name = "fr_Main_Container";
            // 
            // accordionControl1
            // 
            resources.ApplyResources(accordionControl1, "accordionControl1");
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { Home });
            accordionControl1.Name = "accordionControl1";
            accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            accordionControl1.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // Home
            // 
            Home.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { Genshin_tools, Lrc_srt, Soft_Rex, Video_size });
            Home.Expanded = true;
            Home.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("Home.ImageOptions.Image");
            Home.Name = "Home";
            resources.ApplyResources(Home, "Home");
            Home.Click += Home_Click;
            // 
            // Genshin_tools
            // 
            Genshin_tools.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("Genshin_tools.ImageOptions.Image");
            Genshin_tools.Name = "Genshin_tools";
            Genshin_tools.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            resources.ApplyResources(Genshin_tools, "Genshin_tools");
            Genshin_tools.Click += Genshin_tools_Click;
            // 
            // Lrc_srt
            // 
            Lrc_srt.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("Lrc_srt.ImageOptions.Image");
            Lrc_srt.Name = "Lrc_srt";
            Lrc_srt.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            resources.ApplyResources(Lrc_srt, "Lrc_srt");
            Lrc_srt.Click += Lrc_srt_Click;
            // 
            // Soft_Rex
            // 
            Soft_Rex.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("Soft_Rex.ImageOptions.Image");
            Soft_Rex.Name = "Soft_Rex";
            Soft_Rex.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            resources.ApplyResources(Soft_Rex, "Soft_Rex");
            Soft_Rex.Click += Soft_Rex_Click;
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            resources.ApplyResources(fluentDesignFormControl1, "fluentDesignFormControl1");
            fluentDesignFormControl1.Manager = fluentFormDefaultManager1;
            fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            fluentFormDefaultManager1.Form = this;
            fluentFormDefaultManager1.MaxItemId = 2;
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barStaticItem1, barStaticItem2, barStaticItem_Time, Soft_Number, barStaticItem_Ver, SerialNumberID });
            barManager1.MaxItemId = 6;
            barManager1.StatusBar = bar3;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barStaticItem1), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem2), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem_Time), new DevExpress.XtraBars.LinkPersistInfo(Soft_Number), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem_Ver), new DevExpress.XtraBars.LinkPersistInfo(SerialNumberID) });
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(bar3, "bar3");
            // 
            // barStaticItem1
            // 
            resources.ApplyResources(barStaticItem1, "barStaticItem1");
            barStaticItem1.Id = 0;
            barStaticItem1.Name = "barStaticItem1";
            barStaticItem1.ItemClick += barStaticItem1_ItemClick;
            // 
            // barStaticItem2
            // 
            resources.ApplyResources(barStaticItem2, "barStaticItem2");
            barStaticItem2.Id = 1;
            barStaticItem2.Name = "barStaticItem2";
            barStaticItem2.ItemClick += barStaticItem2_ItemClick;
            // 
            // barStaticItem_Time
            // 
            resources.ApplyResources(barStaticItem_Time, "barStaticItem_Time");
            barStaticItem_Time.Id = 2;
            barStaticItem_Time.Name = "barStaticItem_Time";
            // 
            // Soft_Number
            // 
            resources.ApplyResources(Soft_Number, "Soft_Number");
            Soft_Number.Id = 3;
            Soft_Number.Name = "Soft_Number";
            // 
            // barStaticItem_Ver
            // 
            barStaticItem_Ver.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(barStaticItem_Ver, "barStaticItem_Ver");
            barStaticItem_Ver.Id = 4;
            barStaticItem_Ver.Name = "barStaticItem_Ver";
            // 
            // SerialNumberID
            // 
            resources.ApplyResources(SerialNumberID, "SerialNumberID");
            SerialNumberID.Id = 5;
            SerialNumberID.Name = "SerialNumberID";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            resources.ApplyResources(barDockControlTop, "barDockControlTop");
            barDockControlTop.Manager = barManager1;
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(barDockControlBottom, "barDockControlBottom");
            barDockControlBottom.Manager = barManager1;
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(barDockControlLeft, "barDockControlLeft");
            barDockControlLeft.Manager = barManager1;
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            resources.ApplyResources(barDockControlRight, "barDockControlRight");
            barDockControlRight.Manager = barManager1;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Video_size
            // 
            Video_size.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("accordionControlElement1.ImageOptions.Image");
            Video_size.Name = "Video_size";
            Video_size.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            resources.ApplyResources(Video_size, "Video_size");
            Video_size.Click += Video_size_Click;
            // 
            // fr_Main
            // 
            Appearance.BackColor = System.Drawing.SystemColors.Control;
            Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ControlContainer = fr_Main_Container;
            Controls.Add(fr_Main_Container);
            Controls.Add(accordionControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            IconOptions.Image = Properties.Resources.hutao;
            MaximizeBox = false;
            Name = "fr_Main";
            NavigationControl = accordionControl1;
            FormClosed += fr_Main_FormClosed;
            Load += fr_Main_Load;
            Shown += fr_Main_Shown;
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fr_Main_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        public DevExpress.XtraBars.Navigation.AccordionControlElement Genshin_tools;
        public DevExpress.XtraBars.Navigation.AccordionControlElement Lrc_srt;
        public DevExpress.XtraBars.Navigation.AccordionControlElement Home;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Time;
        private DevExpress.XtraBars.BarStaticItem Soft_Number;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Ver;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Soft_Rex;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarStaticItem SerialNumberID;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Video_size;
    }
}

