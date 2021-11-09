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
    public partial class frmXuLy : Form
    {
        EntityFramework dbContext = new EntityFramework();
        int lv;
        bool LoadedQLKH = false;
        bool LoadedQLDH = false;
        List<DONHANG> dhs = new List<DONHANG>();
        List<KHACHHANG> KHs = new List<KHACHHANG>();
        ACCOUNT acc = new ACCOUNT();
        public frmXuLy()
        {
            InitializeComponent();
        }

        private void frmXuLy_Load(object sender, EventArgs e)
        {
            tabCtrl_XuLy.SelectedTab = tabpage_XuLy_DonHang;
            XuLy_DonHang_GetTTNV();
            acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username);
            lv = int.Parse(acc.lv);
            Fill_DGV();
            Format_dPicker_KH();
            KHs = dbContext.KHACHHANGs.ToList();
            QLKH_FillDGV(KHs);
            LoadedQLKH = true;
        }

        #region DonHang
        
        void Fill_DGV()
        {
            LoadedQLDH = false;
            dhs = dbContext.DONHANGs.ToList();
            Fill_DGV_DonHang_TimKiemDH(dhs, lv);
            LoadedQLDH = true;
        }

        void XuLy_DonHang_GetTTNV()
        {
            String username = Properties.Settings.Default.Username;
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == username);
            txt_XuLy_DonHang_MaNV.Text = acc.MaNV;
        }

        bool XuLy_DonHang_CheckMaKH()
        {
            String makh = txt_XuLy_DonHang_MaKH.Text;
            KHACHHANG kh = dbContext.KHACHHANGs.FirstOrDefault(a => a.MaKH == makh);
            if(kh == null)
            {
                return false;
            }
            return true;
        }
        
        bool XuLy_DonHang_CheckMaDH()
        {
            String madh = txt_XuLy_DonHang_MaDH.Text;
            DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
            if(dh != null)
            {
                return false;
            }
            return true;
        }

        int XuLy_DonHang_CheckValid(int chucnang)
        {
            if(string.IsNullOrEmpty(txt_XuLy_DonHang_MaDH.Text) == true)
            {
                return 1; //MaDH bi trong
            }
            else
            {
                if(XuLy_DonHang_CheckMaDH() == false && chucnang == 1)
                {
                    return 2; //MaDH da co trong he thong (Chuc nang them)
                }
                if(XuLy_DonHang_CheckMaKH() == false)
                {
                    return 3; //MaKH khong ton tai
                }
            }
            return 0;
        }

        void XuLy_DonHang_Them()
        {
            int check = XuLy_DonHang_CheckValid(1);
            switch (check)
            {
                case 0:

                    try
                    {
                        String madh = txt_XuLy_DonHang_MaDH.Text;
                        String mess = "Đồng ý tạo mới đơn hàng " + madh + " ?";
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if(dr == DialogResult.OK)
                        {
                            DONHANG dh = new DONHANG();
                            dh.MaDH = txt_XuLy_DonHang_MaDH.Text;
                            dh.MaKH = txt_XuLy_DonHang_MaKH.Text;
                            dh.MaNV = txt_XuLy_DonHang_MaNV.Text;
                            dh.NgayLapDH = DateTime.Now;
                            dh.TongTien = 0;
                            dbContext.DONHANGs.Add(dh);
                            dbContext.SaveChanges();
                            MessageBox.Show("Đã tạo mới đơn hàng, nhấn OK để tiếp tục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XuLy.frmChiTietDonHang form = new XuLy.frmChiTietDonHang(txt_XuLy_DonHang_MaDH.Text);
                            form.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case 1:
                    MessageBox.Show("Không được để trống mã đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show("Mã đơn hàng đã có trên hệ thống, vui lòng thực hiện lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("Mã khách hàng không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void txt_XuLy_DonHang_MaKH_TextChange(object sender, EventArgs e)
        {
            String makh = txt_XuLy_DonHang_MaKH.Text;
            KHACHHANG kh = dbContext.KHACHHANGs.FirstOrDefault(a => a.MaKH == makh);
            if (kh == null)
            {
                lbl_XuLy_DonHang_MaKH_TenKH.Visible = false;
            }
            else
            {
                lbl_XuLy_DonHang_MaKH_TenKH.Text = kh.TenKH.ToString();
                lbl_XuLy_DonHang_MaKH_TenKH.Visible = true;
            }
        }

        private void btn_XuLy_DonHang_TaoDH_Click(object sender, EventArgs e)
        {
            XuLy_DonHang_Them();
            Fill_DGV();
        }




        #endregion

        #region TimKiemDH
        bool XuLy_DonHang_TimKiem_CheckValid()
        {
            DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == txt_XyLy_DonHang_TimKiemDH.Text);
            if(dh == null)
            {
                return false;
            }
            return true;
        }
        private void btn_XuLy_DonHang_TimKiemDH_Click(object sender, EventArgs e)
        {
            bool check = XuLy_DonHang_TimKiem_CheckValid();
            if (check == true)
            {
                DialogResult dr = MessageBox.Show("Đã tìm thấy đơn hàng! Mở chế độ chỉnh sửa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(dr == DialogResult.OK)
                {
                    XuLy.frmChiTietDonHang form = new XuLy.frmChiTietDonHang(txt_XyLy_DonHang_TimKiemDH.Text);
                    form.ShowDialog();
                    Fill_DGV();
                }
                else
                {
                    MessageBox.Show("Đã huỷ bỏ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Fill_DGV_DonHang_TimKiemDH(List<DONHANG> dh, int lv)
        {
            int rowsnum = 0;
            dgv_XuLy_DonHang_TimKiemDH.Rows.Clear();
            if(dh.Count > 0 && lv == 2)
            {
                for(int i = 0; i < dh.Count; i++)
                {
                    if(dh[i].MaNV == acc.MaNV)
                    {
                        int index = dgv_XuLy_DonHang_TimKiemDH.Rows.Add();
                        dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[0].Value = (rowsnum + 1).ToString();
                        dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[1].Value = dh[i].MaDH.ToString();
                        dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[2].Value = dh[i].MaKH.ToString();
                        dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[3].Value = dh[i].KHACHHANG.TenKH.ToString();
                        dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[4].Value = dh[i].MaNV.ToString();
                        dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[5].Value = dh[i].NHANVIEN.TenNV.ToString();
                        dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[6].Value = dh[i].NgayLapDH.ToString();
                        rowsnum++;
                    }
                }
                
            }
            else
            {
                for (int i = 0; i < dh.Count; i++)
                {
                    int index = dgv_XuLy_DonHang_TimKiemDH.Rows.Add();
                    dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[0].Value = (rowsnum + 1).ToString();
                    dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[1].Value = dh[i].MaDH.ToString();
                    dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[2].Value = dh[i].MaKH.ToString();
                    dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[3].Value = dh[i].KHACHHANG.TenKH.ToString();
                    dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[4].Value = dh[i].MaNV.ToString();
                    dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[5].Value = dh[i].NHANVIEN.TenNV.ToString();
                    dgv_XuLy_DonHang_TimKiemDH.Rows[rowsnum].Cells[6].Value = dh[i].NgayLapDH.ToString();
                    rowsnum++;
                }
            }
        }

        private void dgv_XuLy_DonHang_TimKiemDH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_XuLy_DonHang_TimKiemDH.SelectedRows.Count > 0 && dgv_XuLy_DonHang_TimKiemDH.Rows.Count == dhs.Count() && LoadedQLDH == true);
            {
                txt_XyLy_DonHang_TimKiemDH.Text = dgv_XuLy_DonHang_TimKiemDH.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void txt_XyLy_DonHang_TimKiemDH_TextChange(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_XyLy_DonHang_TimKiemDH.Text) == false)
            {
                List<DONHANG> fdh = new List<DONHANG>();
                fdh = dbContext.DONHANGs.Where(a => a.MaDH.Contains(txt_XyLy_DonHang_TimKiemDH.Text)).ToList();
                Fill_DGV_DonHang_TimKiemDH(fdh, lv);
            }
            else
            {
                Fill_DGV_DonHang_TimKiemDH(dhs, lv);
            }
        }

        #endregion

        #region KhachHang

        void Format_dPicker_KH()
        {
            dPicker_QLKH_NgaySinh.CustomFormat = "dd/MM/yyyy";
            dPicker_QLKH_NgaySinh.Format = DateTimePickerFormat.Custom;
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
            if (int.TryParse(sdt, out _) == false)
            {
                return false;
            }

            return true;
        }


        bool IsValidCMND(String cmnd)
        {
            if (cmnd.Length < 9 | cmnd.Length > 14)
            {
                return false;
            }
            if (int.TryParse(cmnd, out _) == false)
            {
                return false;
            }

            return true;
        }
        private int QLKH_CheckValid(int cn)
        {
            if (string.IsNullOrEmpty(txt_QLKH_MaKH.Text) == true && cn == 1)
            {
                return 1; //Khong duoc de trong ma khach hang
            }
            if (IsValidNumber(txt_QLKH_SDT.Text) == false)
            {
                return 2; //Sdt khong hop le
            }

            if (string.IsNullOrEmpty(txt_QLKH_TenKH.Text) == true)
            {
                return 3; //De trong ten khach hang
            }

            if (IsValidEmail(txt_QLKH_Email.Text) == false)
            {
                return 4; // Email khong hop le
            }
            if (IsValidCMND(txt_QLKH_CMND.Text) == false)
            {
                return 5; //CMND không phù hợp
            }
            String mkh = txt_QLKH_MaKH.Text;
            KHACHHANG khf = dbContext.KHACHHANGs.FirstOrDefault(a => a.MaKH.CompareTo(mkh) == 0);
            if (khf != null && cn == 1)
            {
                return 6; //da co khach hang tren he thong
            }

            if(khf == null && cn == 2)
            {
                return 7; //makh khong ton tai
            }
            return 0; //Khong co loi

        }

        void QLKH_ClearTextBox()
        {
            txt_QLKH_MaKH.Text = "";
            txt_QLKH_TenKH.Text = "";
            txt_QLKH_SDT.Text = "";
            txt_QLKH_Email.Text = "";
            dPicker_QLKH_NgaySinh.Value = DateTime.Today;
            txt_QLKH_CMND.Text = "";
        }

        void QLKH_KH_ButtonAuth(int lv, bool value)
        {
            if (lv != 3)
            {
                btn_QLKH_SuaKH.Enabled = value;
                btn_QLKH_XoaKH.Enabled = value;
            }
            else
            {
                btn_QLKH_ThemKH.Enabled = false;
                btn_QLKH_SuaKH.Enabled = false;
                btn_QLKH_XoaKH.Enabled = false;
            }
        }

        void QLKH_FillDGV(List<KHACHHANG> kh)
        {
            dgv_QLKH.Rows.Clear();
            for (int i = 0; i < kh.Count(); i++)
            {
                int index = dgv_QLKH.Rows.Add();
                dgv_QLKH.Rows[i].Cells[0].Value = kh[i].MaKH;
                dgv_QLKH.Rows[i].Cells[1].Value = kh[i].TenKH;
                dgv_QLKH.Rows[i].Cells[2].Value = kh[i].SDT;
                dgv_QLKH.Rows[i].Cells[3].Value = kh[i].Email;
                dgv_QLKH.Rows[i].Cells[4].Value = kh[i].NgaySinh;
                dgv_QLKH.Rows[i].Cells[5].Value = kh[i].CMND;
                if (kh[i].Phai == true)
                {
                    dgv_QLKH.Rows[i].Cells[6].Value = "Nữ";
                }
                else
                {
                    dgv_QLKH.Rows[i].Cells[6].Value = "Nam";
                }
            }
        }
        #region TruyVan
        void QLKH_ThemKH()
        {
            int c = QLKH_CheckValid(1);
            switch (c)
            {
                case 0:
                    try
                    {

                        String mess = "Đồng ý thêm mới khách hàng với thông tin:"
                                    + "\nMã khách hàng: " + txt_QLKH_MaKH.Text
                                    + "\nTên khách hàng: " + txt_QLKH_TenKH.Text
                                    + "\nSố điện thoại: " + txt_QLKH_SDT.Text
                                    + "\nEmail: " + txt_QLKH_Email.Text
                                    + "\nNgày sinh: " + dPicker_QLKH_NgaySinh.Text.ToString()
                                    + "\nChứng minh nhân dân: " + txt_QLKH_CMND.Text;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            KHACHHANG kh = new KHACHHANG();
                            kh.MaKH = txt_QLKH_MaKH.Text;
                            kh.TenKH = txt_QLKH_TenKH.Text;
                            kh.SDT = txt_QLKH_SDT.Text;
                            kh.Email = txt_QLKH_Email.Text;
                            kh.NgaySinh = DateTime.Parse(dPicker_QLKH_NgaySinh.Value.ToString());
                            kh.CMND = txt_QLKH_CMND.Text;
                            if (rdb_QLKH_Nam.Checked == true)
                            {
                                kh.Phai = false;
                            }
                            else
                            {
                                kh.Phai = true;
                            }

                            dbContext.KHACHHANGs.Add(kh);
                            dbContext.SaveChanges();
                            KHs = dbContext.KHACHHANGs.ToList();
                            QLKH_FillDGV(KHs);
                            txt_QLKH_CountKHValue.Text = KHs.Count.ToString();
                            QLKH_ClearTextBox();
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
                    MessageBox.Show("Không thể để trống mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show("Số điện thoại phải từ 10 - 14 kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("Không thể để trống tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 4:
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 5:
                    MessageBox.Show("CMND/CCCD phải dài từ 9 * 14 kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 6:
                    MessageBox.Show("Mã khách hàng đã có trên hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        void QLKH_SuaKH()
        {
            int c = QLKH_CheckValid(2);
            switch (c)
            {
                case 0:
                    try
                    {

                        String mess = "Đồng ý sửa khách hàng với thông tin:"
                                    + "\nMã khách hàng: " + txt_QLKH_MaKH.Text
                                    + "\nTên khách hàng: " + txt_QLKH_TenKH.Text
                                    + "\nSố điện thoại: " + txt_QLKH_SDT.Text
                                    + "\nEmail: " + txt_QLKH_Email.Text
                                    + "\nNgày sinh: " + dPicker_QLKH_NgaySinh.Text.ToString()
                                    + "\nChứng minh nhân dân: " + txt_QLKH_CMND.Text;
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (dr == DialogResult.OK)
                        {
                            KHACHHANG kh = dbContext.KHACHHANGs.FirstOrDefault(a => a.MaKH == txt_QLKH_MaKH.Text);
                            kh.TenKH = txt_QLKH_TenKH.Text;
                            kh.SDT = txt_QLKH_SDT.Text;
                            kh.Email = txt_QLKH_Email.Text;
                            kh.NgaySinh = DateTime.Parse(dPicker_QLKH_NgaySinh.Value.ToString());
                            kh.CMND = txt_QLKH_CMND.Text;
                            if (rdb_QLKH_Nam.Checked == true)
                            {
                                kh.Phai = false;
                            }
                            else
                            {
                                kh.Phai = true;
                            }
                            dbContext.SaveChanges();
                            KHs = dbContext.KHACHHANGs.ToList();
                            QLKH_FillDGV(KHs);
                            QLKH_ClearTextBox();
                            QLKH_ShowOrHide_SelectedMaKH(false);
                            QLKH_KH_ButtonAuth(lv, false);
                            btn_QLKH_BoChon.Visible = false;
                            txt_QLKH_MaKH.Enabled = true;
                            btn_QLKH_ThemKH.Enabled = true;
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
                    MessageBox.Show("Không thể để trống mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show("Số điện thoại phải từ 10 - 14 kí tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("Không thể để trống tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 4:
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 5:
                    MessageBox.Show("CMND/CCCD phải dài từ 9 * 14 kí tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 6:
                    MessageBox.Show("Mã khách hàng không tồn tại trên hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        void QLKH_XoaKH()
        {
            String makh = txt_QLKH_MaKH.Text;
            KHACHHANG kh = dbContext.KHACHHANGs.FirstOrDefault(a => a.MaKH == makh);
            if (kh != null)
            {
                try
                {
                    String mess = "Đồng ý xoá khách hàng với thông tin:"
                                    + "\nMã khách hàng: " + txt_QLKH_MaKH.Text;

                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        dbContext.KHACHHANGs.Remove(kh);
                        dbContext.SaveChanges();
                        KHs = dbContext.KHACHHANGs.ToList();
                        QLKH_FillDGV(KHs);
                        QLKH_ClearTextBox();
                        QLKH_ShowOrHide_SelectedMaKH(false);
                        QLKH_KH_ButtonAuth(lv, false);
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


        #endregion

        int QLKH_FindCheck()
        {
            if (string.IsNullOrEmpty(txt_QLKH_MaKH.Text) == false && string.IsNullOrEmpty(txt_QLKH_TenKH.Text) == false)
            {
                return 1; //Tim theo ma kh va ten kh
            }
            else
            {
                if (string.IsNullOrEmpty(txt_QLKH_MaKH.Text) == false && string.IsNullOrEmpty(txt_QLKH_TenKH.Text) == true)
                {
                    return 2; //tim theo ma kh
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_QLKH_MaKH.Text) == true && string.IsNullOrEmpty(txt_QLKH_TenKH.Text) == false)
                    {
                        return 3; // tim theo ten kh
                    }
                }

            }
            return 0; //khong co du lieu vao
        }
        void QLKH_TimKiemKH()
        {
            String makh = txt_QLKH_MaKH.Text;
            String tenkh = txt_QLKH_TenKH.Text;
            List<KHACHHANG> fkh = new List<KHACHHANG>();
            String mess;
            int c = QLKH_FindCheck();
            switch (c)
            {
                case 0:
                    mess = "Vui lòng tìm kiếm theo:"
                                 + "\nMã khách hàng + Tên khách hàng"
                                 + "\nMã khách hàng"
                                 + "\nTên khách hàng";
                    MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    fkh = dbContext.KHACHHANGs.Where(a => a.MaKH.Contains(makh) && a.TenKH.Contains(tenkh)).ToList();
                    if (fkh.Count == 0)
                    {
                        mess = "Không có kết quả nào phù hợp";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn_QLKH_BoTim.Visible = true;
                        QLKH_FillDGV(fkh);
                        mess = "Có " + fkh.Count + " kết quả!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    fkh = dbContext.KHACHHANGs.Where(a => a.MaKH.Contains(makh)).ToList();
                    if (fkh.Count == 0)
                    {
                        mess = "Không có kết quả nào phù hợp";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn_QLKH_BoTim.Visible = true;
                        QLKH_FillDGV(fkh);
                        mess = "Có " + fkh.Count + " kết quả!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 3:
                    fkh = dbContext.KHACHHANGs.Where(a => a.TenKH.Contains(tenkh)).ToList();
                    if (fkh.Count == 0)
                    {
                        mess = "Không có kết quả nào phù hợp";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn_QLKH_BoTim.Visible = true;
                        QLKH_FillDGV(fkh);
                        mess = "Có " + fkh.Count + " kết quả!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        void QLKH_ShowOrHide_SelectedMaKH(bool value)
        {
            lbl_QLKH_SelectedKHValue.Visible = value;
            lbl_QLKH_SelectedKHLabel.Visible = value;
        }

        private void dgv_QLKH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_QLKH.SelectedRows.Count > 0 && LoadedQLKH == true && string.IsNullOrEmpty(dgv_QLKH.SelectedRows[0].Cells[0].Value?.ToString()) == false)
            {
                btn_QLKH_ThemKH.Enabled = false;
                btn_QLKH_BoChon.Visible = true;
                QLKH_KH_ButtonAuth(lv, true);
                txt_QLKH_MaKH.Enabled = false;
                txt_QLKH_MaKH.Text = dgv_QLKH.SelectedRows[0].Cells[0].Value?.ToString();
                lbl_QLKH_SelectedKHValue.Text = dgv_QLKH.SelectedRows[0].Cells[0].Value?.ToString();
                txt_QLKH_TenKH.Text = dgv_QLKH.SelectedRows[0].Cells[1].Value?.ToString();
                txt_QLKH_SDT.Text = dgv_QLKH.SelectedRows[0].Cells[2].Value?.ToString();
                txt_QLKH_Email.Text = dgv_QLKH.SelectedRows[0].Cells[3].Value?.ToString();
                if (DateTime.TryParse(dgv_QLKH.SelectedRows[0].Cells[4].Value?.ToString(), out _) != false)
                {
                    dPicker_QLKH_NgaySinh.Value = DateTime.Parse(dgv_QLKH.SelectedRows[0].Cells[4].Value?.ToString());
                }
                txt_QLKH_CMND.Text = dgv_QLKH.SelectedRows[0].Cells[5].Value?.ToString();
                if (dgv_QLKH.SelectedRows[0].Cells[6].Value?.ToString() == "Nam")
                {
                    rdb_QLKH_Nam.Checked = true;
                    rdb_QLKH_Nu.Checked = false;
                }
                else
                {
                    rdb_QLKH_Nu.Checked = true;
                    rdb_QLKH_Nam.Checked = false;
                }
                if (string.IsNullOrEmpty(lbl_QLKH_SelectedKHValue.Text) == false)
                {
                    QLKH_ShowOrHide_SelectedMaKH(true);
                   
                }
            }
        }
        private void btn_QLKH_BoChon_Click(object sender, EventArgs e)
        {
            btn_QLKH_ThemKH.Enabled = true;
            QLKH_ClearTextBox();
            QLKH_ShowOrHide_SelectedMaKH(false);
            QLKH_KH_ButtonAuth(lv, false);
            btn_QLKH_BoChon.Visible = false;
            txt_QLKH_MaKH.Enabled = true;
        }

        private void btn_QLKH_ThemKH_Click(object sender, EventArgs e)
        {
            LoadedQLKH = false;
            QLKH_ThemKH();
            LoadedQLKH = true;
        }

        private void btn_QLKH_XoaKH_Click(object sender, EventArgs e)
        {
            LoadedQLKH = false;
            QLKH_XoaKH();
            LoadedQLKH = true;
        }
        private void btn_QLKH_SuaKH_Click(object sender, EventArgs e)
        {
            LoadedQLKH = false;
            QLKH_SuaKH();
            LoadedQLKH = true;
        }

        private void btn_QLKH_TimKiemKH_Click(object sender, EventArgs e)
        {
            LoadedQLKH = false;
            QLKH_TimKiemKH();
            LoadedQLKH = true;
        }

        private void btn_QLKH_BoTim_Click(object sender, EventArgs e)
        {
            QLKH_ClearTextBox();
            QLKH_ShowOrHide_SelectedMaKH(false);
            QLKH_KH_ButtonAuth(lv, false);
            btn_QLKH_BoChon.Visible = false;
            btn_QLKH_BoTim.Visible = false;
            QLKH_FillDGV(KHs);
        }

        #endregion


    }
}
