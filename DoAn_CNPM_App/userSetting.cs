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
        EntityFramework dbContext = new EntityFramework();
        ACCOUNT acc = new ACCOUNT();
        NHANVIEN nv = new NHANVIEN();
        public userSettingForm()
        {
            InitializeComponent();
        }

        private void userSettingForm_Load(object sender, EventArgs e)
        {
            acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString());
            nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == acc.MaNV);
            accSet_FillData(acc);
            userSet_FillData(nv);
        }

        
        #region QuanLyPage
        private void btn_accountSetting_Click(object sender, EventArgs e)
        {
            page_Ctrl.SetPage("accountSetting", false);
        }

        private void btn_userSetting_Click(object sender, EventArgs e)
        {
            page_Ctrl.SetPage("userSetting", false);
        }
        #endregion
        #region PageAccSet
        void accSet_FillData(ACCOUNT acc)
        {
            txt_accSet_LoaiTK.Text = acc.ACCOUNTLV.Quyen;
            txt_accSet_TenTK.Text = acc.username;
            txt_accSet_MaNV.Text = acc.MaNV;
        }

        bool accSet_PassCheck()
        {
            if(txt_accSet_userOldPass.Text == acc.password)
            {
                return true;
            }
            return false;
        }

        bool accSet_reEnterPassCheck()
        {
            if(txt_accSet_userNewPass.Text == txt_accSet_userreNewPass.Text)
            {
                return true;
            }
            return false;
        }

        int accSet_SaveCase()
        {
            if(accSet_PassCheck() == false)
            {
                return 1; //Sai mật khẩu cũ
            }
            else
            {
                if(accSet_reEnterPassCheck() == false)
                {
                    return 2; //Mat khau nhap lai khong trung khop
                }
            }

            return 0;
        }

        void accSet_SavePass()
        {
            int check = accSet_SaveCase();
            switch (check)
            {
                case 0:
                    try
                    {
                        String mess = "Xác nhận thay đổi mật khẩu mới thành " + txt_accSet_userNewPass.Text + "?";
                        DialogResult dr = MessageBox.Show(mess, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            acc.password = txt_accSet_userNewPass.Text;
                            dbContext.SaveChanges();
                            accSet_ClearTextbox();
                            MessageBox.Show("Thao tác thành công! Mật khẩu mới sẽ có hiệu lực ở lần đăng nhập tiếp theo", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác", "Thông báo");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                    break;
                case 1:
                    MessageBox.Show("Bạn đã nhập sai mật khẩu cũ!", "Thông báo");
                    break;
                case 2:
                    MessageBox.Show("Mật khẩu nhập lại không trùng khớp!", "Thông báo");
                    break;
            }   
        }

        void accSet_ClearTextbox()
        {
            txt_accSet_userNewPass.Text = "";
            txt_accSet_userOldPass.Text = "";
            txt_accSet_userreNewPass.Text = "";
        }

        private void btn_accSet_Save_Click(object sender, EventArgs e)
        {
            accSet_SavePass();
        }
        #endregion
        #region PageUserSet
        void userSet_FillData(NHANVIEN nv)
        {
            txt_userSet_MaNV.Text = nv.MaNV;
            txt_userSet_TenNV.Text = nv.TenNV;
            txt_userSet_DiaChi.Text = nv.DiaChi;
            txt_userSet_Email.Text = nv.Email;
            txt_userSet_SDT.Text = nv.SDT;
            txt_userSet_ChucVu.Text = nv.ChucVu;
            if(nv.Phai == false)
            {
                rbtn_userSet_Nam.Checked = true;
            }
            else
            {
                rbtn_userSet_Nu.Checked = true;
            }
        }

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

        bool IsValidNumber(String sdt)
        {
            if (sdt.Length <= 9 | sdt.Length > 12)
            {
                return false;
            }
            if (int.TryParse(sdt, out _) == false) //Kiem tra sdt co phai kieu int khong ma khong tra ve gia tri nao (out_)
            {
                return false;
            }

            return true;
        }

        int userSet_CheckSave()
        {
            String temp_mnv = nv.MaNV; //Lay ma nhan vien da nhap
            if (nv != null)
            {
                if (string.IsNullOrEmpty(txt_userSet_ChucVu.Text) == true |
                    string.IsNullOrEmpty(txt_userSet_DiaChi.Text) == true |
                    string.IsNullOrEmpty(txt_userSet_TenNV.Text) == true |
                    string.IsNullOrEmpty(txt_userSet_SDT.Text) == true |
                    string.IsNullOrEmpty(txt_userSet_Email.Text) == true)
                {
                    return 1; //Co textbox bi trong
                }
                if (IsValidEmail(txt_userSet_Email.Text) == false)
                {
                    return 2; //Email khong hop le
                }
                else
                {
                    if (IsValidNumber(txt_userSet_SDT.Text) == false)
                    {
                        return 3; //SDT khong hop le
                    }
                }

            }
            return 0;
        }

        void userSet_Save()
        {
            int check = userSet_CheckSave();
            switch (check)
            {
                case 0:
                    try
                    {
                        String gioitinh;
                        if (rbtn_userSet_Nu.Checked == true)
                        {
                            gioitinh = "Nữ";
                        }
                        else
                        {
                            gioitinh = "Nam";
                        }
                        String mess = "Thay đổi thông tin thành:"
                                    + "\nMã nhân viên: " + txt_userSet_MaNV.Text
                                    + "\nTên nhân viên: " + txt_userSet_TenNV.Text
                                    + "\nĐịa chỉ: " + txt_userSet_DiaChi.Text
                                    + "\nEmail: " + txt_userSet_Email.Text
                                    + "\nSDT: " + txt_userSet_SDT.Text
                                    + "\nChức vụ: " + txt_userSet_ChucVu.Text
                                    + "\nGiới tính: " + gioitinh;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            nv.TenNV = txt_userSet_TenNV.Text;
                            nv.DiaChi = txt_userSet_DiaChi.Text;
                            nv.Email = txt_userSet_Email.Text;
                            nv.ChucVu = txt_userSet_ChucVu.Text;
                            nv.SDT = txt_userSet_SDT.Text;
                            if (rbtn_userSet_Nam.Checked == true)
                            {
                                nv.Phai = false;
                            }
                            else
                            {
                                nv.Phai = true;
                            }
                            dbContext.SaveChanges();
                            userSet_FillData(nv);
                            MessageBox.Show("Thao tác thành công! Có thể sẽ không hiện thị chính xác\nthông tin mới cho đến lần đăng nhập tiếp theo!", "Thông báo");
                            
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Thông báo");
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng điền đầy đủ các ô trống!", "Cảnh báo");
                    break;
                case 2:
                    MessageBox.Show("Email không hợp lệ!", "Cảnh báo");
                    break;
                case 3:
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Cảnh báo");
                    break;
            }
        }

        private void btn_userSet_Save_Click(object sender, EventArgs e)
        {
            userSet_Save();
        }
        #endregion
    }
}
