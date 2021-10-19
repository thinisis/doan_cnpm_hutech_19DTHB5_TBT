using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_CNPM_App
{
    public partial class MainForm : Form
    {

        private Form activeForm;
        int userLevel;
        int userID;
        String userName;
        String nameOfUser;
        String maNV;
        SqlConnection con = new SqlConnection();
        public MainForm()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=THINNGUYENVN\\SQLEXPRESS;Initial Catalog=TBT_DTB;Integrated Security=True";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetInfoUser();
            PhanQuyen();
            StartTimer();
            lbl_Time.Visible = true;
            lbl_HelloUsername.Text = "Xin chào " + nameOfUser.ToString();
            lbl_UserHello.Text = userName.ToString();
        }

        System.Windows.Forms.Timer t = null;
        private void StartTimer() //Reload dong ho dem gio
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbl_Day.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void GetInfoUser()
        {
            con.ConnectionString = "Data Source=THINNGUYENVN\\SQLEXPRESS;Initial Catalog=TBT_DTB;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from ACCOUNT, NHANVIEN where username='" + Properties.Settings.Default.Username + "' AND ACCOUNT.MaNV = NHANVIEN.MaNV", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        int.TryParse(dr["lv"].ToString(), out userLevel);
                        int.TryParse(dr["id"].ToString(), out userID);
                        nameOfUser = dr["TenNV"].ToString();
                        maNV = dr["MaNV"].ToString();
                        userName = dr["username"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lấy thông tin người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.Close();
            }
        }

        private void ResetButton()
        {
        }

        private void PhanQuyen()
        {
            if(userLevel == 0)
            {

            }

            if(userLevel == 1)
            {

            }
            if(userLevel == 2)
            {
                btn_HeThong.Visible = false;
                btn_BaoHanh.Visible = false;
            }
        }

        private void OpenChildForm (Form ChildForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.pannel_Main.Controls.Add(ChildForm);
            this.pannel_Main.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            lbl_TitleText.Text = ChildForm.Text;
            
        }


        private void btn_DanhMuc_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.DanhMuc(), sender);
        }

        private void pbx_LogoMain_Click(object sender, EventArgs e)
        {

        }

        private void lbl_GioiThieu_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Title_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_HelloUsername_Click(object sender, EventArgs e)
        {

        }

        private void btn_XuLy_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.XuLy(), sender);
        }

        private void btn_TrangChu_Click_1(object sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            lbl_TitleText.Text = "TRANG CHỦ";
        }

        private void btn_HeThong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.HeThong(), sender);
        }

        private void btn_DanhMuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.DanhMuc(), sender);
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.BaoCao(), sender);
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.TimKiem(), sender);
        }

        private void btn_BaoHanh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.BaoHanh(), sender);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.TroGiup(), sender);
        }

        private void btn_UserSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_Day_Click(object sender, EventArgs e)
        {

        }

        private void lbl_UserHello_Click(object sender, EventArgs e)
        {

        }
    }
}
