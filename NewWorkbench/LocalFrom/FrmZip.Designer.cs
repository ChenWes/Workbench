namespace NewWorkbench.LocalFrom
{
    partial class FrmZip
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
            this.btn_zipFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_zipFolder = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_unzip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_zipFile
            // 
            this.btn_zipFile.Location = new System.Drawing.Point(12, 12);
            this.btn_zipFile.Name = "btn_zipFile";
            this.btn_zipFile.Size = new System.Drawing.Size(75, 23);
            this.btn_zipFile.TabIndex = 0;
            this.btn_zipFile.Text = "Zip File";
            this.btn_zipFile.UseVisualStyleBackColor = true;
            this.btn_zipFile.Click += new System.EventHandler(this.btn_zipFile_Click);
            // 
            // btn_zipFolder
            // 
            this.btn_zipFolder.Location = new System.Drawing.Point(109, 12);
            this.btn_zipFolder.Name = "btn_zipFolder";
            this.btn_zipFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_zipFolder.TabIndex = 1;
            this.btn_zipFolder.Text = "Zip Folder";
            this.btn_zipFolder.UseVisualStyleBackColor = true;
            this.btn_zipFolder.Click += new System.EventHandler(this.btn_zipFolder_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btn_unzip
            // 
            this.btn_unzip.Location = new System.Drawing.Point(202, 12);
            this.btn_unzip.Name = "btn_unzip";
            this.btn_unzip.Size = new System.Drawing.Size(75, 23);
            this.btn_unzip.TabIndex = 2;
            this.btn_unzip.Text = "Unzip";
            this.btn_unzip.UseVisualStyleBackColor = true;
            this.btn_unzip.Click += new System.EventHandler(this.btn_unzip_Click);
            // 
            // FrmZip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 71);
            this.Controls.Add(this.btn_unzip);
            this.Controls.Add(this.btn_zipFolder);
            this.Controls.Add(this.btn_zipFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmZip";
            this.Text = "FrmFileHelp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_zipFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btn_zipFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_unzip;
    }
}