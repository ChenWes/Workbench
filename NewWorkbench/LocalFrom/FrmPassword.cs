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
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            txt_password_D.Text = new CommonLibrary.AESCrypt().Encrypt(txt_password.Text.Trim());

            txt_pass.Text = new CommonLibrary.DESCrypt().Encrypt(txt_password.Text.Trim());


            
        }
    }
}
