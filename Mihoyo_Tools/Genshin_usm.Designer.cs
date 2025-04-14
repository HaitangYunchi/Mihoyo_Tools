namespace Mihoyo_Tools
{
    partial class Genshin_usm
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
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            FFmpeg_path = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            Gutscenes_path = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            buttonEdit_Out_path = new DevExpress.XtraEditors.ButtonEdit();
            buttonEdit_usm_path = new DevExpress.XtraEditors.ButtonEdit();
            buttonEdit_Game_path = new DevExpress.XtraEditors.ButtonEdit();
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            simpleButton_Stop = new DevExpress.XtraEditors.SimpleButton();
            labelControl8 = new DevExpress.XtraEditors.LabelControl();
            simpleButton_Out = new DevExpress.XtraEditors.SimpleButton();
            radioButton_usm_path = new System.Windows.Forms.RadioButton();
            radioButton_Game_path = new System.Windows.Forms.RadioButton();
            radioButton_KR = new System.Windows.Forms.RadioButton();
            radioButton_JP = new System.Windows.Forms.RadioButton();
            radioButton_EN = new System.Windows.Forms.RadioButton();
            radioButton_CN = new System.Windows.Forms.RadioButton();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            buttonEdit_usm_Name = new DevExpress.XtraEditors.ButtonEdit();
            memoEdit_out = new DevExpress.XtraEditors.MemoEdit();
            backgroundWorker_Game_path = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FFmpeg_path.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Gutscenes_path.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_Out_path.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_usm_path.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_Game_path.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_usm_Name.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_out.Properties).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(labelControl6);
            groupControl1.Controls.Add(labelControl5);
            groupControl1.Controls.Add(labelControl4);
            groupControl1.Controls.Add(labelControl3);
            groupControl1.Controls.Add(FFmpeg_path);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(Gutscenes_path);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(buttonEdit_Out_path);
            groupControl1.Controls.Add(buttonEdit_usm_path);
            groupControl1.Controls.Add(buttonEdit_Game_path);
            groupControl1.Location = new System.Drawing.Point(45, 49);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(527, 292);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "系统设置";
            // 
            // labelControl6
            // 
            labelControl6.Location = new System.Drawing.Point(43, 245);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(241, 14);
            labelControl6.TabIndex = 0;
            labelControl6.Text = "* 原神游戏目录直接选择 Yuanshen.exe 即可";
            // 
            // labelControl5
            // 
            labelControl5.Location = new System.Drawing.Point(79, 203);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(48, 14);
            labelControl5.TabIndex = 0;
            labelControl5.Text = "输出目录";
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(43, 169);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(84, 14);
            labelControl4.TabIndex = 0;
            labelControl4.Text = "自定义USM目录";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(48, 135);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(79, 14);
            labelControl3.TabIndex = 0;
            labelControl3.Text = "*原神游戏目录";
            // 
            // FFmpeg_path
            // 
            FFmpeg_path.Location = new System.Drawing.Point(136, 94);
            FFmpeg_path.Name = "FFmpeg_path";
            FFmpeg_path.Properties.ReadOnly = true;
            FFmpeg_path.Size = new System.Drawing.Size(338, 28);
            FFmpeg_path.TabIndex = 1;
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(84, 101);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(43, 14);
            labelControl2.TabIndex = 0;
            labelControl2.Text = "FFmpeg";
            // 
            // Gutscenes_path
            // 
            Gutscenes_path.Location = new System.Drawing.Point(136, 60);
            Gutscenes_path.Name = "Gutscenes_path";
            Gutscenes_path.Properties.ReadOnly = true;
            Gutscenes_path.Size = new System.Drawing.Size(338, 28);
            Gutscenes_path.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(70, 67);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(57, 14);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Gutscenes";
            // 
            // buttonEdit_Out_path
            // 
            buttonEdit_Out_path.Location = new System.Drawing.Point(136, 196);
            buttonEdit_Out_path.Name = "buttonEdit_Out_path";
            buttonEdit_Out_path.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            buttonEdit_Out_path.Properties.ReadOnly = true;
            buttonEdit_Out_path.Size = new System.Drawing.Size(338, 28);
            buttonEdit_Out_path.TabIndex = 1;
            buttonEdit_Out_path.ButtonClick += buttonEdit_Out_path_ButtonClick;
            // 
            // buttonEdit_usm_path
            // 
            buttonEdit_usm_path.Location = new System.Drawing.Point(136, 162);
            buttonEdit_usm_path.Name = "buttonEdit_usm_path";
            buttonEdit_usm_path.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            buttonEdit_usm_path.Properties.ReadOnly = true;
            buttonEdit_usm_path.Size = new System.Drawing.Size(338, 28);
            buttonEdit_usm_path.TabIndex = 1;
            buttonEdit_usm_path.ButtonClick += buttonEdit_usm_path_ButtonClick;
            // 
            // buttonEdit_Game_path
            // 
            buttonEdit_Game_path.Location = new System.Drawing.Point(136, 128);
            buttonEdit_Game_path.Name = "buttonEdit_Game_path";
            buttonEdit_Game_path.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            buttonEdit_Game_path.Properties.ReadOnly = true;
            buttonEdit_Game_path.Size = new System.Drawing.Size(338, 28);
            buttonEdit_Game_path.TabIndex = 1;
            buttonEdit_Game_path.ButtonClick += buttonEdit_Game_path_ButtonClick;
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(simpleButton_Stop);
            groupControl2.Controls.Add(labelControl8);
            groupControl2.Controls.Add(simpleButton_Out);
            groupControl2.Controls.Add(radioButton_usm_path);
            groupControl2.Controls.Add(radioButton_Game_path);
            groupControl2.Controls.Add(radioButton_KR);
            groupControl2.Controls.Add(radioButton_JP);
            groupControl2.Controls.Add(radioButton_EN);
            groupControl2.Controls.Add(radioButton_CN);
            groupControl2.Controls.Add(labelControl7);
            groupControl2.Controls.Add(buttonEdit_usm_Name);
            groupControl2.Location = new System.Drawing.Point(45, 392);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new System.Drawing.Size(527, 292);
            groupControl2.TabIndex = 0;
            groupControl2.Text = "导出选项";
            // 
            // simpleButton_Stop
            // 
            simpleButton_Stop.Location = new System.Drawing.Point(398, 228);
            simpleButton_Stop.Name = "simpleButton_Stop";
            simpleButton_Stop.Size = new System.Drawing.Size(75, 23);
            simpleButton_Stop.TabIndex = 4;
            simpleButton_Stop.Text = "复位停止";
            simpleButton_Stop.Click += simpleButton_Stop_Click;
            // 
            // labelControl8
            // 
            labelControl8.Location = new System.Drawing.Point(295, 161);
            labelControl8.Name = "labelControl8";
            labelControl8.Size = new System.Drawing.Size(191, 14);
            labelControl8.TabIndex = 0;
            labelControl8.Text = "* 游戏和自定义目录，导出为多音轨";
            // 
            // simpleButton_Out
            // 
            simpleButton_Out.Appearance.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            simpleButton_Out.Appearance.Options.UseFont = true;
            simpleButton_Out.Location = new System.Drawing.Point(65, 201);
            simpleButton_Out.Name = "simpleButton_Out";
            simpleButton_Out.Size = new System.Drawing.Size(285, 50);
            simpleButton_Out.TabIndex = 3;
            simpleButton_Out.Text = "国语配音";
            simpleButton_Out.Click += simpleButton_Out_Click;
            // 
            // radioButton_usm_path
            // 
            radioButton_usm_path.AutoSize = true;
            radioButton_usm_path.Location = new System.Drawing.Point(171, 159);
            radioButton_usm_path.Name = "radioButton_usm_path";
            radioButton_usm_path.Size = new System.Drawing.Size(109, 18);
            radioButton_usm_path.TabIndex = 2;
            radioButton_usm_path.Text = "自定义目录导出";
            radioButton_usm_path.UseVisualStyleBackColor = true;
            radioButton_usm_path.CheckedChanged += radioButton_usm_path_CheckedChanged;
            // 
            // radioButton_Game_path
            // 
            radioButton_Game_path.AutoSize = true;
            radioButton_Game_path.Location = new System.Drawing.Point(48, 159);
            radioButton_Game_path.Name = "radioButton_Game_path";
            radioButton_Game_path.Size = new System.Drawing.Size(97, 18);
            radioButton_Game_path.TabIndex = 2;
            radioButton_Game_path.Text = "游戏目录导出";
            radioButton_Game_path.UseVisualStyleBackColor = true;
            radioButton_Game_path.CheckedChanged += radioButton_Game_path_CheckedChanged;
            // 
            // radioButton_KR
            // 
            radioButton_KR.AutoSize = true;
            radioButton_KR.Location = new System.Drawing.Point(418, 117);
            radioButton_KR.Name = "radioButton_KR";
            radioButton_KR.Size = new System.Drawing.Size(55, 18);
            radioButton_KR.TabIndex = 2;
            radioButton_KR.Text = "한국어";
            radioButton_KR.UseVisualStyleBackColor = true;
            radioButton_KR.CheckedChanged += radioButton_KR_CheckedChanged;
            // 
            // radioButton_JP
            // 
            radioButton_JP.AutoSize = true;
            radioButton_JP.Location = new System.Drawing.Point(295, 117);
            radioButton_JP.Name = "radioButton_JP";
            radioButton_JP.Size = new System.Drawing.Size(61, 18);
            radioButton_JP.TabIndex = 2;
            radioButton_JP.Text = "日本語";
            radioButton_JP.UseVisualStyleBackColor = true;
            radioButton_JP.CheckedChanged += radioButton_JP_CheckedChanged;
            // 
            // radioButton_EN
            // 
            radioButton_EN.AutoSize = true;
            radioButton_EN.Location = new System.Drawing.Point(171, 117);
            radioButton_EN.Name = "radioButton_EN";
            radioButton_EN.Size = new System.Drawing.Size(62, 18);
            radioButton_EN.TabIndex = 2;
            radioButton_EN.Text = "English";
            radioButton_EN.UseVisualStyleBackColor = true;
            radioButton_EN.CheckedChanged += radioButton_EN_CheckedChanged;
            // 
            // radioButton_CN
            // 
            radioButton_CN.AutoSize = true;
            radioButton_CN.Checked = true;
            radioButton_CN.Location = new System.Drawing.Point(48, 117);
            radioButton_CN.Name = "radioButton_CN";
            radioButton_CN.Size = new System.Drawing.Size(61, 18);
            radioButton_CN.TabIndex = 2;
            radioButton_CN.TabStop = true;
            radioButton_CN.Text = "普通话";
            radioButton_CN.UseVisualStyleBackColor = true;
            radioButton_CN.CheckedChanged += radioButton_CN_CheckedChanged;
            // 
            // labelControl7
            // 
            labelControl7.Location = new System.Drawing.Point(48, 63);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new System.Drawing.Size(82, 14);
            labelControl7.TabIndex = 0;
            labelControl7.Text = "游戏内usm文件";
            // 
            // buttonEdit_usm_Name
            // 
            buttonEdit_usm_Name.Location = new System.Drawing.Point(136, 56);
            buttonEdit_usm_Name.Name = "buttonEdit_usm_Name";
            buttonEdit_usm_Name.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            buttonEdit_usm_Name.Properties.ReadOnly = true;
            buttonEdit_usm_Name.Size = new System.Drawing.Size(338, 28);
            buttonEdit_usm_Name.TabIndex = 1;
            buttonEdit_usm_Name.ButtonClick += buttonEdit_usm_Name_ButtonClick;
            // 
            // memoEdit_out
            // 
            memoEdit_out.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            memoEdit_out.Location = new System.Drawing.Point(604, 52);
            memoEdit_out.Name = "memoEdit_out";
            memoEdit_out.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            memoEdit_out.Properties.Appearance.Options.UseBackColor = true;
            memoEdit_out.Properties.ReadOnly = true;
            memoEdit_out.Size = new System.Drawing.Size(637, 632);
            memoEdit_out.TabIndex = 1;
            // 
            // Genshin_usm
            // 
            Appearance.BackColor = System.Drawing.SystemColors.Control;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(memoEdit_out);
            Controls.Add(groupControl2);
            Controls.Add(groupControl1);
            Name = "Genshin_usm";
            Size = new System.Drawing.Size(1305, 721);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FFmpeg_path.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Gutscenes_path.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_Out_path.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_usm_path.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_Game_path.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)buttonEdit_usm_Name.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_out.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit FFmpeg_path;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit Gutscenes_path;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Out_path;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_usm_path;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Game_path;
        private System.Windows.Forms.RadioButton radioButton_CN;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_usm_Name;
        private System.Windows.Forms.RadioButton radioButton_usm_path;
        private System.Windows.Forms.RadioButton radioButton_Game_path;
        private System.Windows.Forms.RadioButton radioButton_KR;
        private System.Windows.Forms.RadioButton radioButton_JP;
        private System.Windows.Forms.RadioButton radioButton_EN;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Stop;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Out;
        private DevExpress.XtraEditors.MemoEdit memoEdit_out;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Game_path;
    }
}
