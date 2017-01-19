namespace NewWorkbench.LocalFrom
{
    partial class FrmPinyin
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
            this.btn_checkPinyin = new System.Windows.Forms.Button();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_Pinyin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Pinyin_first = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_checkPinyin
            // 
            this.btn_checkPinyin.Location = new System.Drawing.Point(162, 100);
            this.btn_checkPinyin.Name = "btn_checkPinyin";
            this.btn_checkPinyin.Size = new System.Drawing.Size(75, 23);
            this.btn_checkPinyin.TabIndex = 0;
            this.btn_checkPinyin.Text = "Check";
            this.btn_checkPinyin.UseVisualStyleBackColor = true;
            this.btn_checkPinyin.Click += new System.EventHandler(this.btn_checkPinyin_Click);
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(114, 12);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(289, 21);
            this.txt_UserName.TabIndex = 1;
            // 
            // txt_Pinyin
            // 
            this.txt_Pinyin.Location = new System.Drawing.Point(114, 39);
            this.txt_Pinyin.Name = "txt_Pinyin";
            this.txt_Pinyin.Size = new System.Drawing.Size(289, 21);
            this.txt_Pinyin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pinyin";
            // 
            // txt_Pinyin_first
            // 
            this.txt_Pinyin_first.Location = new System.Drawing.Point(114, 68);
            this.txt_Pinyin_first.Name = "txt_Pinyin_first";
            this.txt_Pinyin_first.Size = new System.Drawing.Size(289, 21);
            this.txt_Pinyin_first.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pinyin first";
            // 
            // FrmPinyin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 135);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Pinyin_first);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Pinyin);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.btn_checkPinyin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPinyin";
            this.Text = "FrmPinyin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_checkPinyin;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_Pinyin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Pinyin_first;
        private System.Windows.Forms.Label label3;
    }
}