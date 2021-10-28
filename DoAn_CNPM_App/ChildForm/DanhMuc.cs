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
            tabCtrl_DanhMuc.SelectedTab = tabpage_QLNCC;
            ACCOUNT thisAccount = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString()); //Truyen du lieu username vao tu Properties
            lv = int.Parse(thisAccount.lv);
            nccs = dbContext.NHACUNGCAPs.ToList();
            khos = dbContext.KHOes.ToList();
            lks = dbContext.LINHKIENs.ToList();
            QLNCC_FillDGV(nccs);
            QLKho_FillDGV(khos);
            QLLK_LKien_FillDGV(lks);
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
            txt_QLNCC_CountNCCValue.Text = ncc.Count.ToString();
            dgv_QLNCC.Rows.Clear();
            for (int i = 0; i < ncc.Count(); i++)
            {
                QLNCC_Button_Auth(lv, false);
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
            page_QuanLyLK.SelectedTab = tabpage_QLLK_LoaiLK;
        }

        private void btn_QLLK_SelectpageHang_Click(object sender, EventArgs e)
        {
            LoadedQLLK_Hang = false;
            page_QuanLyLK.SelectedTab = tabpage_QLLK_Hang;
        }

        private void btn_QLLK_SelectpageLKien_Click(object sender, EventArgs e)
        {
            LoadedQLLK_LKien = false;
            page_QuanLyLK.SelectedTab = tabpage_QLLK_LKien;
        }
        #endregion
        #region LinhKien
        #region ThucThi
        void QLLK_LKien_ClearTextBox()
        {
            txt_QLLK_LKien_DonGia.Text = "";
            txt_QLLK_LKien_MaHang.Text = "";
            txt_QLLK_LKien_MaKho.Text = "";
            txt_QLLK_LKien_MaLK.Text = "";
            txt_QLLK_LKien_MaLoai.Text = "";
            txt_QLLK_LKien_NhaCungCap.Text = "";
            txt_QLLK_LKien_TenLK.Text = "";
            txt_QLLK_LKien_XuatXu.Text = "";
            cbx_QLLK_LKien_TinhTrang.SelectedIndex = 0;
            dpick_QLLK_LKien_NgayNhapKho.Value = DateTime.Today;

        }
        #endregion
        #region KiemTra

        #endregion
        #region TruyVan
        void QLLK_LKien_FillDGV(List<LINHKIEN> lk)
        {
            dgv_QLLK_LKien_ColumnNgayNhap.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgv_QLLK_LKien.Rows.Clear();
            if(lk.Count > 0)
            {
                for(int i = 0; i < lk.Count; i++)
                {
                    int index = dgv_QLLK_LKien.Rows.Add();
                    dgv_QLLK_LKien.Rows[i].Cells[0].Value = lk[i].MaLK;
                    dgv_QLLK_LKien.Rows[i].Cells[1].Value = lk[i].MaLoai;
                    dgv_QLLK_LKien.Rows[i].Cells[2].Value = lk[i].TenLK;
                    dgv_QLLK_LKien.Rows[i].Cells[3].Value = lk[i].NgayNhap;
                    dgv_QLLK_LKien.Rows[i].Cells[4].Value = lk[i].DonGia;
                    dgv_QLLK_LKien.Rows[i].Cells[5].Value = lk[i].XuatXu;
                    dgv_QLLK_LKien.Rows[i].Cells[6].Value = lk[i].MaKho;
                    dgv_QLLK_LKien.Rows[i].Cells[7].Value = lk[i].MaNCC;
                    dgv_QLLK_LKien.Rows[i].Cells[8].Value = lk[i].MaHang;
                    if(lk[i].TINHTRANGLK.TinhTrang == true)
                    {
                        dgv_QLLK_LKien.Rows[i].Cells[9].Value = "Còn trong kho";
                    }
                    else
                    {
                        dgv_QLLK_LKien.Rows[i].Cells[9].Value = "Đã bán";
                    }
                    
                }
            }
        }
        #endregion

        #region Event
        #endregion
        #endregion
        #endregion


    }
}
