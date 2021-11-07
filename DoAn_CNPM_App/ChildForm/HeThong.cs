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
        List<NHANVIEN> dsnv = new List<NHANVIEN>();
        List<ACCOUNT> accss = new List<ACCOUNT>();
        String thisAccount;
        int accHopLe;
        bool LoadedNVAdd = false;
        bool LoadedNVCS = false;
        bool LoadedTKCS = false;
        public HeThong()
        {
            InitializeComponent();
        }

        private void HeThong_Load(object sender, EventArgs e)
        {
            tabCtrl_HeThong.SelectedTab = tab_QLTK;
            List<ACCOUNTLV> acclv = dbContext.ACCOUNTLVs.ToList();
            accss = dbContext.ACCOUNTs.ToList();
            dsnv = dbContext.NHANVIENs.ToList();
            FillDataCBX(acclv);
            lbl_TTH_SoLuongHang.Text = dbContext.LINHKIENs.Count(a => a.MaLK != null).ToString();
            
        }
        #region HeThong_Page
        private void btn_QLTK_TTK_Click(object sender, EventArgs e)
        {
            page_QLTK.SetPage("QLTK", false);
        }

        private void btn_QLTK_ChinhSua_Click(object sender, EventArgs e)
        {
            LoadedTKCS = false;
            page_QLTK.SetPage("EDIT", false);
            FillDGVCS(accss);
            lbl_QLTK_CS_Count.Text = accss.Count.ToString();
            FillCBXCS();
            LoadedTKCS = true;
        }

        private void btn_QLNV_TNV_Click(object sender, EventArgs e)
        {
            page_QLNV.SetPage("TNV", false);
        }

        private void btn_QLNV_ChinhSuaNV_Click(object sender, EventArgs e)
        {
            LoadedNVCS = false;
            QLNV_CS_FillDGV(dsnv);
            txt_QLNV_CS_CountSL.Text = dsnv.Count.ToString();
            page_QLNV.SetPage("EDIT", false);
            LoadedNVCS = true;
 
        }
        #endregion
        #region ThemTaiKhoan
        private void CheckUserName()
        {
            String username = txt_TTK_userName.Text;
            if (username == "")
            {
                lbl_TTK_checkuserName.Text = "Không thể để trống tên người dùng !";
                lbl_TTK_checkuserName.ForeColor = Color.Red;
                lbl_TTK_checkuserName.Visible = true;
                accHopLe = -1;
            }
            else
            {
                if (Regex.IsMatch(username, @"(!|@|#)"))
                {
                    lbl_TTK_checkuserName.Text = "Tên người dùng không được có kí tự đặc biệt!";
                    lbl_TTK_checkuserName.ForeColor = Color.Red;
                    lbl_TTK_checkuserName.Visible = true;
                    accHopLe = -1;
                }
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
        void FillDataCBX(List<ACCOUNTLV> acclv)
        {
            cbx_TTK_lv.DataSource = acclv;
            cbx_TTK_lv.DisplayMember = "Quyen";
            cbx_TTK_lv.ValueMember = "lv";
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
            if (nv == null)
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
            switch (dt)
            {
                case 1:
                    MessageBox.Show("Mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 2:
                    MessageBox.Show("Không thể để trống tên người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3:
                    MessageBox.Show("Không thể để trống mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 4:
                    MessageBox.Show("Không thể tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    ACCOUNT acc = new ACCOUNT();
                    acc.username = txt_TTK_userName.Text;
                    acc.password = txt_TTK_Pwd.Text;
                    acc.lv = cbx_TTK_lv.SelectedValue.ToString();
                    acc.MaNV = txt_TTK_MSNV.Text;
                    dbContext.ACCOUNTs.Add(acc);
                    dbContext.SaveChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    break;
            }

        }
        private void btn_TTK_Tao_Click(object sender, EventArgs e)
        {
            TaoTK();
        }
        #endregion // dont  
        #region ChinhSuaTaiKhoan
        void FillDGVCS(List<ACCOUNT> accs)
        {
            dgv_QLTK_CS.Rows.Clear();
            for (int i = 0; i < accs.Count(); i++)
            {
                int index = dgv_QLTK_CS.Rows.Add();
                dgv_QLTK_CS.Rows[i].Cells[0].Value = accs[i].username.ToString();
                dgv_QLTK_CS.Rows[i].Cells[1].Value = accs[i].password.ToString();
                dgv_QLTK_CS.Rows[i].Cells[2].Value = accs[i].NHANVIEN.TenNV.ToString();
                dgv_QLTK_CS.Rows[i].Cells[3].Value = accs[i].MaNV.ToString();
            }
        }

        void FillCBXCS()
        {
            cbx_QLTK_CS_Quyen.DataSource = dbContext.ACCOUNTLVs.ToList();
            cbx_QLTK_CS_Quyen.DisplayMember = "Quyen";
            cbx_QLTK_CS_Quyen.ValueMember = "lv";
        }


        void FindAcc()
        {
            String account = txt_QLTK_CS_userName.Text;
            String mnv = txt_QLTK_CS_MaNV.Text;
            String lv = cbx_QLTK_CS_Quyen.SelectedIndex.ToString();
            List<ACCOUNT> fnvs = new List<ACCOUNT>();
            if (string.IsNullOrEmpty(account) == false)
            {
                fnvs = dbContext.ACCOUNTs.Where(a => a.username == account & a.lv == lv).ToList();
            }
            else
            {
                fnvs = dbContext.ACCOUNTs.Where(a => a.lv == lv).ToList();
            }

            FillDGVCS(fnvs);
            String Messages = "Có " + fnvs.Count.ToString() + " kết quả phù hợp!";
            lbl_QLTK_CS_Message.Text = Messages;
        }

        private void btn_QLTK_CS_Find_Click(object sender, EventArgs e)
        {
            LoadedTKCS = false;
            FindAcc();
            LoadedTKCS = true;
        }

        private void dgv_QLTK_CS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void HideSelectedAccountLable()
        {
            lbl_QLTK_CS_userSelectedValue.Visible = false;
            lbl_QLTK_CS_userSelectedTLable.Visible = false;
            btn_QLTK_CS_BoChon.Visible = false;
        }

        bool QLTK_KTTK(String manv)
        {
            NHANVIEN temp = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == manv);
            if (temp == null)
            {
                return false;
            }
            return true;
        }

        void ClearTextBox()
        {
            txt_QLTK_CS_userName.Enabled = true;
            txt_QLNV_CS_TenNV.Text = "";
            txt_QLTK_CS_MaNV.Text = "";
            txt_QLTK_CS_Pwd.Text = "";
            txt_QLTK_CS_userName.Text = "";
            cbx_QLTK_CS_Quyen.SelectedIndex = 0;
        }

        void QLTK_CS_Edit()
        {

            String user = lbl_QLTK_CS_userSelectedValue.Text;
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == user);
            if (acc != null)
            {
                NHANVIEN tempnv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == txt_QLTK_CS_MaNV.Text);
                ACCOUNTLV templv = dbContext.ACCOUNTLVs.FirstOrDefault(a => a.lv == cbx_QLTK_CS_Quyen.SelectedIndex.ToString());
                if (QLTK_KTTK(txt_QLTK_CS_MaNV.Text) == true)
                {
                    String mess = "Thay đổi thông tin thành:\nTên tài khoản: " + txt_QLTK_CS_userName.Text
                                    + "\nMật khẩu: " + txt_QLTK_CS_Pwd.Text
                                    + "\nTên nhân viên: " + tempnv.TenNV.ToString()
                                    + "\nMã nhân viên: " + txt_QLTK_CS_MaNV.Text
                                    + "\nQuyền: " + templv.Quyen.ToString();
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        acc.password = txt_QLTK_CS_Pwd.Text;
                        acc.MaNV = txt_QLTK_CS_MaNV.Text;
                        acc.lv = cbx_QLTK_CS_Quyen.SelectedIndex.ToString();
                        dbContext.SaveChanges();
                        accss = dbContext.ACCOUNTs.ToList();
                        FillDGVCS(accss);
                        ClearTextBox();
                        HideSelectedAccountLable();
                        MessageBox.Show("Thay đổi thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ bỏ thao tác", "Thông báo");
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mã nhân viên hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        void QLTK_DisableOrEnableBTN(bool kt)
        {
            btn_QLTK_CS_Edit.Enabled = kt;
            btn_QLTK_CS_Xoa.Enabled = kt;
            btn_QLTK_CS_BoChon.Visible = kt;
        }

        private void dgv_QLTK_CS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_QLTK_CS.Rows.Count > 0 && LoadedTKCS == true)
            {
                QLTK_DisableOrEnableBTN(true);
                txt_QLTK_CS_userName.Enabled = false;
                txt_QLTK_CS_MaNV.Text = dgv_QLTK_CS.SelectedRows[0].Cells[3].Value?.ToString();
                txt_QLTK_CS_userName.Text = dgv_QLTK_CS.SelectedRows[0].Cells[0].Value?.ToString();
                txt_QLTK_CS_Pwd.Text = dgv_QLTK_CS.SelectedRows[0].Cells[1].Value?.ToString();
                ACCOUNT temp = new ACCOUNT();
                temp = dbContext.ACCOUNTs.FirstOrDefault(a => a.MaNV == txt_QLTK_CS_MaNV.Text);
                cbx_QLTK_CS_Quyen.SelectedIndex = int.Parse(temp.lv.ToString());
                lbl_QLTK_CS_userSelectedValue.Text = temp.username.ToString();
                lbl_QLTK_CS_userSelectedValue.Visible = true;
                if (string.IsNullOrEmpty(lbl_QLTK_CS_userSelectedValue.Text) == false)
                {
                    lbl_QLTK_CS_userSelectedTLable.Visible = true;
                }
            }
        }

        private void btn_QLTK_CS_Edit_Click(object sender, EventArgs e)
        {
            LoadedTKCS = false;
            QLTK_CS_Edit();
            LoadedTKCS = true;
            txt_QLTK_CS_userName.Enabled = true;
        }

        void QLTK_CS_Delete()
        {
            String user = txt_QLTK_CS_userName.Text;
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == user);
            if (acc != null)
            {
                dbContext.ACCOUNTs.Remove(acc);
                dbContext.SaveChanges();
            }
            accss = dbContext.ACCOUNTs.ToList();
            FillDGVCS(accss);
            ClearTextBox();
            HideSelectedAccountLable();
        }

        private void btn_QLTK_CS_Xoa_Click(object sender, EventArgs e)
        {
            LoadedTKCS = false;
            QLTK_CS_Delete();
            LoadedTKCS = true;
        }

        private void btn_QLTK_CS_BoChon_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            HideSelectedAccountLable();
            QLTK_DisableOrEnableBTN(false);
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
            if (sdt.Length <= 9 | sdt.Length > 12)
            {
                return false;
            }
            if (int.TryParse(sdt, out _) == false)
            {
                return false;
            }

            return true;
        }
        void TNV_CheckMail()
        {
            String email = txt_TNV_Email.Text;
            bool valid = IsValidEmail(email);
            if (valid == false)
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
            if (nvf != null)
            {
                return 7; //da co nhan vien tren he thong
            }
            return 0; //Khong co loi

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
                        MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


       
        private void btn_TNV_Them_Click(object sender, EventArgs e)
        {
            LoadedNVAdd = false;
            TNV_ThemNV();
            LoadedNVAdd = true;
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
        #region ChinhSuaNhanVien
        void QLNV_CS_FillDGV(List<NHANVIEN> nv)
        {
            EnableOrDisable_TextBox_Find_CSNV(true);
            EnableOrDisableButtonCSNV(false);
            dgv_QLNV_CS.Rows.Clear();
            for (int i = 0; i < nv.Count(); i++)
            {
                int index = dgv_QLNV_CS.Rows.Add();
                dgv_QLNV_CS.Rows[i].Cells[0].Value = (i + 1).ToString();
                dgv_QLNV_CS.Rows[i].Cells[1].Value = nv[i].MaNV;
                dgv_QLNV_CS.Rows[i].Cells[2].Value = nv[i].TenNV;
                dgv_QLNV_CS.Rows[i].Cells[3].Value = nv[i].DiaChi;
                dgv_QLNV_CS.Rows[i].Cells[4].Value = nv[i].SDT;
                dgv_QLNV_CS.Rows[i].Cells[5].Value = nv[i].Email;
                if (nv[i].Phai == true)
                {
                    dgv_QLNV_CS.Rows[i].Cells[6].Value = "Nữ";
                }
                else
                {
                    dgv_QLNV_CS.Rows[i].Cells[6].Value = "Nam";
                }
                dgv_QLNV_CS.Rows[i].Cells[7].Value = nv[i].ChucVu;
            }
        }



        void EnableOrDisableButtonCSNV(bool value)
        {
            btn_QLNV_CS_ChinhSua.Enabled = value;
            btn_QLNV_CS_Xoa.Enabled = value;
        }

        void EnableOrDisable_TextBox_Find_CSNV(bool value)
        {
            txt_QLNV_CS_Email.Enabled = value;
            txt_QLNV_CS_DiaChi.Enabled = value;
            txt_QLNV_CS_ChucVu.Enabled = value;
        }

        int QLNV_CS_SearchResult_Data_Filter()
        {
            if (string.IsNullOrEmpty(txt_QLNV_CS_MaNV.Text) == false & string.IsNullOrEmpty(txt_QLNV_CS_TenNV.Text) == true)
            {
                return 1; //Chi tim kiem  manv
            }
            else
            {
                if (string.IsNullOrEmpty(txt_QLNV_CS_MaNV.Text) == true & string.IsNullOrEmpty(txt_QLNV_CS_TenNV.Text) == false)
                {
                    return 2; //chi tim kiem tennv
                }
            }
            return 0;
        }

        void QLNV_CS_Find()
        {
            List<NHANVIEN> nvf = new List<NHANVIEN>();
            int findoption = QLNV_CS_SearchResult_Data_Filter();
            switch (findoption)
            {
                case 0:
                    nvf = dbContext.NHANVIENs.Where(a => a.MaNV == txt_QLNV_CS_MaNV.Text & a.TenNV == txt_QLNV_CS_TenNV.Text).ToList();
                    QLNV_CS_FillDGV(nvf);
                    break;
                case 1:
                    nvf = dbContext.NHANVIENs.Where(a => a.MaNV == txt_QLNV_CS_MaNV.Text).ToList();
                    QLNV_CS_FillDGV(nvf);
                    break;
                case 2:
                    nvf = dbContext.NHANVIENs.Where(a => a.TenNV == txt_QLNV_CS_TenNV.Text).ToList();
                    QLNV_CS_FillDGV(nvf);
                    break;
            }
        }

        int CheckValid_Edit_QLNV_CS()
        {
            String temp_mnv = lbl_QLNV_CS_SelectedMaNVValue.Text; //Lay ma nhan vien da nhap
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == temp_mnv);
            if (nv != null)
            {
                if (string.IsNullOrEmpty(txt_QLNV_CS_ChucVu.Text) == true |
                    string.IsNullOrEmpty(txt_QLNV_CS_TenNV.Text) == true |
                    string.IsNullOrEmpty(txt_QLNV_CS_SDT.Text) == true |
                    string.IsNullOrEmpty(txt_QLNV_CS_Email.Text) == true |
                    string.IsNullOrEmpty(txt_QLNV_CS_ChucVu.Text) == true)
                {
                    return 3; //Co textbox bi trong
                }
                if (IsValidEmail(txt_QLNV_CS_Email.Text) == false)
                {
                    return 1; //Email khong hop le
                }
                else
                {
                    if (IsValidNumber(txt_QLNV_CS_SDT.Text) == false)
                    {
                        return 2; //SDT khong hop le
                    }
                }

            }
            return 0;
        }

        private void btn_QLNV_CS_TimKiem_Click(object sender, EventArgs e)
        {
            QLNV_CS_Find();
        }

        void ClearTextBox_QLNVCS()
        {
            txt_QLNV_CS_MaNV.Text = "";
            txt_QLNV_CS_TenNV.Text = "";
            txt_QLNV_CS_Email.Text = "";
            txt_QLNV_CS_SDT.Text = "";
            txt_QLNV_CS_DiaChi.Text = "";
            txt_QLNV_CS_ChucVu.Text = "";
        }

        void ShowOrHide_SelectedMaNV_QLNVCS(bool value)
        {
            lbl_QLNV_CS_SelectedMaNVValue.Visible = value;
            lbl_QLNV_CS_SelectedMaNVLable.Visible = value;
            btn_QLNV_CS_BoChon.Visible = value;
        }
        private void btn_QLNV_CS_BoChon_Click(object sender, EventArgs e)
        {
            ShowOrHide_SelectedMaNV_QLNVCS(false);
            ClearTextBox_QLNVCS();
            EnableOrDisableButtonCSNV(false);
            txt_QLNV_CS_MaNV.Enabled = true;
        }

        void QLNV_CS_EditNV()
        {
            int check = CheckValid_Edit_QLNV_CS();
            switch (check)
            {
                case 0:
                    try
                    {
                        String manv = lbl_QLNV_CS_SelectedMaNVValue.Text;
                        String gioitinh;
                        if (rdb_QLNV_CS_Nam.Checked == true)
                        {
                            gioitinh = "Nữ";
                        }
                        else
                        {
                            gioitinh = "Nam";
                        }
                        String mess = "Thay đổi thông tin thành:"
                                    + "\nMã nhân viên: " + txt_QLNV_CS_MaNV.Text
                                    + "\nTên nhân viên: " + txt_QLNV_CS_TenNV.Text
                                    + "\nĐịa chỉ: " + txt_QLNV_CS_DiaChi.Text
                                    + "\nEmail: " + txt_QLNV_CS_Email.Text
                                    + "\nSDT: " + txt_QLNV_CS_SDT.Text
                                    + "\nChức vụ: " + txt_QLNV_CS_ChucVu.Text
                                    + "\nGiới tính: " + gioitinh;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            NHANVIEN tempnv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == manv);
                            tempnv.TenNV = txt_QLNV_CS_TenNV.Text;
                            tempnv.DiaChi = txt_QLNV_CS_DiaChi.Text;
                            tempnv.SDT = txt_QLNV_CS_SDT.Text;
                            tempnv.ChucVu = txt_QLNV_CS_ChucVu.Text;
                            tempnv.Email = txt_QLNV_CS_Email.Text;
                            if (rdb_QLNV_CS_Nam.Checked == true)
                            {
                                tempnv.Phai = false;
                            }
                            else
                            {
                                tempnv.Phai = true;
                            }
                            dbContext.SaveChanges();
                            dsnv = dbContext.NHANVIENs.ToList();
                            QLNV_CS_FillDGV(dsnv);
                            ShowOrHide_SelectedMaNV_QLNVCS(false);
                            txt_QLNV_CS_MaNV.Enabled = true;
                            ClearTextBox_QLNVCS();
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                    break;
                case 1:
                    MessageBox.Show("Email không hợp lệ!", "Cảnh báo");
                    break;
                case 2:
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Cảnh báo");
                    break;
                case 3:
                    MessageBox.Show("Vui lòng điền đầy đủ các ô trống!", "Cảnh báo");
                    break;
            }
        }

        private void btn_QLNV_CS_ChinhSua_Click(object sender, EventArgs e)
        {
            LoadedNVCS = false;
            QLNV_CS_EditNV();
            LoadedNVCS = true;        }

        int CheckXoaNV_QLNV()
        {
            String mnv = txt_QLNV_CS_MaNV.Text;
            ACCOUNT tempacc = dbContext.ACCOUNTs.FirstOrDefault(a => a.MaNV == mnv);
            if(tempacc != null)
            {
                return 1;
            }
            return 0;
        }

        void XoaNV_CSNV()
        {
            int check = CheckXoaNV_QLNV();
            try
            {
                switch (check)
                {
                    case 0:
                        String gioitinh;
                        if (rdb_QLNV_CS_Nam.Checked == true)
                        {
                            gioitinh = "Nữ";
                        }
                        else
                        {
                            gioitinh = "Nam";
                        }
                        String mess = "Bạn chắc chắn muốn xoá nhân viên này:"
                                    + "\nMã nhân viên: " + txt_QLNV_CS_MaNV.Text
                                    + "\nTên nhân viên: " + txt_QLNV_CS_TenNV.Text
                                    + "\nĐịa chỉ: " + txt_QLNV_CS_DiaChi.Text
                                    + "\nEmail: " + txt_QLNV_CS_Email.Text
                                    + "\nSDT: " + txt_QLNV_CS_SDT.Text
                                    + "\nChức vụ: " + txt_QLNV_CS_ChucVu.Text
                                    + "\nGiới tính: " + gioitinh;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            String manv = txt_QLNV_CS_MaNV.Text;
                            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == manv);
                            dbContext.NHANVIENs.Remove(nv);
                            dsnv = dbContext.NHANVIENs.ToList();
                            QLNV_CS_FillDGV(dsnv);
                            ShowOrHide_SelectedMaNV_QLNVCS(false);
                            txt_QLNV_CS_MaNV.Enabled = true;
                            ClearTextBox_QLNVCS();
                            MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK);
                        }
                        break;
                    case 1:
                        MessageBox.Show("Nhân viên đã có tài khoản!\n " +
                                        "Để xoá nhân viên vui lòng xoá tài khoản trước!", "Thông báo", MessageBoxButtons.OK);
                        break;
                }
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }

        private void btn_QLNV_CS_Xoa_Click(object sender, EventArgs e)
        {
            LoadedNVCS = false;
            XoaNV_CSNV();
            LoadedNVCS = true;
        }
        private void dgv_QLNV_CS_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_QLNV_CS.SelectedRows.Count > 0 && LoadedNVCS == true)
            {
                txt_QLNV_CS_MaNV.Enabled = false;
                EnableOrDisable_TextBox_Find_CSNV(true);
                EnableOrDisableButtonCSNV(true);
                txt_QLNV_CS_MaNV.Text = dgv_QLNV_CS.SelectedRows[0].Cells[1].Value?.ToString();
                txt_QLNV_CS_TenNV.Text = dgv_QLNV_CS.SelectedRows[0].Cells[2].Value?.ToString();
                txt_QLNV_CS_SDT.Text = dgv_QLNV_CS.SelectedRows[0].Cells[4].Value?.ToString();
                txt_QLNV_CS_Email.Text = dgv_QLNV_CS.SelectedRows[0].Cells[5].Value?.ToString();
                txt_QLNV_CS_DiaChi.Text = dgv_QLNV_CS.SelectedRows[0].Cells[3].Value?.ToString();
                txt_QLNV_CS_ChucVu.Text = dgv_QLNV_CS.SelectedRows[0].Cells[7].Value?.ToString();
                if (dgv_QLNV_CS.SelectedRows[0].Cells[6].Value?.ToString() == "Nam")
                {
                    rdb_QLNV_CS_Nam.Checked = true;
                    rdb_TNV_Nu.Checked = false;
                }
                else
                {
                    rdb_QLNV_CS_Nu.Checked = true;
                    rdb_TNV_Nam.Checked = false;
                }
                lbl_QLNV_CS_SelectedMaNVValue.Text = dgv_QLNV_CS.SelectedRows[0].Cells[1].Value?.ToString();
                if (string.IsNullOrEmpty(lbl_QLNV_CS_SelectedMaNVValue.Text) == false)
                {
                    ShowOrHide_SelectedMaNV_QLNVCS(true);
                }
            }
        }
        #endregion


    }
}