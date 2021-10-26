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
        bool LoadedQLNCC = false;
        int lv;
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            ACCOUNT thisAccount = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString()); //Truyen du lieu username vao tu Properties
            lv = int.Parse(thisAccount.lv);
            nccs = dbContext.NHACUNGCAPs.ToList();
            QLNCC_FillDGV(nccs);
            LoadedQLNCC = true;
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
                        fncc = dbContext.NHACUNGCAPs.Where(a => a.TenNCC == mancc).ToList();
                        QLNCC_FillDGV(fncc);
                        btn_QLNCC_BoTim.Visible = true;
                        mess = "Tìm kiếm thành công, có " + fncc.Count + " kết quả trùng khớp!";
                        MessageBox.Show(mess, "Thông báo");
                        break;
                    case 3:
                        fncc = dbContext.NHACUNGCAPs.Where(a => a.MaNCC == mancc && a.TenNCC == mancc).ToList();
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


    }
}
