namespace NewWorkbench.LocalFrom
{
    partial class FrmMain
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
            this.btn_CheckUser = new System.Windows.Forms.Button();
            this.btn_checkPinYin = new System.Windows.Forms.Button();
            this.btn_zip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CheckUser
            // 
            this.btn_CheckUser.Location = new System.Drawing.Point(12, 12);
            this.btn_CheckUser.Name = "btn_CheckUser";
            this.btn_CheckUser.Size = new System.Drawing.Size(75, 23);
            this.btn_CheckUser.TabIndex = 0;
            this.btn_CheckUser.Text = "Password";
            this.btn_CheckUser.UseVisualStyleBackColor = true;
            this.btn_CheckUser.Click += new System.EventHandler(this.btn_CheckUser_Click);
            // 
            // btn_checkPinYin
            // 
            this.btn_checkPinYin.Location = new System.Drawing.Point(12, 41);
            this.btn_checkPinYin.Name = "btn_checkPinYin";
            this.btn_checkPinYin.Size = new System.Drawing.Size(75, 23);
            this.btn_checkPinYin.TabIndex = 0;
            this.btn_checkPinYin.Text = "Pinyin";
            this.btn_checkPinYin.UseVisualStyleBackColor = true;
            this.btn_checkPinYin.Click += new System.EventHandler(this.btn_checkPinYin_Click);
            // 
            // btn_zip
            // 
            this.btn_zip.Location = new System.Drawing.Point(12, 70);
            this.btn_zip.Name = "btn_zip";
            this.btn_zip.Size = new System.Drawing.Size(75, 23);
            this.btn_zip.TabIndex = 1;
            this.btn_zip.Text = "Zip";
            this.btn_zip.UseVisualStyleBackColor = true;
            this.btn_zip.Click += new System.EventHandler(this.btn_zip_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 447);
            this.Controls.Add(this.btn_zip);
            this.Controls.Add(this.btn_checkPinYin);
            this.Controls.Add(this.btn_CheckUser);
            this.Name = "FrmMain";
            this.Text = "NewWorkbench";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CheckUser;
        private System.Windows.Forms.Button btn_checkPinYin;
        private System.Windows.Forms.Button btn_zip;
    }
}

