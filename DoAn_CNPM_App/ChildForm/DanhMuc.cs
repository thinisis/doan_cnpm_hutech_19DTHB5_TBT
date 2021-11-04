using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNPM_App.ChildForm
{
    public partial class frmDanhMuc : Form
    {
        EntityFramework dbContext = new EntityFramework();
        List<NHACUNGCAP> nccs = new List<NHACUNGCAP>();
        List<KHO> khos = new List<KHO>();
        List<LINHKIEN> lks = new List<LINHKIEN>();
        List<LOAILINHKIEN> llks = new List<LOAILINHKIEN>();
        List<HANG> hangs = new List<HANG>();
        List<TINHTRANGLK_GIATRI> ttlks = new List<TINHTRANGLK_GIATRI>();
        bool LoadedQLNCC = false;
        bool LoadedQLKho = false;
        bool LoadedQLLK_LKien = false;
        bool LoadedQLLK_LoaiLK = false;
        bool LoadedQLLK_Hang = false;
        int lv;
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            tabCtrl_DanhMuc.SelectedTab = tab_QLNCC;
            ACCOUNT thisAccount = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString()); //Truyen du lieu username vao tu Properties
            lv = int.Parse(thisAccount.lv);
            nccs = dbContext.NHACUNGCAPs.ToList();
            khos = dbContext.KHOes.ToList();
            lks = dbContext.LINHKIENs.ToList();
            QLLK_LKien_FillAllCBX();
            QLNCC_FillDGV(nccs);
            QLKho_FillDGV(khos);
            QLLK_LKien_FillDGV(lks);
            dpick_QLLK_LKien_NgayNhapKho.Format = DateTimePickerFormat.Custom;
            dpick_QLLK_LKien_NgayNhapKho.CustomFormat = "dd/MM/yyyy"; 
            LoadedQLNCC = true;
            LoadedQLKho = true;
        }

        #region QuanLyNhaCungCap

        #region HamKiemTra
        void QLNCC_Button_Auth(int lv, bool value) //Phan quyen chuc nang nguoi dung
        {
            if (lv != 2)
            {
                btn_QLNCC_Sua.Enabled = value;
                btn_QLNCC_Xoa.Enabled = value;

            }
            else
            {
                btn_QLNCC_ThemNCC.Enabled = false;
                btn_QLNCC_Sua.Enabled = false;
                btn_QLNCC_Xoa.Enabled = false;
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

        int QLNCC_CheckXoa()
        {
            String mancc = txt_QLNCC_MaNCC.Text;
            LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaNCC == mancc);
            if(lk != null)
            {
                return 1; //khong the xoa, van con linh kien voi ma nha cung cap trong csdl
            }
            return 0;
        }

        private int QLNCC_CheckValid()
        {
            if (string.IsNullOrEmpty(txt_QLNCC_MaNCC.Text) == true)
            {
                return 1; //Khong duoc de trong ma nha cung cap
            }
            if (IsValidNumber(txt_QLNCC_SDT.Text) == false)
            {
                return 2; //Sdt khong hop le
            }

            if (string.IsNullOrEmpty(txt_QLNCC_TenNCC.Text) == true)
            {
                return 3; //De trong ten nha cung cap
            }

            if (IsValidEmail(txt_QLNCC_Email.Text) == false)
            {
                return 4; // Email khong hop le
            }
            String mncc = txt_QLNCC_MaNCC.Text;
            NHACUNGCAP nccf = dbContext.NHACUNGCAPs.FirstOrDefault(a => a.MaNCC.CompareTo(mncc) == 0);
            if (nccf != null)
            {
                return 5; //da co nha cung cap tren he thong
            }
            return 0; //Khong co loi
        }
        #endregion
        #region HamThucThi
        void QLNCC_ClearTextBox()
        {
            txt_QLNCC_MaNCC.Text = "";
            txt_QLNCC_TenNCC.Text = "";
            txt_QLNCC_Email.Text = "";
            txt_QLNCC_SDT.Text = "";
        }

        void QLNCC_ShowOrHide_SelectedValue(bool value)
        {
            lbl_QLNCC_SelectedNCCLabel.Visible = value;
            lbl_QLNCC_SelectedNCCValue.Visible = value;
        }
        void QLNCC_FillDGV(List<NHACUNGCAP> ncc)
        {
            QLNCC_Button_Auth(lv, false);
            txt_QLNCC_CountNCCValue.Text = ncc.Count.ToString();
            dgv_QLNCC.Rows.Clear();
            for (int i = 0; i < ncc.Count(); i++)
            {

                int index = dgv_QLNCC.Rows.Add();
                dgv_QLNCC.Rows[i].Cells[0].Value = ncc[i].MaNCC;
                dgv_QLNCC.Rows[i].Cells[1].Value = ncc[i].TenNCC;
                dgv_QLNCC.Rows[i].Cells[2].Value = ncc[i].SDT;
                dgv_QLNCC.Rows[i].Cells[3].Value = ncc[i].Email;
            }
        }
        #endregion
        #region TruyVan

        void QLNCC_Them()
        {
            int c = QLNCC_CheckValid();
            switch (c)
            {
                case 0:
                    try
                    {
                        String mess = "Đồng ý thêm mới nhà cung cấp với thông tin:"
                                    + "\nMã nhà cung cấp: " + txt_QLNCC_MaNCC.Text
                                    + "\nTên nhà cung cấp: " + txt_QLNCC_TenNCC.Text
                                    + "\nEmail: " + txt_QLNCC_Email.Text
                                    + "\nSDT: " + txt_QLNCC_SDT.Text;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {

                            NHACUNGCAP ncc = new NHACUNGCAP();
                            ncc.MaNCC = txt_QLNCC_MaNCC.Text;
                            ncc.TenNCC = txt_QLNCC_TenNCC.Text;
                            ncc.SDT = txt_QLNCC_SDT.Text;
                            ncc.Email = txt_QLNCC_Email.Text;
                            dbContext.NHACUNGCAPs.Add(ncc);
                            dbContext.SaveChanges();
                            nccs = dbContext.NHACUNGCAPs.ToList();
                            QLNCC_FillDGV(nccs);
                            txt_QLNCC_CountNCCValue.Text = nccs.Count.ToString();
                            QLNCC_ClearTextBox();
                            QLNCC_ShowOrHide_SelectedValue(false);
                            MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                    break;
                case 1:
                    MessageBox.Show("Không thể để trống mã nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Mã nhà cung cấp đã có trên hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        void QLNCC_ChinhSua()
        {
            int c = QLNCC_CheckValid();
            switch (c)
            {
                case 0:
                    try
                    {
                        String mess = "Đồng ý thay đổi thông tin thành:"
                                    + "\nMã nhà cung cấp: " + txt_QLNCC_MaNCC.Text
                                    + "\nTên nhà cung cấp: " + txt_QLNCC_TenNCC.Text
                                    + "\nEmail: " + txt_QLNCC_Email.Text
                                    + "\nSDT: " + txt_QLNCC_SDT.Text;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if(dr == DialogResult.OK)
                        {
                            String MaNCC = dgv_QLNCC.SelectedRows[0].Cells[0].Value.ToString();
                            NHACUNGCAP ncc = dbContext.NHACUNGCAPs.FirstOrDefault(d => d.MaNCC.CompareTo(MaNCC) == 0);
                            ncc.TenNCC = txt_QLNCC_TenNCC.Text;
                            ncc.SDT = txt_QLNCC_SDT.Text;
                            ncc.Email = txt_QLNCC_Email.Text;
                            dbContext.SaveChanges();
                            nccs = dbContext.NHACUNGCAPs.ToList();
                            QLNCC_FillDGV(nccs);
                            txt_QLNCC_CountNCCValue.Text = nccs.Count.ToString();
                            QLNCC_ClearTextBox();
                            QLNCC_ShowOrHide_SelectedValue(false);
                            txt_QLNCC_MaNCC.Enabled = true;

                            MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
                    MessageBox.Show("Không thể để trống tên nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 4:
                    MessageBox.Show("Email không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 5:
                    if(txt_QLNCC_MaNCC.Text == lbl_QLNCC_SelectedNCCValue.Text)
                    {
                        try
                        {
                            String mess = "Đồng ý thay đổi thông tin thành:"
                                        + "\nMã nhà cung cấp: " + txt_QLNCC_MaNCC.Text
                                        + "\nTên nhà cung cấp: " + txt_QLNCC_TenNCC.Text
                                        + "\nEmail: " + txt_QLNCC_Email.Text
                                        + "\nSDT: " + txt_QLNCC_SDT.Text;
                            DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.OK)
                            {
                                String MaNCC = dgv_QLNCC.SelectedRows[0].Cells[0].Value.ToString();
                                NHACUNGCAP ncc = dbContext.NHACUNGCAPs.FirstOrDefault(d => d.MaNCC.CompareTo(MaNCC) == 0);
                                ncc.TenNCC = txt_QLNCC_TenNCC.Text;
                                ncc.SDT = txt_QLNCC_SDT.Text;
                                ncc.Email = txt_QLNCC_Email.Text;
                                dbContext.SaveChanges();
                                nccs = dbContext.NHACUNGCAPs.ToList();
                                QLNCC_FillDGV(nccs);
                                txt_QLNCC_CountNCCValue.Text = nccs.Count.ToString();
                                QLNCC_ClearTextBox();
                                QLNCC_ShowOrHide_SelectedValue(false);
                                txt_QLNCC_MaNCC.Enabled = true;
                                MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Mã nhà cung cấp đã có trên hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

            }
        }

        void QLNCC_Xoa()
        {
            int check = QLNCC_CheckXoa();
            switch (check)
            {
                case 0:
                    try
                    {
                        String mess = "Đồng ý xoá nhà cung cấp có thông tin như sau:"
                                            + "\nMã nhà cung cấp: " + txt_QLNCC_MaNCC.Text
                                            + "\nTên nhà cung cấp: " + txt_QLNCC_TenNCC.Text
                                            + "\nEmail: " + txt_QLNCC_Email.Text
                                            + "\nSDT: " + txt_QLNCC_SDT.Text;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            String mancc = txt_QLNCC_MaNCC.Text;
                            NHACUNGCAP ncc = dbContext.NHACUNGCAPs.FirstOrDefault(a => a.MaNCC == mancc);
                            dbContext.NHACUNGCAPs.Remove(ncc);
                            dbContext.SaveChanges();
                            nccs = dbContext.NHACUNGCAPs.ToList();
                            QLNCC_FillDGV(nccs);
                            QLNCC_ClearTextBox();
                            QLNCC_ShowOrHide_SelectedValue(false);
                            txt_QLNCC_MaNCC.Enabled = true;
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                    break;
                case 1:
                    MessageBox.Show("Trong kho vẫn còn linh kiện của đơn vị này, không thể xoá!");
                    break;
            }
        }

        int QLNCC_FindCheck()
        {
            if(string.IsNullOrEmpty(txt_QLNCC_MaNCC.Text) == false && string.IsNullOrEmpty(txt_QLNCC_TenNCC.Text) == true)
            {
                return 1; //Chi tim kiem theo ma nha cung cap
            }
            else
            {
                if (string.IsNullOrEmpty(txt_QLNCC_MaNCC.Text) == true && string.IsNullOrEmpty(txt_QLNCC_TenNCC.Text) == false)
                {
                    return 2; //Chi tim kiem theo ten nha cung cap
                }
                else
                {
                    if((string.IsNullOrEmpty(txt_QLNCC_MaNCC.Text) == false && string.IsNullOrEmpty(txt_QLNCC_TenNCC.Text) == false))
                    {
                        return 3;// Tim kiem theo ca ten va ma nha cung cap
                    }
                }

            }
            return 0; //Khong tim kiem
        }

        void QLNCC_Find()
        {
            try
            {
                String mess;
                int check = QLNCC_FindCheck();
                String mancc = txt_QLNCC_MaNCC.Text;
                String tenncc = txt_QLNCC_TenNCC.Text;
                List<NHACUNGCAP> fncc = new List<NHACUNGCAP>();
                switch (check)
                {
                    case 0:
                        mess = "Vui lòng tìm kiếm theo:\nMã nhà cung cấp\nTên nhà cung cấp\nMã nhà cung cấp và tên nhà cung cấp";
                        MessageBox.Show(mess, "Thông báo");
                        break;
                    case 1:
                        fncc = dbContext.NHACUNGCAPs.Where(a => a.MaNCC == mancc).ToList();
                        QLNCC_FillDGV(fncc);
                        btn_QLNCC_BoTim.Visible = true;
                        mess = "Tìm kiếm thành công, có " + fncc.Count + " kết quả trùng khớp!";
                        MessageBox.Show(mess, "Thông báo");
                        break;
                    case 2:
                        fncc = dbContext.NHACUNGCAPs.Where(a => a.TenNCC == tenncc).ToList();
                        QLNCC_FillDGV(fncc);
                        btn_QLNCC_BoTim.Visible = true;
                        mess = "Tìm kiếm thành công, có " + fncc.Count + " kết quả trùng khớp!";
                        MessageBox.Show(mess, "Thông báo");
                        break;
                    case 3:
                        fncc = dbContext.NHACUNGCAPs.Where(a => a.MaNCC == mancc && a.TenNCC == tenncc).ToList();
                        QLNCC_FillDGV(fncc);
                        btn_QLNCC_BoTim.Visible = true;
                        mess = "Tìm kiếm thành công, có " + fncc.Count + " kết quả trùng khớp!";
                        MessageBox.Show(mess, "Thông báo");
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
            
        }
        #endregion
        #region Event
        private void dgv_QLNCC_SelectionChanged(object sender, EventArgs e)
        {

            if (dgv_QLNCC.SelectedRows.Count > 0 && LoadedQLNCC == true)
            {
                btn_QLNCC_BoChon.Visible = true;
                QLNCC_Button_Auth(lv, true);
                txt_QLNCC_MaNCC.Enabled = false;
                lbl_QLNCC_SelectedNCCValue.Text = dgv_QLNCC.SelectedRows[0].Cells[0].Value?.ToString();
                txt_QLNCC_MaNCC.Text = dgv_QLNCC.SelectedRows[0].Cells[0].Value?.ToString();
                txt_QLNCC_TenNCC.Text = dgv_QLNCC.SelectedRows[0].Cells[1].Value?.ToString();
                txt_QLNCC_SDT.Text = dgv_QLNCC.SelectedRows[0].Cells[2].Value?.ToString();
                txt_QLNCC_Email.Text = dgv_QLNCC.SelectedRows[0].Cells[3].Value?.ToString();
                if (string.IsNullOrEmpty(lbl_QLNCC_SelectedNCCValue.Text) == false)
                {
                    QLNCC_ShowOrHide_SelectedValue(true);
                }
            }
        }
        private void btn_QLNCC_BoChon_Click(object sender, EventArgs e)
        {
            QLNCC_Button_Auth(lv, false);
            QLNCC_ShowOrHide_SelectedValue(false);
            QLNCC_ClearTextBox();
            txt_QLNCC_MaNCC.Enabled = true;
            btn_QLNCC_BoChon.Visible = false;
        }

        private void btn_QLNCC_TimKiem_Click(object sender, EventArgs e)
        {
            LoadedQLNCC = false;
            QLNCC_Find();
            
            LoadedQLNCC = true;
        }

        private void btn_QLNCC_ThemNCC_Click(object sender, EventArgs e)
        {
            LoadedQLNCC = false;
            QLNCC_Them();
            LoadedQLNCC = true;
            

        }

        private void btn_QLNCC_Sua_Click(object sender, EventArgs e)
        {
            LoadedQLNCC = false;
            QLNCC_ChinhSua();
            LoadedQLNCC = true;
            
        }

        private void btn_QLNCC_Xoa_Click(object sender, EventArgs e)
        {
            LoadedQLNCC = false;
            QLNCC_Xoa();
            LoadedQLNCC = true;

        }

        private void btn_QLNCC_BoTim_Click(object sender, EventArgs e)
        {
            LoadedQLNCC = false;
            QLNCC_FillDGV(nccs);
            LoadedQLNCC = true;
            QLNCC_ClearTextBox();
            QLNCC_ShowOrHide_SelectedValue(false);
            QLNCC_Button_Auth(lv, true);
            btn_QLNCC_BoTim.Visible = false;
        }

        #endregion

        #endregion

        #region QuanLyKho

        #region KiemTra
        private int QLKho_Check()
        {
            if (string.IsNullOrEmpty(txt_QLKho_MaKho.Text) == true)
            {
                return 1; //de trong ma kho
            }
            if (string.IsNullOrEmpty(txt_QLKho_TenKho.Text) == true)
            {
                return 2; //De trong ten kho
            }
            String mk = txt_QLKho_MaKho.Text;
            KHO kf = dbContext.KHOes.FirstOrDefault(a => a.MaKho.CompareTo(mk) == 0);
            if (kf != null)
            {
                return 3; //da co kho  tren he thong
            }
            return 0; //Khong co loi
        }

        private int QLKho_CheckFind()
        {
            if(string.IsNullOrEmpty(txt_QLKho_MaKho.Text) == true && string.IsNullOrEmpty(txt_QLKho_TenKho.Text) == true)
            {
                return 1; //de trong ca 2 text box
            }
            else
            {
                if (string.IsNullOrEmpty(txt_QLKho_MaKho.Text) == false && string.IsNullOrEmpty(txt_QLKho_TenKho.Text) == true)
                {
                    return 2; //tim theo ma kho
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_QLKho_MaKho.Text) == true && string.IsNullOrEmpty(txt_QLKho_TenKho.Text) == false)
                    {
                        return 3; //tim theo ten kho
                    }
                }
            }
            return 0;
            
        }
        #endregion

        #region ThucThi

        void QLKho_ClearTextbox()
        {
            txt_QLKho_MaKho.Text = "";
            txt_QLKho_TenKho.Text = "";
            txt_QLKho_SLHangValue.Text = "";
        }
        void QLKho_ButtonAuth(int lv, bool value)
        {
            if(lv != 2)
            {
                btn_QLKho_Sua.Enabled = value;
                btn_QLKho_Xoa.Enabled = value;
            }
            else
            {
                btn_QLKho_Them.Enabled = false;
                btn_QLKho_Sua.Enabled = false;
                btn_QLKho_Xoa.Enabled = false;
            }
        }
        void QLKho_ShowOrHide_SelectedKho(bool value)
        {
            lbl_QLKho_SelectedKhoLabel.Visible = value;
            lbl_QLKho_SelectedKhoValue.Visible = value;
        }

        void QLKho_BoTim()
        {
            QLKho_FillDGV(khos);
            QLKho_ClearTextbox();
            QLKho_ShowOrHide_SelectedKho(false);
            QLNCC_Button_Auth(lv, false);
        }

        #endregion

        #region TruyVan

        void QLKho_Find()
        {
            String makho = txt_QLKho_MaKho.Text;
            String mess;
            String tenkho = txt_QLKho_TenKho.Text;
            List<KHO> fkho = new List<KHO>();
            int check = QLKho_CheckFind();
            switch (check)
            {
                case 0:
                    fkho = dbContext.KHOes.Where(a => a.MaKho == makho && a.TenKho == tenkho).ToList();
                    QLKho_FillDGV(fkho);
                    QLKho_ClearTextbox();
                    QLNCC_Button_Auth(lv, false);
                    btn_QLKho_BoTim.Visible = true;
                    mess = "Có " + fkho.Count + " kết quả phù hợp!";
                    MessageBox.Show(mess, "Thông báo");

                    break;
                case 1:
                    mess = "Phải tìm kiếm theo\nMã kho\nTên kho\nMã kho và tên kho";
                    MessageBox.Show(mess, "Thông báo");
                    break;
                case 2:
                    fkho = dbContext.KHOes.Where(a => a.MaKho == makho).ToList();
                    QLKho_FillDGV(fkho);
                    QLKho_ClearTextbox();
                    QLNCC_Button_Auth(lv, false);
                    btn_QLKho_BoTim.Visible = true;
                    mess = "Có " + fkho.Count + " kết quả phù hợp!";
                    MessageBox.Show(mess, "Thông báo");
                    break;
                case 3:
                    fkho = dbContext.KHOes.Where(a => a.TenKho == tenkho).ToList();
                    QLKho_FillDGV(fkho);
                    QLKho_ClearTextbox();
                    QLNCC_Button_Auth(lv, false);
                    btn_QLKho_BoTim.Visible = true;
                    mess = "Có " + fkho.Count + " kết quả phù hợp!";
                    MessageBox.Show(mess, "Thông báo");
                    break;
            }
        }
        void QLKho_Them()
        {
            int check = QLKho_Check();
            switch (check)
            {
                case 0:
                    try
                    {
                        String mess = "Xác nhận thêm kho mới:"
                            + "\n Mã kho: " + txt_QLKho_MaKho.Text
                            + "\n Tên kho: " + txt_QLKho_TenKho.Text;
                        DialogResult dr = MessageBox.Show(mess, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            KHO kho = new KHO();
                            kho.MaKho = txt_QLKho_MaKho.Text;
                            kho.TenKho = txt_QLKho_TenKho.Text;
                            dbContext.KHOes.Add(kho);
                            dbContext.SaveChanges();
                            khos = dbContext.KHOes.ToList();
                            QLKho_FillDGV(khos);
                            QLKho_ClearTextbox();
                            MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                    break;
                case 1:
                    MessageBox.Show("Không thể để trống mã kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 2:
                    MessageBox.Show("Không thể để trống tên kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3:
                    MessageBox.Show("Mã kho đã có trên hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        int QLKho_CheckXoa()
        {
            String makho = txt_QLKho_MaKho.Text;
            LINHKIEN templk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaKho == makho);
            if(templk != null)
            {
                return 1;
            }
            return 0;
        }

        void QLKho_FillDGV(List<KHO> khos)
        {
            dgv_QLKho.Rows.Clear();
            QLKho_ButtonAuth(lv, false);
            for (int i = 0; i < khos.Count(); i++)
            {
                int index = dgv_QLKho.Rows.Add();
                dgv_QLKho.Rows[i].Cells[0].Value = khos[i].MaKho;
                dgv_QLKho.Rows[i].Cells[1].Value = khos[i].TenKho;
                String makho = khos[i].MaKho;
                int count = dbContext.LINHKIENs.Where(a => a.MaKho == makho).Count();
                dgv_QLKho.Rows[i].Cells[2].Value = count;
            }
        }

        void QLKho_Sua()
        {
            String tenkho = txt_QLKho_TenKho.Text;
            String makho = txt_QLKho_MaKho.Text;
            KHO tempkho = dbContext.KHOes.FirstOrDefault(a => a.MaKho == makho);
            String mess = "Xác nhận thay đổi thông tin:"
                           + "\n Mã kho: " + txt_QLKho_MaKho.Text
                           + "\n Tên kho: " + txt_QLKho_TenKho.Text;
            DialogResult dr = MessageBox.Show(mess, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(tenkho) == false)
                {
                    try
                    {
                        tempkho.TenKho = tenkho;
                        dbContext.SaveChanges();
                        khos = dbContext.KHOes.ToList();
                        QLKho_FillDGV(khos);
                        QLKho_ShowOrHide_SelectedKho(false);
                        QLNCC_Button_Auth(lv, false);
                        QLNCC_ClearTextBox();
                        txt_QLKho_MaKho.Enabled = true;
                        MessageBox.Show("Thao tác thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Không thể để trống tên kho!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
            }
        }

        void QLKho_Xoa()
        {
            int check = QLKho_CheckXoa();
            switch (check)
            {
                case 0:
                    String mess = "Xác nhận xoá kho:"
                           + "\n Mã kho: " + txt_QLKho_MaKho.Text
                           + "\n Tên kho: " + txt_QLKho_TenKho.Text;
                    DialogResult dr = MessageBox.Show(mess, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            String makho = txt_QLKho_MaKho.Text;
                            KHO tempkho = dbContext.KHOes.FirstOrDefault(a => a.MaKho == makho);
                            dbContext.KHOes.Remove(tempkho);
                            dbContext.SaveChanges();
                            khos = dbContext.KHOes.ToList();
                            QLKho_FillDGV(khos);
                            QLKho_ShowOrHide_SelectedKho(false);
                            QLNCC_Button_Auth(lv, false);
                            QLNCC_ClearTextBox();
                            txt_QLKho_MaKho.Enabled = true;
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                    }
                    break;
                case 1:
                    MessageBox.Show("Trong kho vẫn còn hàng! Vui lòng xoá hàng trước!", "Thông báo");
                    break;
            }
        }
        #endregion

        #region Event
        private void dgv_QLKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_QLKho.SelectedRows.Count > 0 && LoadedQLKho == true)
            {
                btn_QLKho_BoChon.Visible = true;
                txt_QLKho_MaKho.Enabled = false;
                txt_QLKho_MaKho.Text = dgv_QLKho.SelectedRows[0].Cells[0].Value?.ToString();
                txt_QLKho_TenKho.Text = dgv_QLKho.SelectedRows[0].Cells[1].Value?.ToString();
                txt_QLKho_SLHangValue.Text = dgv_QLKho.SelectedRows[0].Cells[2].Value?.ToString();
                QLKho_ButtonAuth(lv, true);
                lbl_QLKho_SelectedKhoValue.Text = txt_QLKho_MaKho.Text;
                if(string.IsNullOrEmpty(lbl_QLKho_SelectedKhoValue.Text) == false)
                {
                    QLKho_ShowOrHide_SelectedKho(true);
                }
            }

        }
        private void btn_QLKho_Them_Click(object sender, EventArgs e)
        {
            LoadedQLKho = false;
            QLKho_Them();
            LoadedQLKho = true;
        }

        private void btn_QLKho_BoChon_Click(object sender, EventArgs e)
        {
            QLKho_ShowOrHide_SelectedKho(false);
            QLKho_ClearTextbox();
            QLKho_ButtonAuth(lv, false);
            txt_QLKho_MaKho.Enabled = true;
            btn_QLKho_BoChon.Visible = false;
        }

        private void btn_QLKho_Sua_Click(object sender, EventArgs e)
        {
            LoadedQLKho = false;
            QLKho_Sua();
            LoadedQLKho = true;
        }

        private void btn_QLKho_BoTim_Click(object sender, EventArgs e)
        {
            LoadedQLKho = false;
            QLKho_BoTim();
            LoadedQLKho = true;
            btn_QLKho_BoTim.Visible = false;
        }

        private void btn_QLKho_TimKiem_Click(object sender, EventArgs e)
        {
            LoadedQLKho = false;
            QLKho_Find();
            LoadedQLKho = true;
        }

        private void btn_QLKho_Xoa_Click(object sender, EventArgs e)
        {
            LoadedQLKho = false;
            QLKho_Xoa();
            LoadedQLKho = true;
        }

        #endregion

        #endregion

        #region QuanLyLinhKien

        #region TabPage
        private void btn_QLLK_SelectpageLoaiLKien_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LoaiLK = false;
            llks = dbContext.LOAILINHKIENs.ToList();
            QLLK_LoaiLK_FillDGV(llks);
            page_QuanLyLK.SelectedTab = tabpage_QLLK_LoaiLK;
        }

        private void btn_QLLK_SelectpageHang_Click(object sender, EventArgs e)
        {
            LoadedQLLK_Hang = false;
            hangs = dbContext.HANGs.ToList();
            QLLK_Hang_FillDGV(hangs);
            page_QuanLyLK.SelectedTab = tabpage_QLLK_Hang;
        }

        private void btn_QLLK_SelectpageLKien_Click(object sender, EventArgs e)
        {
            page_QuanLyLK.SelectedTab = tabpage_QLLK_LinhKien;
        }
        #endregion


        #region LinhKien
        #region ThucThi
        void QLLK_LKien_ButtonAuth(int lv, bool value)
        {
            if(lv != 3)
            {
                btn_QLLK_LKien_Sua.Enabled = value;
                btn_QLLK_LKien_Xoa.Enabled = value;
            }
            else
            {
                btn_QLLK_LKien_Them.Enabled = false;
                btn_QLLK_LKien_Sua.Enabled = false;
                btn_QLLK_LKien_Xoa.Enabled = false;
            }
        }

        void QLLK_LKien_ShowOrHide_SelectedMaLK(bool value)
        {
            lbl_QLLK_LKien_SelectedLKienLabel.Visible = value;
            lbl_QLLK_LKien_SelectedMaLKValue.Visible = value;
        }


        void QLLK_LKien_ClearTextBox()
        {
            txt_QLLK_LKien_DonGia.Text = "";
            cbx_QLLK_LKien_Hang.SelectedIndex = 0;
            cbx_QLLK_LKien_Kho.SelectedIndex = 0;
            txt_QLLK_LKien_MaLK.Text = "";
            cbx_QLLK_LKien_LoaiLK.SelectedIndex = 0;
            cbx_QLLK_LKien_NCC.SelectedIndex = 0;
            txt_QLLK_LKien_TenLK.Text = "";
            txt_QLLK_LKien_XuatXu.Text = "";
            txt_QLLK_LKien_Serial.Text = "";
            cbx_QLLK_LKien_TinhTrang.SelectedIndex = 0;
            dpick_QLLK_LKien_NgayNhapKho.Value = DateTime.Today;

        }

        void QLLK_LKien_FillAllCBX()
        {
            List<TINHTRANGLK_GIATRI> ttlk = dbContext.TINHTRANGLK_GIATRI.ToList();
            QLLK_LKien_FillCBX_TTrang(ttlk);
            List<LOAILINHKIEN> llk = dbContext.LOAILINHKIENs.ToList();
            QLLK_LKien_FillCBX_LoaiLK(llk);
            List<KHO> kho = dbContext.KHOes.ToList();
            QLLK_LKien_FillCBX_Kho(kho);
            List<HANG> hang = dbContext.HANGs.ToList();
            QLLK_LKien_FillCBX_Hang(hang);
            List<NHACUNGCAP> ncc = dbContext.NHACUNGCAPs.ToList();
            QLLK_LKien_FillCBX_NCC(ncc);
        }

        void QLLK_LKien_FillCBX_TTrang(List<TINHTRANGLK_GIATRI> ttlk)
        {
            cbx_QLLK_LKien_TinhTrang.DataSource = ttlk;
            cbx_QLLK_LKien_TinhTrang.ValueMember = "TinhTrang";
            cbx_QLLK_LKien_TinhTrang.DisplayMember = "GiaTri";
        }

        void QLLK_LKien_FillCBX_LoaiLK(List<LOAILINHKIEN> llk)
        {
            cbx_QLLK_LKien_LoaiLK.DataSource = llk;
            cbx_QLLK_LKien_LoaiLK.ValueMember = "MaLoai";
            cbx_QLLK_LKien_LoaiLK.DisplayMember = "TenLoai";
        }

        void QLLK_LKien_FillCBX_Kho(List<KHO> kho)
        {
            cbx_QLLK_LKien_Kho.DataSource = kho;
            cbx_QLLK_LKien_Kho.ValueMember = "MaKho";
            cbx_QLLK_LKien_Kho.DisplayMember = "TenKho";
        }

        void QLLK_LKien_FillCBX_Hang(List<HANG> hang)
        {
            cbx_QLLK_LKien_Hang.DataSource = hang;
            cbx_QLLK_LKien_Hang.ValueMember = "MaHang";
            cbx_QLLK_LKien_Hang.DisplayMember = "TenHang";
        }

        void QLLK_LKien_FillCBX_NCC(List<NHACUNGCAP> ncc)
        {
            cbx_QLLK_LKien_NCC.DataSource = ncc;
            cbx_QLLK_LKien_NCC.ValueMember = "MaNCC";
            cbx_QLLK_LKien_NCC.DisplayMember = "TenNCC";
        }

        void QLLK_LKien_FillDGV(List<LINHKIEN> lk)
        {
            QLLK_LKien_ButtonAuth(lv, false);
            LoadedQLLK_LKien = false;
            dgv_QLLK_LKien_ColumnNgayNhap.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_QLLK_LKien.Rows.Clear();
            if (lk.Count > 0)
            {
                txt_QLLK_LKien_LKCountValue.Text = lk.Count.ToString();
                for (int i = 0; i < lk.Count; i++)
                {
                    txt_QLNCC_CountNCCValue.Text = lk.Count.ToString();
                    int index = dgv_QLLK_LKien.Rows.Add();
                    dgv_QLLK_LKien.Rows[i].Cells[0].Value = lk[i].MaLK;
                    dgv_QLLK_LKien.Rows[i].Cells[1].Value = lk[i].LOAILINHKIEN.TenLoai;
                    dgv_QLLK_LKien.Rows[i].Cells[2].Value = lk[i].TenLK;
                    dgv_QLLK_LKien.Rows[i].Cells[3].Value = lk[i].Serial;
                    dgv_QLLK_LKien.Rows[i].Cells[4].Value = lk[i].NgayNhap.ToString();
                    dgv_QLLK_LKien.Rows[i].Cells[5].Value = lk[i].DonGia;
                    dgv_QLLK_LKien.Rows[i].Cells[6].Value = lk[i].XuatXu;
                    dgv_QLLK_LKien.Rows[i].Cells[7].Value = lk[i].KHO.TenKho;
                    dgv_QLLK_LKien.Rows[i].Cells[8].Value = lk[i].NHACUNGCAP.TenNCC;
                    dgv_QLLK_LKien.Rows[i].Cells[9].Value = lk[i].HANG.TenHang;
                    if (lk[i].TinhTrang == true)
                    {
                        dgv_QLLK_LKien.Rows[i].Cells[10].Value = "Còn trong kho";
                    }
                    else
                    {
                        dgv_QLLK_LKien.Rows[i].Cells[10].Value = "Đã bán";
                    }

                }
            }
            LoadedQLLK_LKien = true;
        }

        #endregion
        #region KiemTra
        private int QLLK_LKien_CheckValid(int chucnang)
        {
            if (string.IsNullOrEmpty(txt_QLLK_LKien_MaLK.Text) == true)
            {
                return 1; //trong ma lk
            }
            if (string.IsNullOrEmpty(txt_QLLK_LKien_TenLK.Text) == true)
            {
                 return 2;//trong ten lk
            }
            if (string.IsNullOrEmpty(txt_QLLK_LKien_Serial.Text) == true)
            {
                return 3; //De trong Serial
            }
            if (string.IsNullOrEmpty(txt_QLLK_LKien_DonGia.Text) == true)
            {
                return 4; //de trong don gia
            }
            if (string.IsNullOrEmpty(txt_QLLK_LKien_XuatXu.Text) == true)
            {
                return 5; //De trong xuat xu
            }
            String malk = txt_QLLK_LKien_MaLK.Text;
            LINHKIEN lkf = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK.CompareTo(malk) == 0);
            if (lkf != null && chucnang == 1)
            {
                return 6; //da co mã linh kiện tren he thong
            }

            return 0; //Khong co loi
        }

        int QLLK_LKien_FindCheck()
        {
            if(string.IsNullOrEmpty(txt_QLLK_LKien_MaLK.Text) == false && string.IsNullOrEmpty(txt_QLLK_LKien_TenLK.Text) == false)
            {
                return 1; //Tim theo ma lk va ten lk
            }
            else
            {
                if (string.IsNullOrEmpty(txt_QLLK_LKien_MaLK.Text) == false && string.IsNullOrEmpty(txt_QLLK_LKien_TenLK.Text) == true)
                {
                    return 2; //tim theo ma lk
                }
                else
                {
                    if(string.IsNullOrEmpty(txt_QLLK_LKien_MaLK.Text) == true && string.IsNullOrEmpty(txt_QLLK_LKien_TenLK.Text) == false)
                    {
                        return 3; // tim theo tenlk
                    }
                }

            }
            return 0; //khong co du lieu vao
        }
        #endregion
        #region TruyVan
       
        void QLLK_LKien_ThemLK()
        {
            int check = QLLK_LKien_CheckValid(1);
            switch (check)
            {
                case 0:
                    try
                    {

                        String mess = "Đồng ý thêm mới linh kiện với thông tin:"
                                    + "\nMã linh kiện: " + txt_QLLK_LKien_MaLK.Text
                                    + "\nLoại: " + cbx_QLLK_LKien_LoaiLK.Text.ToString()
                                    + "\nTên linh kiện: " + txt_QLLK_LKien_TenLK.Text
                                    + "\nSerial: " + txt_QLLK_LKien_Serial.Text
                                    + "\nNgày nhập: " + dpick_QLLK_LKien_NgayNhapKho.Text.ToString()
                                    + "\nXuất xứ: " + txt_QLLK_LKien_XuatXu.Text
                                    + "\nĐơn Giá: " + txt_QLLK_LKien_DonGia.Text
                                    + "\nMã kho: " + cbx_QLLK_LKien_Kho.Text.ToString()
                                    + "\nMã nhà cung cấp: " + cbx_QLLK_LKien_NCC.Text.ToString()
                                    + "\nMã hàng: " + cbx_QLLK_LKien_Hang.Text.ToString()
                                    + "\nTình trạng: " + cbx_QLLK_LKien_TinhTrang.Text.ToString();
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            LINHKIEN lk = new LINHKIEN();
                            lk.MaLK = txt_QLLK_LKien_MaLK.Text;
                            lk.MaLoai = cbx_QLLK_LKien_LoaiLK.SelectedValue.ToString();
                            lk.TenLK = txt_QLLK_LKien_TenLK.Text;
                            lk.Serial = txt_QLLK_LKien_Serial.Text;
                            lk.XuatXu = txt_QLLK_LKien_XuatXu.Text;
                            lk.DonGia = float.Parse(txt_QLLK_LKien_DonGia.Text);
                            lk.NgayNhap = DateTime.Parse(dpick_QLLK_LKien_NgayNhapKho.Value.ToString());
                            lk.MaKho = cbx_QLLK_LKien_Kho.SelectedValue.ToString();
                            lk.MaNCC = cbx_QLLK_LKien_NCC.SelectedValue.ToString();
                            lk.MaHang = cbx_QLLK_LKien_Hang.SelectedValue.ToString();
                            lk.TinhTrang = bool.Parse(cbx_QLLK_LKien_TinhTrang.SelectedValue.ToString());

                            dbContext.LINHKIENs.Add(lk);
                            dbContext.SaveChanges();

                            lks = dbContext.LINHKIENs.ToList();
                            QLLK_LKien_FillDGV(lks);
                            txt_QLLK_LKien_LKCountValue.Text = lks.Count.ToString();
                            QLLK_LKien_ClearTextBox();
                            MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");

                    }
                    break;
                case 1:
                    MessageBox.Show("Không thể để trống mã linh kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show("Không thể để trống tên linh kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("Không thể để trống Serial!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 4:
                    MessageBox.Show("Không thể để trống đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 5:
                    MessageBox.Show("Không thể để trống xuất xứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 6:
                    MessageBox.Show("Mã linh kiện đã có trên hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        void QLLK_LKien_SuaLK()
        {
            int check = QLLK_LKien_CheckValid(2);
            switch (check)
            {
                case 0:
                    try
                    {

                        String mess = "Đồng ý sửa linh kiện với thông tin:"
                                    + "\nMã linh kiện: " + txt_QLLK_LKien_MaLK.Text
                                    + "\nLoại: " + cbx_QLLK_LKien_LoaiLK.Text.ToString()
                                    + "\nTên linh kiện: " + txt_QLLK_LKien_TenLK.Text
                                    + "\nSerial: " + txt_QLLK_LKien_Serial.Text
                                    + "\nNgày nhập: " + dpick_QLLK_LKien_NgayNhapKho.Text.ToString()
                                    + "\nXuất xứ: " + txt_QLLK_LKien_XuatXu.Text
                                    + "\nĐơn Giá: " + txt_QLLK_LKien_DonGia.Text
                                    + "\nMã kho: " + cbx_QLLK_LKien_Kho.Text.ToString()
                                    + "\nMã nhà cung cấp: " + cbx_QLLK_LKien_NCC.Text.ToString()
                                    + "\nMã hàng: " + cbx_QLLK_LKien_Hang.Text.ToString()
                                    + "\nTình trạng: " + cbx_QLLK_LKien_TinhTrang.Text.ToString();

                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (dr == DialogResult.OK)
                        {
                            String malk = txt_QLLK_LKien_MaLK.Text;
                            LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == malk);
                            lk.MaLoai = cbx_QLLK_LKien_LoaiLK.SelectedValue.ToString();
                            lk.TenLK = txt_QLLK_LKien_TenLK.Text;
                            lk.Serial = txt_QLLK_LKien_Serial.Text;
                            lk.XuatXu = txt_QLLK_LKien_XuatXu.Text;
                            lk.DonGia = float.Parse(txt_QLLK_LKien_DonGia.Text);
                            lk.NgayNhap = DateTime.Parse(dpick_QLLK_LKien_NgayNhapKho.Value.ToString());
                            lk.MaKho = cbx_QLLK_LKien_Kho.SelectedValue.ToString();
                            lk.MaNCC = cbx_QLLK_LKien_NCC.SelectedValue.ToString();
                            lk.MaHang = cbx_QLLK_LKien_Hang.SelectedValue.ToString();
                            lk.TinhTrang = bool.Parse(cbx_QLLK_LKien_TinhTrang.SelectedValue.ToString());
                            dbContext.SaveChanges();
                            lks = dbContext.LINHKIENs.ToList();
                            QLLK_LKien_FillDGV(lks);
                            QLLK_LKien_ClearTextBox();
                            btn_QLKho_BoChon.Visible = false;
                            QLLK_LKien_ShowOrHide_SelectedMaLK(false);
                            QLLK_LKien_ButtonAuth(lv, false);
                            MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {

                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi");

                    }
                    break;
                case 1:
                    MessageBox.Show("Không thể để trống mã linh kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show("Không thể để trống tên linh kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("Không thể để trống Serial!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 4:
                    MessageBox.Show("Không thể để trống đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 5:
                    MessageBox.Show("Không thể để trống xuất xứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        void QLLK_LKien_Xoa()
        {
            String malk = txt_QLLK_LKien_MaLK.Text;
            LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == malk);
            if (lk != null)
            {
                try
                {
                    String mess = "Đồng ý xoá linh kiện với thông tin:"
                                    + "\nMã linh kiện: " + txt_QLLK_LKien_MaLK.Text;

                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        dbContext.LINHKIENs.Remove(lk);
                        dbContext.SaveChanges();
                        lks = dbContext.LINHKIENs.ToList();
                        QLLK_LKien_FillDGV(lks);
                        QLLK_LKien_ClearTextBox();
                        btn_QLKho_BoChon.Visible = false;
                        QLLK_LKien_ShowOrHide_SelectedMaLK(false);
                        QLLK_LKien_ButtonAuth(lv, false);
                        MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
            }
        }



        void QLLK_LKien_TimKiem()
        {
            String malk = txt_QLLK_LKien_MaLK.Text;
            String tenlk = txt_QLLK_LKien_TenLK.Text;
            List<LINHKIEN> flk = new List<LINHKIEN>();
            String mess;
            int check = QLLK_LKien_FindCheck();
            switch (check)
            {
                case 0:
                   mess = "Vui lòng tìm kiếm theo:" 
                                +"\nMã linh kiện + Tên linh kiện"
                                + "\nMã linh kiện"
                                + "\nTên linh kiện";
                    MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    flk = dbContext.LINHKIENs.Where(a => a.MaLK.Contains(malk) && a.TenLK.Contains(tenlk)).ToList();
                    if(flk.Count == 0)
                    {
                        mess = "Không có kết quả nào phù hợp";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn_QLLK_LKien_BoTim.Visible = true;
                        QLLK_LKien_FillDGV(flk);
                        mess = "Có "+flk.Count+" kết quả!";
                        btn_QLKho_BoTim.Visible = true;
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    flk = dbContext.LINHKIENs.Where(a => a.MaLK.Contains(malk)).ToList();
                    if (flk.Count == 0)
                    {
                        mess = "Không có kết quả nào phù hợp";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn_QLLK_LKien_BoTim.Visible = true;
                        QLLK_LKien_FillDGV(flk);
                        mess = "Có " + flk.Count + " kết quả!";
                        btn_QLKho_BoTim.Visible = true;
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 3:
                    flk = dbContext.LINHKIENs.Where(a => a.TenLK.Contains(tenlk)).ToList();
                    if (flk.Count == 0)
                    {
                        mess = "Không có kết quả nào phù hợp";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn_QLLK_LKien_BoTim.Visible = true;
                        QLLK_LKien_FillDGV(flk);
                        mess = "Có " + flk.Count + " kết quả!";
                        btn_QLKho_BoTim.Visible = true;
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        #endregion
        #region Event
        private void dgv_QLLK_LKien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_QLLK_LKien.SelectedRows.Count > 0 && LoadedQLLK_LKien == true)
            {
                btn_QLLK_LKien_Them.Enabled = false;
                btn_QLLK_LKien_BoChon.Visible = true;
                QLLK_LKien_ButtonAuth(lv, true);
                txt_QLLK_LKien_MaLK.Enabled = false;
                txt_QLLK_LKien_MaLK.Text = dgv_QLLK_LKien.SelectedRows[0].Cells[0].Value?.ToString();
                cbx_QLLK_LKien_LoaiLK.SelectedIndex = cbx_QLLK_LKien_LoaiLK.FindStringExact(dgv_QLLK_LKien.SelectedRows[0].Cells[1].Value?.ToString());
                txt_QLLK_LKien_TenLK.Text = dgv_QLLK_LKien.SelectedRows[0].Cells[2].Value?.ToString();
                txt_QLLK_LKien_Serial.Text = dgv_QLLK_LKien.SelectedRows[0].Cells[3].Value?.ToString();
                if(DateTime.TryParse(dgv_QLLK_LKien.SelectedRows[0].Cells[4].Value?.ToString(), out _) != false)
                {
                    dpick_QLLK_LKien_NgayNhapKho.Value = DateTime.Parse(dgv_QLLK_LKien.SelectedRows[0].Cells[4].Value?.ToString());
                }
                txt_QLLK_LKien_DonGia.Text = dgv_QLLK_LKien.SelectedRows[0].Cells[5].Value?.ToString();
                txt_QLLK_LKien_XuatXu.Text = dgv_QLLK_LKien.SelectedRows[0].Cells[6].Value?.ToString();
                cbx_QLLK_LKien_Kho.SelectedIndex = cbx_QLLK_LKien_Kho.FindStringExact(dgv_QLLK_LKien.SelectedRows[0].Cells[7].Value?.ToString());
                cbx_QLLK_LKien_NCC.SelectedIndex = cbx_QLLK_LKien_NCC.FindStringExact(dgv_QLLK_LKien.SelectedRows[0].Cells[8].Value?.ToString());
                cbx_QLLK_LKien_Hang.SelectedIndex = cbx_QLLK_LKien_Hang.FindStringExact(dgv_QLLK_LKien.SelectedRows[0].Cells[9].Value?.ToString());
                cbx_QLLK_LKien_TinhTrang.SelectedIndex = cbx_QLLK_LKien_TinhTrang.FindStringExact(dgv_QLLK_LKien.SelectedRows[0].Cells[10].Value?.ToString());
                lbl_QLLK_LKien_SelectedMaLKValue.Text = txt_QLLK_LKien_MaLK.Text;
                if(string.IsNullOrEmpty(lbl_QLLK_LKien_SelectedMaLKValue.Text) == false)
                {
                    QLLK_LKien_ShowOrHide_SelectedMaLK(true);
                }
            }
        }

        private void btn_QLLK_LKien_BoChon_Click(object sender, EventArgs e)
        {
            btn_QLLK_LKien_Them.Enabled = true;
            QLLK_LKien_ClearTextBox();
            QLLK_LKien_ShowOrHide_SelectedMaLK(false);
            QLLK_LKien_ButtonAuth(lv, false);
            btn_QLLK_LKien_BoChon.Visible = false;
            txt_QLLK_LKien_MaLK.Enabled = true;
        }

        private void btn_QLLK_LKien_Them_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LKien = false;
            QLLK_LKien_ThemLK();
            LoadedQLLK_LKien = true;
        }

        private void btn_QLLK_LKien_Sua_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LKien = false;
            QLLK_LKien_SuaLK();
            LoadedQLLK_LKien = true;
        }
        private void btn_QLLK_LKien_Xoa_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LKien = false;
            QLLK_LKien_Xoa();
            LoadedQLLK_LKien = true;
        }

        private void btn_QLLK_LKien_TKiem_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LKien = false;
            QLLK_LKien_TimKiem();
            LoadedQLLK_LKien = true;
        }

        private void btn_QLLK_LKien_BoTim_Click(object sender, EventArgs e)
        {
            QLLK_LKien_ClearTextBox();
            QLLK_LKien_ShowOrHide_SelectedMaLK(false);
            QLLK_LKien_ButtonAuth(lv, false);
            btn_QLLK_LKien_BoChon.Visible = false;
            txt_QLLK_LKien_MaLK.Enabled = true;
            btn_QLLK_LKien_BoTim.Visible = false;
            QLLK_LKien_FillDGV(lks);
        }


        #endregion

        #endregion

        #region LoaiLinhKien

        #region KiemTra

        int QLLK_LoaiLK_CheckValid(int chucnang)
        {
            String mallk = txt_QLLK_LoaiLK_MaLoaiLK.Text;
            LOAILINHKIEN llk = dbContext.LOAILINHKIENs.FirstOrDefault(a => a.MaLoai == mallk);
            if(string.IsNullOrEmpty(txt_QLLK_LoaiLK_MaLoaiLK.Text) == true | string.IsNullOrEmpty(txt_QLLK_LoaiLK_TenLoai.Text) == true)
            {
                return 1; // co text box khong co du lieu
            }
            else
            {
                if(llk != null && chucnang == 1)
                {
                    return 2; //da co loailk tren he thong
                }
                if(llk == null && chucnang == 2)
                {
                    return 2;
                }
                if (llk == null && chucnang == 0)
                {
                    return 2;
                }
            }
            return 0;
        }
        int QLLK_LoaiLK_FindCheck()
        {
            if(string.IsNullOrEmpty(txt_QLLK_LoaiLK_MaLoaiLK.Text) == false && string.IsNullOrEmpty(txt_QLLK_LoaiLK_TenLoai.Text) == false)
            {
                return 1; //tim theo maloai va ten
            }
            else
            {
                if(string.IsNullOrEmpty(txt_QLLK_LoaiLK_MaLoaiLK.Text) == false && string.IsNullOrEmpty(txt_QLLK_LoaiLK_TenLoai.Text) == true)
                {
                    return 2; // tim theo ma loai
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_QLLK_LoaiLK_MaLoaiLK.Text) == true && string.IsNullOrEmpty(txt_QLLK_LoaiLK_TenLoai.Text) == false)
                    {
                        return 3; //tim theo ten
                    }
                }
            }
            return 0; // khong co du lieu de tim kiem
        }
        #endregion

        #region ThucThi
        void QLLK_LoaiLK_ClearTextbox()
        {
            txt_QLLK_LoaiLK_MaLoaiLK.Text = "";
            txt_QLLK_LoaiLK_TenLoai.Text = "";
        }

        void QLLK_LoaiLK_ShowOrHide_SelectedMaLLK(bool value)
        {
            lbl_QLLK_LoaiLK_SelectedLoaiLKLabel.Visible = value;
            lbl_QLLK_LoaiLK_SelectedLoaiLKValue.Visible = value;
        }

        void QLLK_LoaiLK_ButtonAuth(int lv, bool value)
        {
            if(lv != 3)
            {
                btn_QLLK_LoaiLK_Sua.Enabled = value;
                btn_QLLK_LoaiLK_Xoa.Enabled = value;
            }
            else
            {
                btn_QLLK_LoaiLK_Them.Enabled = false;
                btn_QLLK_LoaiLK_Sua.Enabled = false;
                btn_QLLK_LoaiLK_Xoa.Enabled = false;
            }
        }

        void QLLK_LoaiLK_FillDGV(List<LOAILINHKIEN> llk)
        {
            dgv_QLLK_LoaiLK.Rows.Clear();
            if(llk.Count > 0)
            {
                for(int i = 0; i < llk.Count; i++)
                {
                    int index = dgv_QLLK_LoaiLK.Rows.Add();
                    dgv_QLLK_LoaiLK.Rows[i].Cells[0].Value = llk[i].MaLoai;
                    dgv_QLLK_LoaiLK.Rows[i].Cells[1].Value = llk[i].TenLoai;
                }
            }
            LoadedQLLK_LoaiLK = true;
            QLLK_LoaiLK_ButtonAuth(lv, false);
        }
        #endregion

        #region TruyVan

        void QLLK_LoaiLK_TimKiem()
        {
            String mallk = txt_QLLK_LoaiLK_MaLoaiLK.Text;
            String tenllk = txt_QLLK_LoaiLK_TenLoai.Text;
            List<LOAILINHKIEN> fllk = new List<LOAILINHKIEN>();
            String mess;
            int check = QLLK_LoaiLK_FindCheck();
            switch (check)
            {
                case 0:
                    mess = "Vui lòng tìm kiếm theo:"
                                + "\nMã loại"
                                + "\nTên loại"
                                + "\nMã loại và tên loại";
                    MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    break;
                case 1:
                    fllk = dbContext.LOAILINHKIENs.Where(a => a.MaLoai.Contains(mallk) && a.TenLoai.Contains(tenllk)).ToList();
                    if(fllk.Count == 0)
                    {
                        mess = "Không tìm thấy kết quả nào!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        mess = "Có "+fllk.Count+" kết quả phù hợp!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                        QLLK_LoaiLK_FillDGV(fllk);
                        btn_QLLK_LoaiLK_BoTim.Visible = true;
                        QLLK_LoaiLK_ClearTextbox();
                    }
                    break;
                case 2:
                    fllk = dbContext.LOAILINHKIENs.Where(a => a.MaLoai.Contains(mallk)).ToList();
                    if (fllk.Count == 0)
                    {
                        mess = "Không tìm thấy kết quả nào!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        mess = "Có " + fllk.Count + " kết quả phù hợp!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                        QLLK_LoaiLK_FillDGV(fllk);
                        btn_QLLK_LoaiLK_BoTim.Visible = true;
                        QLLK_LoaiLK_ClearTextbox();
                    }
                    break;
                case 3:
                    fllk = dbContext.LOAILINHKIENs.Where(a => a.TenLoai.Contains(tenllk)).ToList();
                    if (fllk.Count == 0)
                    {
                        mess = "Không tìm thấy kết quả nào!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        mess = "Có " + fllk.Count + " kết quả phù hợp!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                        QLLK_LoaiLK_FillDGV(fllk);
                        btn_QLLK_LoaiLK_BoTim.Visible = true;
                        QLLK_LoaiLK_ClearTextbox();
                    }
                    break;
            }
        }
        
        void QLLK_LoaiLK_Them()
        {
            LOAILINHKIEN llk = new LOAILINHKIEN();
            int check = QLLK_LoaiLK_CheckValid(1);
            switch (check)
            {
                case 0:
                    String mess = "Xác nhận thêm mới loại linh kiện:"
                                + "\nMã loại: " + txt_QLLK_LoaiLK_MaLoaiLK.Text
                                + "\nTên loại: " + txt_QLLK_LoaiLK_TenLoai.Text;
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if(dr == DialogResult.OK)
                    {
                        try
                        {
                            llk.MaLoai = txt_QLLK_LoaiLK_MaLoaiLK.Text;
                            llk.TenLoai = txt_QLLK_LoaiLK_TenLoai.Text;
                            dbContext.LOAILINHKIENs.Add(llk);
                            dbContext.SaveChanges();
                            llks = dbContext.LOAILINHKIENs.ToList();
                            QLLK_LoaiLK_FillDGV(llks);
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                    }
                    
                    break;
            
                case 1:
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                    break;
                case 2:
                    MessageBox.Show("Mã loại linh kiện đã có trên hệ thống!", "Thông báo");
                    break;
            }
        }

        void QLLK_LoaiLK_Sua()
        {
            int check = QLLK_LoaiLK_CheckValid(2);
            
            switch (check)
            {
                case 0:
                    String mallk = txt_QLLK_LoaiLK_MaLoaiLK.Text;
                    String mess = "Xác nhận sửa loại linh kiện:"
                               + "\nMã loại: " + txt_QLLK_LoaiLK_MaLoaiLK.Text
                               + "\nTên loại: " + txt_QLLK_LoaiLK_TenLoai.Text;
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            LOAILINHKIEN llk = dbContext.LOAILINHKIENs.FirstOrDefault(a => a.MaLoai == mallk);
                            llk.TenLoai = txt_QLLK_LoaiLK_TenLoai.Text;
                            dbContext.SaveChanges();
                            llks = dbContext.LOAILINHKIENs.ToList();
                            QLLK_LoaiLK_FillDGV(llks);
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                    break;
                case 2:
                    MessageBox.Show("Mã loại linh kiện không tồn tại trên hệ thống!", "Thông báo");
                    break;

            }
        }

        void QLLK_LoaiLK_Xoa()
        {
            int check = QLLK_LoaiLK_CheckValid(0);
            String mallk = txt_QLLK_LoaiLK_MaLoaiLK.Text;
            switch (check)
            {
                case 0:
                    String mess = "Xác nhận xoá loại linh kiện:"
                                + "\nMã loại: " + txt_QLLK_LoaiLK_MaLoaiLK.Text
                                + "\nTên loại: " + txt_QLLK_LoaiLK_TenLoai.Text;
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            LOAILINHKIEN llk = dbContext.LOAILINHKIENs.FirstOrDefault(a => a.MaLoai == mallk);
                            dbContext.LOAILINHKIENs.Remove(llk);
                            dbContext.SaveChanges();
                            llks = dbContext.LOAILINHKIENs.ToList();
                            QLLK_LoaiLK_FillDGV(llks);
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                    }
                    break;
                case 2:
                    MessageBox.Show("Mã loại linh kiện không tồn tại trên hệ thống!", "Thông báo");
                    break;
            }
        }
        #endregion

        #region Event
        private void dgv_QLLK_LoaiLK_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv_QLLK_LoaiLK.SelectedRows.Count > 0 && LoadedQLLK_LoaiLK == true)
            {
                
                btn_QLLK_LoaiLK_BoChon.Visible = true;
                txt_QLLK_LoaiLK_MaLoaiLK.Enabled = false;
                btn_QLLK_LoaiLK_Them.Enabled = false;
                txt_QLLK_LoaiLK_MaLoaiLK.Text = dgv_QLLK_LoaiLK.SelectedRows[0].Cells[0].Value?.ToString();
                txt_QLLK_LoaiLK_TenLoai.Text = dgv_QLLK_LoaiLK.SelectedRows[0].Cells[1].Value?.ToString();
                QLLK_LoaiLK_ButtonAuth(lv, true);
                lbl_QLLK_LoaiLK_SelectedLoaiLKValue.Text = txt_QLLK_LoaiLK_MaLoaiLK.Text;
                if(string.IsNullOrEmpty(lbl_QLLK_LoaiLK_SelectedLoaiLKValue.Text) == false)
                {
                    QLLK_LoaiLK_ShowOrHide_SelectedMaLLK(true);
                }
            }
        }

        private void btn_QLLK_LoaiLK_BoChon_Click(object sender, EventArgs e)
        {
            QLLK_LoaiLK_ClearTextbox();
            QLLK_LoaiLK_ButtonAuth(lv, false);
            QLLK_LoaiLK_ShowOrHide_SelectedMaLLK(false);
            txt_QLLK_LoaiLK_MaLoaiLK.Enabled = true;
            btn_QLLK_LoaiLK_Them.Enabled = true;
            btn_QLLK_LoaiLK_BoChon.Visible = false;

        }

        private void btn_QLLK_LoaiLK_Them_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LoaiLK = false;
            QLLK_LoaiLK_Them();
            LoadedQLLK_LoaiLK = true;
        }

        private void btn_QLLK_LoaiLK_Xoa_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LoaiLK = false;
            QLLK_LoaiLK_Xoa();
            LoadedQLLK_LoaiLK = true;
        }
        private void btn_QLLK_LoaiLK_Sua_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LoaiLK = false;
            QLLK_LoaiLK_Sua();
            LoadedQLLK_LoaiLK = true;
        }

        private void btn_QLLK_LoaiLK_TimKiem_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LoaiLK = false;
            QLLK_LoaiLK_TimKiem();
            LoadedQLLK_LoaiLK = true;
        }

        private void btn_QLLK_LoaiLK_BoTim_Click(object sender, EventArgs e)
        {
            QLLK_LoaiLK_ClearTextbox();
            QLLK_LoaiLK_ShowOrHide_SelectedMaLLK(false);
            QLLK_LoaiLK_ButtonAuth(lv, false);
            btn_QLLK_LKien_BoChon.Visible = false;
            btn_QLLK_LKien_BoTim.Visible = false;
            QLLK_LoaiLK_FillDGV(llks);
        }

        #endregion
        #endregion

        #region Hang
        #region KiemTra

        int QLLK_Hang_CheckValid(int chucnang)
        {
            String mahang = txt_QLLK_Hang_MaHang.Text;
            HANG llk = dbContext.HANGs.FirstOrDefault(a => a.MaHang == mahang);
            if (string.IsNullOrEmpty(txt_QLLK_Hang_MaHang.Text) == true | string.IsNullOrEmpty(txt_QLLK_Hang_TenHang.Text) == true)
            {
                return 1; // co text box khong co du lieu
            }
            else
            {
                if (llk != null && chucnang == 1)
                {
                    return 2; //da co loailk tren he thong
                }
                if (llk == null && chucnang == 2)
                {
                    return 2;
                }
                if (llk == null && chucnang == 0)
                {
                    return 2;
                }
            }
            return 0;
        }
        int QLLK_Hang_FindCheck()
        {
            if (string.IsNullOrEmpty(txt_QLLK_Hang_MaHang.Text) == false && string.IsNullOrEmpty(txt_QLLK_Hang_TenHang.Text) == false)
            {
                return 1; //tim theo maloai va ten
            }
            else
            {
                if (string.IsNullOrEmpty(txt_QLLK_Hang_MaHang.Text) == false && string.IsNullOrEmpty(txt_QLLK_Hang_TenHang.Text) == true)
                {
                    return 2; // tim theo ma loai
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_QLLK_Hang_MaHang.Text) == true && string.IsNullOrEmpty(txt_QLLK_Hang_TenHang.Text) == false)
                    {
                        return 3; //tim theo ten
                    }
                }
            }
            return 0; // khong co du lieu de tim kiem
        }
        #endregion

        #region ThucThi
        void QLLK_Hang_ClearTextbox()
        {
            txt_QLLK_Hang_MaHang.Text = "";
            txt_QLLK_Hang_TenHang.Text = "";
        }

        void QLLK_Hang_ShowOrHide_SelectedMaHang(bool value)
        {
            lbl_QLLK_Hang_SelectedHangLabel.Visible = value;
            lbl_QLLK_Hang_SelectedHang_Value.Visible = value;
        }

        void QLLK_Hang_ButtonAuth(int lv, bool value)
        {
            if (lv != 3)
            {
                btn_QLLK_Hang_Sua.Enabled = value;
                btn_QLLK_Hang_Xoa.Enabled = value;
            }
            else
            {
                btn_QLLK_Hang_Them.Enabled = false;
                btn_QLLK_Hang_Sua.Enabled = false;
                btn_QLLK_Hang_Xoa.Enabled = false;
            }
        }

        void QLLK_Hang_FillDGV(List<HANG> hang)
        {
            dgv_QLLK_Hang.Rows.Clear();
            if (hang.Count > 0)
            {
                for (int i = 0; i < hang.Count; i++)
                {
                    int index = dgv_QLLK_Hang.Rows.Add();
                    dgv_QLLK_Hang.Rows[i].Cells[0].Value = hang[i].MaHang;
                    dgv_QLLK_Hang.Rows[i].Cells[1].Value = hang[i].TenHang;
                }
            }
            LoadedQLLK_Hang = true;
            QLLK_Hang_ButtonAuth(lv, false);
        }
        #endregion

        #region TruyVan

        void QLLK_Hang_TimKiem()
        {
            String mahang = txt_QLLK_Hang_MaHang.Text;
            String tenhang = txt_QLLK_Hang_TenHang.Text;
            List<HANG> fhang = new List<HANG>();
            String mess;
            int check = QLLK_Hang_FindCheck();
            switch (check)
            {
                case 0:
                    mess = "Vui lòng tìm kiếm theo:"
                                + "\nMã hãng"
                                + "\nTên hãng"
                                + "\nMã hãng và tên hãng";
                    MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    break;
                case 1:
                    fhang = dbContext.HANGs.Where(a => a.MaHang.Contains(mahang) && a.TenHang.Contains(tenhang)).ToList();
                    if (fhang.Count == 0)
                    {
                        mess = "Không tìm thấy kết quả nào!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        mess = "Có " + fhang.Count + " kết quả phù hợp!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                        QLLK_Hang_FillDGV(fhang);
                        btn_QLLK_Hang_BoTim.Visible = true;
                        QLLK_Hang_ClearTextbox();
                    }
                    break;
                case 2:
                    fhang = dbContext.HANGs.Where(a => a.MaHang.Contains(mahang)).ToList();
                    if (fhang.Count == 0)
                    {
                        mess = "Không tìm thấy kết quả nào!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        mess = "Có " + fhang.Count + " kết quả phù hợp!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                        QLLK_Hang_FillDGV(fhang);
                        btn_QLLK_Hang_BoTim.Visible = true;
                        QLLK_Hang_ClearTextbox();
                    }
                    break;
                case 3:
                    fhang = dbContext.HANGs.Where(a => a.TenHang.Contains(tenhang)).ToList();
                    if (fhang.Count == 0)
                    {
                        mess = "Không tìm thấy kết quả nào!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        mess = "Có " + fhang.Count + " kết quả phù hợp!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK);
                        QLLK_Hang_FillDGV(fhang);
                        btn_QLLK_Hang_BoTim.Visible = true;
                        QLLK_Hang_ClearTextbox();
                    }
                    break;
            }
        }

        void QLLK_Hang_Them()
        {
            HANG hang = new HANG();
            int check = QLLK_Hang_CheckValid(1);
            switch (check)
            {
                case 0:
                    String mess = "Xác nhận thêm mới hãng:"
                                + "\nMã hãng: " + txt_QLLK_Hang_MaHang.Text
                                + "\nTên hãng: " + txt_QLLK_Hang_TenHang.Text;
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            hang.MaHang = txt_QLLK_Hang_MaHang.Text;
                            hang.TenHang = txt_QLLK_Hang_TenHang.Text;
                            dbContext.HANGs.Add(hang);
                            dbContext.SaveChanges();
                            hangs = dbContext.HANGs.ToList();
                            QLLK_Hang_FillDGV(hangs);
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                    }

                    break;

                case 1:
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                    break;
                case 2:
                    MessageBox.Show("Mã hãng đã có trên hệ thống!", "Thông báo");
                    break;
            }
        }

        void QLLK_Hang_Sua()
        {
            int check = QLLK_Hang_CheckValid(2);

            switch (check)
            {
                case 0:
                    String mahang = txt_QLLK_Hang_MaHang.Text;
                    String mess = "Xác nhận sửa thông tin hãng:"
                                + "\nMã hãng: " + txt_QLLK_Hang_MaHang.Text
                                + "\nTên hãng: " + txt_QLLK_Hang_TenHang.Text;
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            HANG hang = dbContext.HANGs.FirstOrDefault(a => a.MaHang == mahang);
                            hang.TenHang = txt_QLLK_Hang_TenHang.Text;
                            dbContext.SaveChanges();
                            hangs = dbContext.HANGs.ToList();
                            QLLK_Hang_FillDGV(hangs);
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                    }
                    break;
                case 1:
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                    break;
                case 2:
                    MessageBox.Show("Mã hãng không tồn tại trên hệ thống!", "Thông báo");
                    break;

            }
        }

        void QLLK_Hang_Xoa()
        {
            int check = QLLK_Hang_CheckValid(0);
            String mahang = txt_QLLK_Hang_MaHang.Text;
            switch (check)
            {
                case 0:
                    String mess = "Xác nhận xoá hãng:"
                                + "\nMã hãng: " + txt_QLLK_Hang_MaHang.Text
                                + "\nTên hãng: " + txt_QLLK_Hang_TenHang.Text;
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            HANG hang = dbContext.HANGs.FirstOrDefault(a => a.MaHang == mahang);
                            dbContext.HANGs.Remove(hang);
                            dbContext.SaveChanges();
                            hangs = dbContext.HANGs.ToList();
                            QLLK_Hang_FillDGV(hangs);
                            MessageBox.Show("Thao tác thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ thao tác!", "Thông báo");
                    }
                    break;
                case 2:
                    MessageBox.Show("Mã hãng không tồn tại trên hệ thống!", "Thông báo");
                    break;
            }
        }
        #endregion

        #region Event
        private void dgv_QLLK_Hang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_QLLK_Hang.SelectedRows.Count > 0 && LoadedQLLK_Hang == true)
            {

                btn_QLLK_Hang_BoChon.Visible = true;
                txt_QLLK_Hang_MaHang.Enabled = false;
                btn_QLLK_Hang_Them.Enabled = false;
                txt_QLLK_Hang_MaHang.Text = dgv_QLLK_Hang.SelectedRows[0].Cells[0].Value?.ToString();
                txt_QLLK_Hang_TenHang.Text = dgv_QLLK_Hang.SelectedRows[0].Cells[1].Value?.ToString();
                QLLK_Hang_ButtonAuth(lv, true);
                lbl_QLLK_Hang_SelectedHang_Value.Text = txt_QLLK_Hang_MaHang.Text;
                if (string.IsNullOrEmpty(lbl_QLLK_Hang_SelectedHang_Value.Text) == false)
                {
                    QLLK_Hang_ShowOrHide_SelectedMaHang(true);
                }
            }
        }

        private void btn_QLLK_Hang_BoChon_Click(object sender, EventArgs e)
        {
            QLLK_Hang_ClearTextbox();
            QLLK_Hang_ButtonAuth(lv, false);
            QLLK_Hang_ShowOrHide_SelectedMaHang(false);
            txt_QLLK_Hang_MaHang.Enabled = true;
            btn_QLLK_Hang_Them.Enabled = true;
            btn_QLLK_Hang_BoChon.Visible = false;

        }

        private void btn_QLLK_Hang_Them_Click(object sender, EventArgs e)
        {
            LoadedQLLK_Hang = false;
            QLLK_Hang_Them();
            LoadedQLLK_Hang = true;
        }

        private void btn_QLLK_Hang_Xoa_Click(object sender, EventArgs e)
        {
            LoadedQLLK_Hang = false;
            QLLK_Hang_Xoa();
            LoadedQLLK_Hang = true;
        }
        private void btn_QLLK_Hang_Sua_Click(object sender, EventArgs e)
        {
            LoadedQLLK_Hang = false;
            QLLK_Hang_Sua();
            LoadedQLLK_Hang = true;
        }

        private void btn_QLLK_Hang_TimKiem_Click(object sender, EventArgs e)
        {
            LoadedQLLK_Hang = false;
            QLLK_Hang_TimKiem();
            LoadedQLLK_Hang = true;
        }

        private void btn_QLLK_Hang_BoTim_Click(object sender, EventArgs e)
        {
            QLLK_Hang_ClearTextbox();
            QLLK_Hang_ShowOrHide_SelectedMaHang(false);
            QLLK_Hang_ButtonAuth(lv, false);
            btn_QLLK_Hang_BoChon.Visible = false;
            btn_QLLK_Hang_BoTim.Visible = false;
            QLLK_Hang_FillDGV(hangs);
        }

        #endregion
        #endregion
        #endregion


    }
}
