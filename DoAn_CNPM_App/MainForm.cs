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
using System.Threading;

namespace DoAn_CNPM_App
{
    public partial class MainForm : Form
    {
        EntityFramework dbContext = new EntityFramework();
        private Form activeForm;
        int userLevel;
        String userName;
        String nameOfUser;
        String maNV;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            GetInfoUser();
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
            try
            {
                ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username);
                if (acc != null)
                {
                    userLevel = int.Parse(acc.lv);
                    nameOfUser = acc.NHANVIEN.TenNV;
                    maNV = acc.MaNV;
                    userName = acc.username;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lấy thông tin người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btn_XuLy_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.frmXuLy(), sender);
        }

        private void btn_TrangChu_Click_1(object sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            lbl_TitleText.Text = "TRANG CHỦ";
        }
        void LoadingTime()
        {
            for (int i = 0; i <= 40; i++)
                Thread.Sleep(40);
        }

        private void btn_HeThong_Click(object sender, EventArgs e)
        {
            if(userLevel == 0 )
            {
                using (Loading form = new Loading(LoadingTime))
                {
                    form.ShowDialog(this);
                }
                OpenChildForm(new ChildForm.HeThong(), sender);
            }
            else
            {
                OpenChildForm(new ChildForm.PQ_Error(), sender);
            }
            
        }

        private void btn_DanhMuc_Click(object sender, EventArgs e)
        {
            using (Loading form = new Loading(LoadingTime))
            {
                form.ShowDialog(this);
                OpenChildForm(new ChildForm.frmDanhMuc(), sender);
            }
            
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            if (userLevel != 2)
            {
                OpenChildForm(new ChildForm.BaoCao(), sender);
            }
            else
            {
                OpenChildForm(new ChildForm.PQ_Error(), sender);
            }
                
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.DangXayDung(), sender);
        }

        private void btn_BaoHanh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.DangXayDung(), sender);
        }

        private void btn_TroGiup_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChildForm.TroGiup(), sender);
        }

        private void btn_UserSetting_Click(object sender, EventArgs e)
        {
            
        }


        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            String mess = "Bạn sẽ đăng xuất, tiếp tục?";
            DialogResult dr = MessageBox.Show(mess, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_userSetting_Click_1(object sender, EventArgs e)
        {
            userSettingForm form = new userSettingForm();
            form.ShowDialog();
        }

        
    }
}
