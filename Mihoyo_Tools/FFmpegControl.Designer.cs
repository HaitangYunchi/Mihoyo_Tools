namespace Mihoyo_Tools
{
    partial class FFmpegControl
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
            components = new System.ComponentModel.Container();
            tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            tabPageConvert = new DevExpress.XtraTab.XtraTabPage();
            groupControlFiles = new DevExpress.XtraEditors.GroupControl();
            StopButton = new DevExpress.XtraEditors.SimpleButton();
            btnClearFiles = new DevExpress.XtraEditors.SimpleButton();
            btnConvert = new DevExpress.XtraEditors.SimpleButton();
            btnRemoveFile = new DevExpress.XtraEditors.SimpleButton();
            btnAddFiles = new DevExpress.XtraEditors.SimpleButton();
            lstFiles = new DevExpress.XtraEditors.ListBoxControl();
            groupControlSettings = new DevExpress.XtraEditors.GroupControl();
            labelControlArgs = new DevExpress.XtraEditors.LabelControl();
            cboBitrate = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlBitrate = new DevExpress.XtraEditors.LabelControl();
            cboResolution = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlResolution = new DevExpress.XtraEditors.LabelControl();
            cboVideoCodec = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControlCodec = new DevExpress.XtraEditors.LabelControl();
            fps = new DevExpress.XtraEditors.ComboBoxEdit();
            groupControlPreset = new DevExpress.XtraEditors.GroupControl();
            cboPreset = new DevExpress.XtraEditors.ComboBoxEdit();
            btnPresetManage = new DevExpress.XtraEditors.SimpleButton();
            btnPresetSave = new DevExpress.XtraEditors.SimpleButton();
            txtPresetName = new DevExpress.XtraEditors.TextEdit();
            labelControlPresetName = new DevExpress.XtraEditors.LabelControl();
            labelControlPreset = new DevExpress.XtraEditors.LabelControl();
            groupControlFFmpeg = new DevExpress.XtraEditors.GroupControl();
            txtFFmpegPath = new DevExpress.XtraEditors.TextEdit();
            labelControlFFmpegPath = new DevExpress.XtraEditors.LabelControl();
            tabPageInfo = new DevExpress.XtraTab.XtraTabPage();
            txtVideoInfo = new DevExpress.XtraEditors.MemoEdit();
            btnAnalyze = new DevExpress.XtraEditors.SimpleButton();
            tabPageLog = new DevExpress.XtraTab.XtraTabPage();
            txtLog = new DevExpress.XtraEditors.MemoEdit();
            progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            ((System.ComponentModel.ISupportInitialize)tabControlMain).BeginInit();
            tabControlMain.SuspendLayout();
            tabPageConvert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControlFiles).BeginInit();
            groupControlFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lstFiles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlSettings).BeginInit();
            groupControlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboBitrate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboResolution.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboVideoCodec.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fps.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPreset).BeginInit();
            groupControlPreset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboPreset.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPresetName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControlFFmpeg).BeginInit();
            groupControlFFmpeg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFFmpegPath.Properties).BeginInit();
            tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtVideoInfo.Properties).BeginInit();
            tabPageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtLog.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)progressBar.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControlMain.Location = new System.Drawing.Point(12, 13);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedTabPage = tabPageConvert;
            tabControlMain.Size = new System.Drawing.Size(1168, 635);
            tabControlMain.TabIndex = 0;
            tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { tabPageConvert, tabPageInfo, tabPageLog });
            // 
            // tabPageConvert
            // 
            tabPageConvert.Controls.Add(groupControlFiles);
            tabPageConvert.Controls.Add(groupControlSettings);
            tabPageConvert.Controls.Add(groupControlPreset);
            tabPageConvert.Controls.Add(groupControlFFmpeg);
            tabPageConvert.Name = "tabPageConvert";
            tabPageConvert.Size = new System.Drawing.Size(1166, 604);
            tabPageConvert.Text = "转换设置";
            // 
            // groupControlFiles
            // 
            groupControlFiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupControlFiles.Controls.Add(StopButton);
            groupControlFiles.Controls.Add(btnClearFiles);
            groupControlFiles.Controls.Add(btnConvert);
            groupControlFiles.Controls.Add(btnRemoveFile);
            groupControlFiles.Controls.Add(btnAddFiles);
            groupControlFiles.Controls.Add(lstFiles);
            groupControlFiles.Location = new System.Drawing.Point(11, 244);
            groupControlFiles.Name = "groupControlFiles";
            groupControlFiles.Size = new System.Drawing.Size(1142, 348);
            groupControlFiles.TabIndex = 3;
            groupControlFiles.Text = "文件列表";
            // 
            // StopButton
            // 
            StopButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            StopButton.Location = new System.Drawing.Point(1032, 305);
            StopButton.Name = "StopButton";
            StopButton.Size = new System.Drawing.Size(94, 29);
            StopButton.TabIndex = 2;
            StopButton.Text = "停止";
            StopButton.Click += StopButton_Click;
            // 
            // btnClearFiles
            // 
            btnClearFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnClearFiles.Location = new System.Drawing.Point(212, 305);
            btnClearFiles.Name = "btnClearFiles";
            btnClearFiles.Size = new System.Drawing.Size(94, 29);
            btnClearFiles.TabIndex = 3;
            btnClearFiles.Text = "清空";
            // 
            // btnConvert
            // 
            btnConvert.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnConvert.Location = new System.Drawing.Point(927, 305);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(94, 29);
            btnConvert.TabIndex = 2;
            btnConvert.Text = "开始转换";
            // 
            // btnRemoveFile
            // 
            btnRemoveFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnRemoveFile.Location = new System.Drawing.Point(112, 305);
            btnRemoveFile.Name = "btnRemoveFile";
            btnRemoveFile.Size = new System.Drawing.Size(94, 29);
            btnRemoveFile.TabIndex = 2;
            btnRemoveFile.Text = "移除";
            // 
            // btnAddFiles
            // 
            btnAddFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnAddFiles.Location = new System.Drawing.Point(12, 305);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new System.Drawing.Size(94, 29);
            btnAddFiles.TabIndex = 1;
            btnAddFiles.Text = "添加文件";
            // 
            // lstFiles
            // 
            lstFiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lstFiles.Location = new System.Drawing.Point(12, 46);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new System.Drawing.Size(1114, 242);
            lstFiles.TabIndex = 0;
            // 
            // groupControlSettings
            // 
            groupControlSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupControlSettings.Controls.Add(labelControlArgs);
            groupControlSettings.Controls.Add(cboBitrate);
            groupControlSettings.Controls.Add(labelControlBitrate);
            groupControlSettings.Controls.Add(cboResolution);
            groupControlSettings.Controls.Add(labelControlResolution);
            groupControlSettings.Controls.Add(cboVideoCodec);
            groupControlSettings.Controls.Add(labelControlCodec);
            groupControlSettings.Controls.Add(fps);
            groupControlSettings.Location = new System.Drawing.Point(649, 12);
            groupControlSettings.Name = "groupControlSettings";
            groupControlSettings.Size = new System.Drawing.Size(505, 207);
            groupControlSettings.TabIndex = 2;
            groupControlSettings.Text = "缩放/帧率";
            // 
            // labelControlArgs
            // 
            labelControlArgs.Location = new System.Drawing.Point(47, 160);
            labelControlArgs.Name = "labelControlArgs";
            labelControlArgs.Size = new System.Drawing.Size(52, 14);
            labelControlArgs.TabIndex = 6;
            labelControlArgs.Text = "视频帧率:";
            // 
            // cboBitrate
            // 
            cboBitrate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cboBitrate.Location = new System.Drawing.Point(137, 118);
            cboBitrate.Name = "cboBitrate";
            cboBitrate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cboBitrate.Size = new System.Drawing.Size(313, 28);
            cboBitrate.TabIndex = 5;
            // 
            // labelControlBitrate
            // 
            labelControlBitrate.Location = new System.Drawing.Point(47, 125);
            labelControlBitrate.Name = "labelControlBitrate";
            labelControlBitrate.Size = new System.Drawing.Size(52, 14);
            labelControlBitrate.TabIndex = 4;
            labelControlBitrate.Text = "质量模式:";
            // 
            // cboResolution
            // 
            cboResolution.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cboResolution.Location = new System.Drawing.Point(137, 83);
            cboResolution.Name = "cboResolution";
            cboResolution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cboResolution.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboResolution.Size = new System.Drawing.Size(313, 28);
            cboResolution.TabIndex = 3;
            // 
            // labelControlResolution
            // 
            labelControlResolution.Location = new System.Drawing.Point(59, 90);
            labelControlResolution.Name = "labelControlResolution";
            labelControlResolution.Size = new System.Drawing.Size(40, 14);
            labelControlResolution.TabIndex = 2;
            labelControlResolution.Text = "分辨率:";
            // 
            // cboVideoCodec
            // 
            cboVideoCodec.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cboVideoCodec.Location = new System.Drawing.Point(137, 48);
            cboVideoCodec.Name = "cboVideoCodec";
            cboVideoCodec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cboVideoCodec.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboVideoCodec.Size = new System.Drawing.Size(313, 28);
            cboVideoCodec.TabIndex = 1;
            // 
            // labelControlCodec
            // 
            labelControlCodec.Location = new System.Drawing.Point(47, 55);
            labelControlCodec.Name = "labelControlCodec";
            labelControlCodec.Size = new System.Drawing.Size(52, 14);
            labelControlCodec.TabIndex = 0;
            labelControlCodec.Text = "视频编码:";
            // 
            // fps
            // 
            fps.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fps.Location = new System.Drawing.Point(137, 153);
            fps.Name = "fps";
            fps.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            fps.Size = new System.Drawing.Size(313, 28);
            fps.TabIndex = 7;
            // 
            // groupControlPreset
            // 
            groupControlPreset.Controls.Add(cboPreset);
            groupControlPreset.Controls.Add(btnPresetManage);
            groupControlPreset.Controls.Add(btnPresetSave);
            groupControlPreset.Controls.Add(txtPresetName);
            groupControlPreset.Controls.Add(labelControlPresetName);
            groupControlPreset.Controls.Add(labelControlPreset);
            groupControlPreset.Location = new System.Drawing.Point(12, 12);
            groupControlPreset.Name = "groupControlPreset";
            groupControlPreset.Size = new System.Drawing.Size(607, 207);
            groupControlPreset.TabIndex = 1;
            groupControlPreset.Text = "预设管理";
            // 
            // cboPreset
            // 
            cboPreset.Location = new System.Drawing.Point(88, 76);
            cboPreset.Name = "cboPreset";
            cboPreset.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cboPreset.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboPreset.Size = new System.Drawing.Size(368, 28);
            cboPreset.TabIndex = 5;
            cboPreset.SelectedIndexChanged += cboPreset_SelectedIndexChanged;
            // 
            // btnPresetManage
            // 
            btnPresetManage.Location = new System.Drawing.Point(486, 83);
            btnPresetManage.Name = "btnPresetManage";
            btnPresetManage.Size = new System.Drawing.Size(80, 23);
            btnPresetManage.TabIndex = 4;
            btnPresetManage.Text = "管理";
            // 
            // btnPresetSave
            // 
            btnPresetSave.Location = new System.Drawing.Point(486, 123);
            btnPresetSave.Name = "btnPresetSave";
            btnPresetSave.Size = new System.Drawing.Size(80, 23);
            btnPresetSave.TabIndex = 3;
            btnPresetSave.Text = "保存";
            // 
            // txtPresetName
            // 
            txtPresetName.Location = new System.Drawing.Point(88, 117);
            txtPresetName.Name = "txtPresetName";
            txtPresetName.Size = new System.Drawing.Size(368, 28);
            txtPresetName.TabIndex = 2;
            // 
            // labelControlPresetName
            // 
            labelControlPresetName.Location = new System.Drawing.Point(23, 125);
            labelControlPresetName.Name = "labelControlPresetName";
            labelControlPresetName.Size = new System.Drawing.Size(52, 14);
            labelControlPresetName.TabIndex = 1;
            labelControlPresetName.Text = "预设名称:";
            // 
            // labelControlPreset
            // 
            labelControlPreset.Location = new System.Drawing.Point(47, 81);
            labelControlPreset.Name = "labelControlPreset";
            labelControlPreset.Size = new System.Drawing.Size(28, 14);
            labelControlPreset.TabIndex = 0;
            labelControlPreset.Text = "预设:";
            // 
            // groupControlFFmpeg
            // 
            groupControlFFmpeg.Controls.Add(txtFFmpegPath);
            groupControlFFmpeg.Controls.Add(labelControlFFmpegPath);
            groupControlFFmpeg.Location = new System.Drawing.Point(12, 12);
            groupControlFFmpeg.Name = "groupControlFFmpeg";
            groupControlFFmpeg.Size = new System.Drawing.Size(607, 89);
            groupControlFFmpeg.TabIndex = 0;
            groupControlFFmpeg.Text = "FFmpeg路径";
            groupControlFFmpeg.Visible = false;
            // 
            // txtFFmpegPath
            // 
            txtFFmpegPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFFmpegPath.Location = new System.Drawing.Point(88, 45);
            txtFFmpegPath.Name = "txtFFmpegPath";
            txtFFmpegPath.Properties.ReadOnly = true;
            txtFFmpegPath.Size = new System.Drawing.Size(508, 28);
            txtFFmpegPath.TabIndex = 1;
            // 
            // labelControlFFmpegPath
            // 
            labelControlFFmpegPath.Location = new System.Drawing.Point(11, 52);
            labelControlFFmpegPath.Name = "labelControlFFmpegPath";
            labelControlFFmpegPath.Size = new System.Drawing.Size(71, 14);
            labelControlFFmpegPath.TabIndex = 0;
            labelControlFFmpegPath.Text = "FFmpeg路径:";
            // 
            // tabPageInfo
            // 
            tabPageInfo.Controls.Add(txtVideoInfo);
            tabPageInfo.Controls.Add(btnAnalyze);
            tabPageInfo.Name = "tabPageInfo";
            tabPageInfo.Size = new System.Drawing.Size(1166, 604);
            tabPageInfo.Text = "视频信息";
            // 
            // txtVideoInfo
            // 
            txtVideoInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtVideoInfo.Location = new System.Drawing.Point(12, 50);
            txtVideoInfo.Name = "txtVideoInfo";
            txtVideoInfo.Properties.ReadOnly = true;
            txtVideoInfo.Size = new System.Drawing.Size(1142, 542);
            txtVideoInfo.TabIndex = 1;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new System.Drawing.Point(12, 12);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new System.Drawing.Size(120, 29);
            btnAnalyze.TabIndex = 0;
            btnAnalyze.Text = "分析视频";
            // 
            // tabPageLog
            // 
            tabPageLog.Controls.Add(txtLog);
            tabPageLog.Name = "tabPageLog";
            tabPageLog.Size = new System.Drawing.Size(1166, 609);
            tabPageLog.Text = "日志";
            // 
            // txtLog
            // 
            txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            txtLog.Location = new System.Drawing.Point(0, 0);
            txtLog.Name = "txtLog";
            txtLog.Properties.ReadOnly = true;
            txtLog.Size = new System.Drawing.Size(1166, 609);
            txtLog.TabIndex = 0;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(12, 664);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(1169, 18);
            progressBar.TabIndex = 1;
            // 
            // FFmpegControl
            // 
            Controls.Add(progressBar);
            Controls.Add(tabControlMain);
            Name = "FFmpegControl";
            Size = new System.Drawing.Size(1196, 700);
            ((System.ComponentModel.ISupportInitialize)tabControlMain).EndInit();
            tabControlMain.ResumeLayout(false);
            tabPageConvert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControlFiles).EndInit();
            groupControlFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lstFiles).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlSettings).EndInit();
            groupControlSettings.ResumeLayout(false);
            groupControlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboBitrate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboResolution.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboVideoCodec.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)fps.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlPreset).EndInit();
            groupControlPreset.ResumeLayout(false);
            groupControlPreset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboPreset.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPresetName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControlFFmpeg).EndInit();
            groupControlFFmpeg.ResumeLayout(false);
            groupControlFFmpeg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtFFmpegPath.Properties).EndInit();
            tabPageInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtVideoInfo.Properties).EndInit();
            tabPageLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtLog.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)progressBar.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ResumeLayout(false);

        }

        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.XtraTab.XtraTabPage tabPageConvert;
        private DevExpress.XtraTab.XtraTabPage tabPageInfo;
        private DevExpress.XtraTab.XtraTabPage tabPageLog;
        private DevExpress.XtraEditors.GroupControl groupControlFiles;
        private DevExpress.XtraEditors.ListBoxControl lstFiles;
        private DevExpress.XtraEditors.SimpleButton btnAddFiles;
        private DevExpress.XtraEditors.SimpleButton btnRemoveFile;
        private DevExpress.XtraEditors.SimpleButton btnClearFiles;
        private DevExpress.XtraEditors.GroupControl groupControlSettings;
        private DevExpress.XtraEditors.ComboBoxEdit cboVideoCodec;
        private DevExpress.XtraEditors.LabelControl labelControlCodec;
        private DevExpress.XtraEditors.ComboBoxEdit cboResolution;
        private DevExpress.XtraEditors.LabelControl labelControlResolution;
        private DevExpress.XtraEditors.ComboBoxEdit cboBitrate;
        private DevExpress.XtraEditors.LabelControl labelControlBitrate;
        private DevExpress.XtraEditors.LabelControl labelControlArgs;
        private DevExpress.XtraEditors.GroupControl groupControlPreset;
        private DevExpress.XtraEditors.ComboBoxEdit cboPreset;
        private DevExpress.XtraEditors.LabelControl labelControlPreset;
        private DevExpress.XtraEditors.TextEdit txtPresetName;
        private DevExpress.XtraEditors.LabelControl labelControlPresetName;
        private DevExpress.XtraEditors.SimpleButton btnPresetSave;
        private DevExpress.XtraEditors.SimpleButton btnPresetManage;
        private DevExpress.XtraEditors.GroupControl groupControlFFmpeg;
        private DevExpress.XtraEditors.TextEdit txtFFmpegPath;
        private DevExpress.XtraEditors.LabelControl labelControlFFmpegPath;
        private DevExpress.XtraEditors.MemoEdit txtVideoInfo;
        private DevExpress.XtraEditors.SimpleButton btnAnalyze;
        private DevExpress.XtraEditors.MemoEdit txtLog;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private DevExpress.XtraEditors.SimpleButton btnConvert;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.ComboBoxEdit fps;
        private DevExpress.XtraEditors.SimpleButton StopButton;
    }
}
