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

namespace DoAn_CNPM_App.ChildForm
{
    public partial class HeThong : Form
    {
        EntityFramework dbContext = new EntityFramework();
        int accHopLe;
        public HeThong()
        {
            InitializeComponent();
        }

        private void HeThong_Load(object sender, EventArgs e)
        {
            List<ACCOUNTLV> acclv = dbContext.ACCOUNTLVs.ToList();
            FillDataCBX(acclv);
            lbl_TTH_SoLuongHang.Text = dbContext.LINHKIENs.Count(a => a.MaLK != null).ToString();

        }

        void FillDataCBX(List<ACCOUNTLV> acclv)
        {
            cbx_TTK_lv.DataSource = acclv;
            cbx_TTK_lv.DisplayMember = "Quyen";
            cbx_TTK_lv.ValueMember = "lv";
        }

      
        #region ThemTaiKhoan
        private void CheckUserName()
        {
            String username = txt_TTK_userName.Text;
            if(username == "")
            {
                lbl_TTK_checkuserName.Text = "Không thể để trống tên người dùng!";
                lbl_TTK_checkuserName.ForeColor = Color.Red;
                lbl_TTK_checkuserName.Visible = true;
                accHopLe = -1;
            }
            else
            {
                ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username.CompareTo(username) == 0);
                if (acc == null)
                {
                    lbl_TTK_checkuserName.Text = "Tên người dùng khả dụng!";
                    lbl_TTK_checkuserName.ForeColor = Color.Green;
                    lbl_TTK_checkuserName.Visible = true;
                    accHopLe = 0;
                }
                else
                {
                    lbl_TTK_checkuserName.Text = "Tên đã có người sử dụng!";
                    lbl_TTK_checkuserName.ForeColor = Color.Red;
                    lbl_TTK_checkuserName.Visible = true;
                    accHopLe = 1;
                }
            }
            
        }

        int CheckAddAccount()
        {
            if (txt_TTK_userName.Text == "") //Ten nguoi dung de trong
            {
                return 2;
            }
            if (txt_TTK_Pwd.Text != txt_TTK_reEnterPWD.Text) //Nhap lai mat khau khong trung khop
            {
                return 1;
            }
            if(txt_TTK_MSNV.Text == "") // Ma so nhan vien de trong
            {
                return 3;
            }
            return 0;
        }

        private void CheckMNV()
        {
            String mnv = txt_TTK_MSNV.Text;
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV.CompareTo(mnv) == 0);
            if (nv != null)
            {
                lbl_TTK_checkMSNV.Text = nv.TenNV.ToString();
                lbl_TTK_checkMSNV.Visible = true;
                accHopLe = 0;
            }
            else
            {
                lbl_TTK_checkMSNV.Text = "Không thể tìm thấy nhân viên";
                lbl_TTK_checkMSNV.Visible = true;
                accHopLe = 1;
            }
        }

        private void txt_TTK_userName_TextChanged(object sender, EventArgs e)
        {
            CheckUserName();
        }
        private void btn_TTK_CheckuserName_Click_1(object sender, EventArgs e)
        {
            
        }

        private void txt_TTK_MSNV_TextChanged(object sender, EventArgs e)
        {
            CheckMNV();
        }

        private void btn_TTK_Tao_Click_1(object sender, EventArgs e)
        {
            int dt = CheckAddAccount();
            if (dt == 2)
            {
                MessageBox.Show("Không thể để trống tên người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dt == 1)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (dt == 3)
                    {
                        MessageBox.Show("Không thể để trống mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ACCOUNT acc = new ACCOUNT();
                        acc.username = txt_TTK_userName.Text;
                        acc.password = txt_TTK_Pwd.Text;
                        acc.lv = cbx_TTK_lv.SelectedValue.ToString();
                        acc.MaNV = txt_TTK_MSNV.Text;
                        dbContext.ACCOUNTs.Add(acc);
                        dbContext.SaveChanges();
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
        }
        #endregion
        #region ThemNhanVien
        bool IsValidEmail(string eMail) //Kiem tra Email co dung dinh dang hay khong
        {
            bool Result = false;

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(eMail);

                Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
            }
            catch
            {
                Result = false;
            };

            return Result;
        }


        #endregion

        private void chbx_TTK_ShowOrHidePWD_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_TTK_ShowOrHidePWD.Checked == true)
            {
                txt_TTK_Pwd.UseSystemPasswordChar = false;
                txt_TTK_reEnterPWD.UseSystemPasswordChar = false;
            }
            else
            {
                txt_TTK_Pwd.UseSystemPasswordChar = true;
                txt_TTK_reEnterPWD.UseSystemPasswordChar = true;
            }
        }
    }
}

