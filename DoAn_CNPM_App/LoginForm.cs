using MetroSet_UI.Forms;
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
    public partial class LoginForm : MetroSetForm
    {
        SqlConnection con = new SqlConnection();
        public LoginForm()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=THINNGUYENVN\\SQLEXPRESS;Initial Catalog=TBT_DTB;Integrated Security=True";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=THINNGUYENVN\\SQLEXPRESS;Initial Catalog=TBT_DTB;Integrated Security=True");
            con.Open(); //ket noi csdl
            txb_Account.Text = Properties.Settings.Default.Username; 
            txb_Pwd.Text = Properties.Settings.Default.Password;
            if (Properties.Settings.Default.Checked == true)
            {
                ckbx_Remember.Checked = true;
            }
            else
            {
                ckbx_Remember.Checked = false;
            }
        }

        private void lb_Account_Click(object sender, EventArgs e)
        {

        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroSetMessageBox.Show(this,"Bạn thực sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            { }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=THINNGUYENVN\\SQLEXPRESS;Initial Catalog=TBT_DTB;Integrated Security=True";
            con.Open();
            string userid = txb_Account.Text;
            string password = txb_Pwd.Text;
            SqlCommand cmd = new SqlCommand("select username,password from ACCOUNT where username='" + txb_Account.Text + "'and password='" + txb_Pwd.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MetroSetMessageBox.Show(this,"Đăng nhập thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Question);
                if (ckbx_Remember.Checked == true)
                {
                    Properties.Settings.Default.Username = txb_Account.Text;
                    Properties.Settings.Default.Password = txb_Pwd.Text;
                    Properties.Settings.Default.Checked = true;
                    Properties.Settings.Default.Save();
                }
                if (ckbx_Remember.Checked == false)
                {
                    Properties.Settings.Default.Username = txb_Account.Text;
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
                MetroSetMessageBox.Show(this, "Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            
        }

        private void metroSetPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroSetLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ForgotPwd_Click(object sender, EventArgs e)
        {
            MetroSetMessageBox.Show(this, "Vui lòng liên hệ quản lí để được cấp lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lb_DangNhap_Click(object sender, EventArgs e)
        {

        }

        private void txb_Account_Click(object sender, EventArgs e)
        {

        }
    }
}
