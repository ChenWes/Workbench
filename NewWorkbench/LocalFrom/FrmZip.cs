using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NewWorkbench.LocalFrom
{
    public partial class FrmZip : Form
    {
        public FrmZip()
        {
            InitializeComponent();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        private void btn_zipFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string pi_file = openFileDialog.FileName;
                    NewWorkbench.CommonLibrary.ZipHelper.ZipFile(pi_file, "d:\\", "test1", 5, 2048, true);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btn_zipFolder_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string pi_path = folderBrowserDialog.SelectedPath;
                    NewWorkbench.CommonLibrary.ZipHelper.ZipDirectory(pi_path,"D:\\", "test", true);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btn_unzip_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string pi_file = openFileDialog.FileName;
                    NewWorkbench.CommonLibrary.ZipHelper.UnZip(pi_file, "d:\\test1", "123", true);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
