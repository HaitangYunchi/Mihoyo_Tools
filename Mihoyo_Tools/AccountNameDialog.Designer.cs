namespace Mihoyo_Tools
{
    partial class AccountNameDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountNameDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAcctName = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCance = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入当前登录账号的备注：";
            // 
            // txtAcctName
            // 
            this.txtAcctName.Location = new System.Drawing.Point(37, 61);
            this.txtAcctName.Name = "txtAcctName";
            this.txtAcctName.Size = new System.Drawing.Size(230, 20);
            this.txtAcctName.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(55, 99);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "保存";
            // 
            // btnCance
            // 
            this.btnCance.Location = new System.Drawing.Point(156, 99);
            this.btnCance.Name = "btnCance";
            this.btnCance.Size = new System.Drawing.Size(75, 23);
            this.btnCance.TabIndex = 7;
            this.btnCance.Text = "取消";
            // 
            // AccountNameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 171);
            this.ControlBox = false;
            this.Controls.Add(this.btnCance);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAcctName);
            this.Controls.Add(this.label1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("AccountNameDialog.IconOptions.Image")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountNameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保存账号";
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtAcctName;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCance;
    }
}