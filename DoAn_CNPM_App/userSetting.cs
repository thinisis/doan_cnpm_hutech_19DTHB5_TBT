using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNPM_App
{
    public partial class userSettingForm : Form
    {
        public userSettingForm()
        {
            InitializeComponent();
        }

        private void btn_accountSetting_Click(object sender, EventArgs e)
        {
            page_Ctrl.SetPage("accountSetting", false);
        }

        private void btn_userSetting_Click(object sender, EventArgs e)
        {
            page_Ctrl.SetPage("userSetting", false);
        }
    }
}
