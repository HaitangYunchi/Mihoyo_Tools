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
            this.Element_usm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_ys_usm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.lElement_Rex = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Element_mihoyo_rex = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fr_Main_Container
            // 
            this.fr_Main_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fr_Main_Container.Location = new System.Drawing.Point(260, 31);
            this.fr_Main_Container.Name = "fr_Main_Container";
            this.fr_Main_Container.Size = new System.Drawing.Size(1262, 767);
            this.fr_Main_Container.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_usm,
            this.lElement_Rex});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 767);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // Element_usm
            // 
            this.Element_usm.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Element_ys_usm});
            this.Element_usm.Expanded = true;
            this.Element_usm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_usm.ImageOptions.Image")));
            this.Element_usm.Name = "Element_usm";
            this.Element_usm.Text = "USM 工具";
            // 
            // Element_ys_usm
            // 
            this.Element_ys_usm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Element_ys_usm.ImageOptions.Image")));
            this.Element_ys_usm.Name = "Element_ys_usm";
            this.Element_ys_usm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Element_ys_usm.Text = "原神USM导出工具";
            this.Element_ys_usm.Click += new System.EventHandler(this.Element_ys_usm_Click);
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
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.skinDropDownButtonItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1522, 31);
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
            this.statusStrip1.Location = new System.Drawing.Point(260, 776);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1262, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // fr_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 798);
            this.ControlContainer = this.fr_Main_Container;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fr_Main_Container);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("fr_Main.IconOptions.Image")));
            this.Name = "fr_Main";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 米哈游工具箱";
            this.Load += new System.EventHandler(this.fr_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fr_Main_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_usm;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_ys_usm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement lElement_Rex;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Element_mihoyo_rex;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}