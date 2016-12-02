using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewWorkbench.CommonLibrary;

namespace NewWorkbench.LocalFrom
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btn_CheckUser_Click(object sender, EventArgs e)
        {
            FrmPassword newfrom = new FrmPassword();
            newfrom.Show();
        }
    }
}
