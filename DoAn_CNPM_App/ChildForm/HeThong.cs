using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNPM_App.ChildForm
{
    public partial class HeThong : Form
    {
        EntityFramework dbContext = new EntityFramework();
        List<NHANVIEN> nvs = new List<NHANVIEN>();
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
            ResizeTbx();

        }
        void ResizeTbx()
        {
            txt_TTK_userName.Size = new Size (210, 30);
            txt_TTK_MSNV.Size = new Size(210, 30);
            txt_TTK_Pwd.Size = new Size(210, 30);
            txt_TTK_reEnterPWD.Size = new Size(210, 30);
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

        private void txt_TTK_MSNV_TextChange(object sender, EventArgs e)
        {
            CheckMNV();
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
            if (String.IsNullOrEmpty(txt_TTK_MSNV.Text) == true | String.IsNullOrWhiteSpace(txt_TTK_MSNV.Text) == true) // Ma so nhan vien de trong
            {
                return 3;
            }
            String mnv = txt_TTK_MSNV.Text;
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV.CompareTo(mnv) == 0);
            if(nv == null)
            {
                return 4;
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
            }
            else
            {
                lbl_TTK_checkMSNV.Text = "Không thể tìm thấy nhân viên";
                lbl_TTK_checkMSNV.Visible = true;
            }
        }

        private void txt_TTK_userName_TextChange(object sender, EventArgs e)
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
        void TaoTK()
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
                        if(dt == 4)
                        {
                            MessageBox.Show("Không thể tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
        private void btn_TTK_Tao_Click(object sender, EventArgs e)
        {
            TaoTK();
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

        bool IsValidNumber(String sdt)
        {
            if(sdt.Length <= 9 | sdt.Length > 12)
            {
                return false;
            }
            if(int.TryParse(sdt, out _) == false)
            {
                return false;
            }

            return true;
        }
        void TNV_CheckMail()
        {
            String email = txt_TNV_Email.Text;
            bool valid = IsValidEmail(email);
            if(valid == false)
            {
                lbl_TNV_ValidEmail.Text = "Email không hợp lệ!";
                lbl_TNV_ValidEmail.ForeColor = Color.Red;
                lbl_TNV_ValidEmail.Visible = true;
            }
            else
            {
                lbl_TNV_ValidEmail.Text = "Email hợp lệ";
                lbl_TNV_ValidEmail.ForeColor = Color.Green;
                lbl_TNV_ValidEmail.Visible = true;
            }
        }

        void TNV_CheckMaNV()
        {
            String manv = txt_TNV_MaNV.Text;
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV.CompareTo(manv) == 0);
            if (manv == "")
            {
                lbl_TNV_checkMNV.Text = "Không thể để trống mã nhân viên!";
                lbl_TNV_checkMNV.ForeColor = Color.Red;
                lbl_TNV_checkMNV.Visible = true;
            }
            else
            {
                if (nv != null)
                {
                    lbl_TNV_checkMNV.Text = "Đã có mã nhân viên này trên hệ thống!";
                    lbl_TNV_checkMNV.ForeColor = Color.Red;
                    lbl_TNV_checkMNV.Visible = true;
                }
                else
                {
                    lbl_TNV_checkMNV.Text = "";
                }

            }
        }

        private int TNV_CheckValid(int cn)
        {
            if (string.IsNullOrEmpty(txt_TNV_MaNV.Text) == true && cn == 1)
            {
                return 1; //Khong duoc de trong ma nhan vien
            }
            if (IsValidNumber(txt_TNV_SDT.Text) == false)
            {
                return 2; //Sdt khong hop le
            }

            if (string.IsNullOrEmpty(txt_TNV_TenNV.Text) == true)
            {
                return 3; //De trong ten NV
            }

            if (IsValidEmail(txt_TNV_Email.Text) == false)
            {
                return 4; // Email khong hop le
            }
            if (string.IsNullOrEmpty(txt_TNV_DiaChi.Text) == true)
            {
                return 5; //Dia chi bi trong
            }
            if (string.IsNullOrEmpty(txt_TNV_ChucVu.Text) == true)
            {
                return 6; //Chuc vu bi trong
            }
            String mnv = txt_TNV_MaNV.Text;
            NHANVIEN nvf = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV.CompareTo(mnv) == 0);
            if(nvf != null)
            {
                return 7; //da co nhan vien tren he thong
            }
            return 0; //Khong co loi
            
        }
        void TNV_FillDGV(List<NHANVIEN> nv)
        {
            tnv_DGV_Add.Rows.Clear();
            for(int i = 0; i < nv.Count(); i++)
            {
                tnv_DGV_Add.Rows[i].Cells[0].Value = nv[i].MaNV;
                tnv_DGV_Add.Rows[i].Cells[1].Value = nv[i].TenNV;
                tnv_DGV_Add.Rows[i].Cells[2].Value = nv[i].DiaChi;
                tnv_DGV_Add.Rows[i].Cells[3].Value = nv[i].SDT;
                tnv_DGV_Add.Rows[i].Cells[4].Value = nv[i].Email;
                if(nv[i].Phai == true)
                {
                    tnv_DGV_Add.Rows[i].Cells[5].Value = "Nữ";
                }
                else
                {
                    tnv_DGV_Add.Rows[i].Cells[5].Value = "Nam";
                }
                tnv_DGV_Add.Rows[i].Cells[6].Value = nv[i].ChucVu;
            }
        }
        
        void TNV_ThemNV()
        {
            int c = TNV_CheckValid(1);
            switch (c)
            {
                case 0:
                    try
                    {


                        NHANVIEN nv = new NHANVIEN();
                        nv.MaNV = txt_TNV_MaNV.Text;
                        nv.TenNV = txt_TNV_TenNV.Text;
                        nv.SDT = txt_TNV_SDT.Text;
                        nv.Email = txt_TNV_Email.Text;
                        nv.DiaChi = txt_TNV_DiaChi.Text;
                        nv.ChucVu = txt_TNV_ChucVu.Text;
                        if (rdb_TNV_Nam.Checked == true)
                        {
                            nv.Phai = false;
                        }
                        else
                        {
                            nv.Phai = true;
                        }
                        nvs.Add(nv);
                        dbContext.NHANVIENs.Add(nv);
                        dbContext.SaveChanges();
                        TNV_FillDGV(nvs);
                        btn_TNV_TongNVDaThem_Disable.Text = nvs.Count.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                    break;
                case 1:
                    MessageBox.Show("Không thể để trống mã nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 2:
                    MessageBox.Show("SĐT không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3:
                    MessageBox.Show("Không thể để trống tên nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 4:
                    MessageBox.Show("Email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 5:
                    MessageBox.Show("Không thể để trống địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 6:
                    MessageBox.Show("Không thể để trống chức vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 7:
                    MessageBox.Show("Mã nhân viên đã có trên hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

            }
        }

        private void tnv_DGV_Add_SelectionChanged(object sender, EventArgs e)
        {

            if (nvs.Count > 0)
            {
                btn_TNV_Sua.Enabled = true;
                txt_TNV_MaNV.Text = tnv_DGV_Add.SelectedRows[0].Cells[0].Value.ToString();
                txt_TNV_TenNV.Text = tnv_DGV_Add.SelectedRows[0].Cells[1].Value.ToString();
                txt_TNV_SDT.Text = tnv_DGV_Add.SelectedRows[0].Cells[3].Value.ToString();
                txt_TNV_Email.Text = tnv_DGV_Add.SelectedRows[0].Cells[4].Value.ToString();
                txt_TNV_DiaChi.Text = tnv_DGV_Add.SelectedRows[0].Cells[2].Value.ToString();
                txt_TNV_ChucVu.Text = tnv_DGV_Add.SelectedRows[0].Cells[6].Value.ToString();

                if (tnv_DGV_Add.SelectedRows[0].Cells[6].Value.ToString() == "Nam")
                {
                    rdb_TNV_Nam.Checked = true;
                    rdb_TNV_Nu.Checked = false;
                }
                else
                {
                    rdb_TNV_Nu.Checked = true;
                    rdb_TNV_Nam.Checked = false;
                }
            }
        }


        void TNV_SuaNVDaThem()
        {
            int c = TNV_CheckValid(2);
            switch (c)
            {
                case 0:
                    try
                    {
                        String MaNV = tnv_DGV_Add.SelectedRows[0].Cells[0].Value.ToString();
                        NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(d => d.MaNV.CompareTo(MaNV) == 0);
                        nv.TenNV = txt_TNV_TenNV.Text;
                        nv.SDT = txt_TNV_SDT.Text;
                        nv.Email = txt_TNV_Email.Text;
                        nv.DiaChi = txt_TNV_DiaChi.Text;
                        nv.ChucVu = txt_TNV_ChucVu.Text;
                        if (rdb_TNV_Nam.Checked == true)
                        {
                            nv.Phai = false;
                        }
                        else
                        {
                            nv.Phai = true;
                        }
                        dbContext.SaveChanges();
                        nvs[nvs.FindIndex(a => a.MaNV.Equals(MaNV))] = nv;
                        TNV_FillDGV(nvs);
                        btn_TNV_TongNVDaThem_Disable.Text = nvs.Count.ToString();
                        btn_TNV_Sua.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                    break;
                case 1:
                    
                    break;
                case 2:
                    MessageBox.Show("SĐT không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3:
                    MessageBox.Show("Không thể để trống tên nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 4:
                    MessageBox.Show("Email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 5:
                    MessageBox.Show("Không thể để trống địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 6:
                    MessageBox.Show("Không thể để trống chức vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 7:
                    MessageBox.Show("Mã nhân viên đã có trên hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

            }
        }
        private void btn_TNV_Them_Click(object sender, EventArgs e)
        {
            TNV_ThemNV();
        }

        
        private void btn_TNV_Sua_Click(object sender, EventArgs e)
        {
            TNV_SuaNVDaThem();
        }

        private void txt_TNV_MaNV_TextChange(object sender, EventArgs e)
        {
            TNV_CheckMaNV();
        }
        private void txt_TNV_Email_TextChanged(object sender, EventArgs e)
        {
            TNV_CheckMail();
        }


        #endregion

        private void btn_QLTK_TTK_Click(object sender, EventArgs e)
        {
            page_QLTK.SetPage("QLTK",false);
        }

        private void btn_QLTK_ChinhSua_Click(object sender, EventArgs e)
        {
            page_QLTK.SetPage("EDIT", false);
        }
    }
}

