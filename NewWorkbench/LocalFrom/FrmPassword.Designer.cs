namespace NewWorkbench.LocalFrom
{
    partial class FrmPassword
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
            this.btn_check = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_password_D = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(175, 66);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(122, 21);
            this.btn_check.TabIndex = 0;
            this.btn_check.Text = "Check";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(12, 12);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(451, 21);
            this.txt_password.TabIndex = 1;
            // 
            // txt_password_D
            // 
            this.txt_password_D.Location = new System.Drawing.Point(12, 39);
            this.txt_password_D.Name = "txt_password_D";
            this.txt_password_D.Size = new System.Drawing.Size(451, 21);
            this.txt_password_D.TabIndex = 2;
            // 
            // FrmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 94);
            this.Controls.Add(this.txt_password_D);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.btn_check);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPassword";
            this.Text = "FrmPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_password_D;
    }
}