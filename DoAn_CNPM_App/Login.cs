using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNPM_App
{
    public partial class Login : Form
    {
        EntityFramework dbContext = new EntityFramework();
        public Login()
        {
            InitializeComponent();
        }


        private void btn_Login_Click(object sender, EventArgs e)
        {
            string userid = txt_Account.Text;
            string password = txt_Pwd.Text;
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == userid && a.password == password);
            if (acc != null)
            {
                MessageBox.Show(this, "Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                if (ckbx_RememberPwd.Checked == true)
                {
                    Properties.Settings.Default.Username = txt_Account.Text;
                    Properties.Settings.Default.Password = txt_Pwd.Text;
                    Properties.Settings.Default.Checked = true;
                    Properties.Settings.Default.Save();
                }
                if (ckbx_RememberPwd.Checked == false)
                {
                    Properties.Settings.Default.Username = txt_Account.Text;
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Checked = false;
                    Properties.Settings.Default.Save();
                }
                MainForm f = new MainForm();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show(this, "Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ckbx_RememberPwd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_Login;
            txt_Account.Text = Properties.Settings.Default.Username;
            txt_Pwd.Text = Properties.Settings.Default.Password;
            if (Properties.Settings.Default.Checked == true)
            {
                ckbx_RememberPwd.Checked = true;
            }
            else
            {
                ckbx_RememberPwd.Checked = false;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thực sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            { }
        }

        private void lbl_Forgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Vui lòng liên hệ quản lí để được cấp lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pnl_Login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_SPTBT_Click(object sender, EventArgs e)
        {

        }

        private void pl_Title_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_Title_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TBT_Click(object sender, EventArgs e)
        {

        }

        private void pnl_LoginForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_SPwd_Click(object sender, EventArgs e)
        {

        }

        private void txt_Account_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Pwd_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Account_Click(object sender, EventArgs e)
        {

        }

    }
}
