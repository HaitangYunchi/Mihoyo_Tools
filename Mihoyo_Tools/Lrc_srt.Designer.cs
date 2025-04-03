namespace Mihoyo_Tools
{
    partial class Lrc_srt
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
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            txtLRCFilePath = new DevExpress.XtraEditors.ButtonEdit();
            memoEdit_Lrc = new DevExpress.XtraEditors.MemoEdit();
            memoEdit_str = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)txtLRCFilePath.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_Lrc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_str.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(106, 81);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(96, 14);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "选择 Lrc 歌词文件";
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(1056, 127);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(116, 23);
            simpleButton1.TabIndex = 2;
            simpleButton1.Text = "转换到SRT字幕";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // txtLRCFilePath
            // 
            txtLRCFilePath.Location = new System.Drawing.Point(106, 124);
            txtLRCFilePath.Name = "txtLRCFilePath";
            txtLRCFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            txtLRCFilePath.Size = new System.Drawing.Size(924, 28);
            txtLRCFilePath.TabIndex = 1;
            txtLRCFilePath.ButtonClick += txtLRCFilePath_ButtonClick;
            // 
            // memoEdit_Lrc
            // 
            memoEdit_Lrc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            memoEdit_Lrc.Location = new System.Drawing.Point(106, 193);
            memoEdit_Lrc.Name = "memoEdit_Lrc";
            memoEdit_Lrc.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            memoEdit_Lrc.Properties.Appearance.Options.UseBackColor = true;
            memoEdit_Lrc.Properties.ReadOnly = true;
            memoEdit_Lrc.Size = new System.Drawing.Size(503, 458);
            memoEdit_Lrc.TabIndex = 4;
            // 
            // memoEdit_str
            // 
            memoEdit_str.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            memoEdit_str.Location = new System.Drawing.Point(669, 193);
            memoEdit_str.Name = "memoEdit_str";
            memoEdit_str.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            memoEdit_str.Properties.Appearance.Options.UseBackColor = true;
            memoEdit_str.Properties.ReadOnly = true;
            memoEdit_str.Size = new System.Drawing.Size(503, 458);
            memoEdit_str.TabIndex = 4;
            // 
            // Lrc_srt
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(memoEdit_str);
            Controls.Add(memoEdit_Lrc);
            Controls.Add(simpleButton1);
            Controls.Add(labelControl1);
            Controls.Add(txtLRCFilePath);
            Name = "Lrc_srt";
            Size = new System.Drawing.Size(1271, 716);
            ((System.ComponentModel.ISupportInitialize)txtLRCFilePath.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_Lrc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_str.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ButtonEdit txtLRCFilePath;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Lrc;
        private DevExpress.XtraEditors.MemoEdit memoEdit_str;
    }
}
