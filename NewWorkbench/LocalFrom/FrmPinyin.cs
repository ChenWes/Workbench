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
    public partial class FrmPinyin : Form
    {
        public FrmPinyin()
        {
            InitializeComponent();
        }

        private void btn_checkPinyin_Click(object sender, EventArgs e)
        {
            txt_Pinyin.Text = CommonLibrary.StringHelper.ConvertHzToPz.Convert(txt_UserName.Text.Trim());

            txt_Pinyin_first.Text = CommonLibrary.StringHelper.ConvertHzToPz.ConvertFirst(txt_UserName.Text.Trim());
        }
    }
}
