using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNPM_App.XuLy
{
    public partial class frmChiTietDonHang : Form
    {
        EntityFramework dbContext = new EntityFramework();
        String madh;
        bool Loaded = false;
        List<LINHKIEN> lks = new List<LINHKIEN>();
        List<CTDONHANG> ctdhs = new List<CTDONHANG>();
        public frmChiTietDonHang(String MaDH)
        {
            InitializeComponent();
            this.madh = MaDH;
        }

        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {
            String formTitle = "Thông tin đơn hàng " + madh;
            this.Text = formTitle;
            lks = dbContext.LINHKIENs.ToList();
            Fill_Find_DGV(lks);
            ctdhs = dbContext.CTDONHANGs.Where(a => a.MaDH == madh).ToList();
            Fill_DonHang_DGV(ctdhs);
            LoadTTDH();
            DateTimePicker_Format();
            EnableOrDisable_Button(false);
            Loaded = true;
        }

        void DateTimePicker_Format()
        {
            dtpicker_XuLy_DonHang_NgayXuatHang.CustomFormat = ("dd/MM/yyyy");
            dtpicker_XuLy_DonHang_NgayXuatHang.Format = DateTimePickerFormat.Custom;
        }

        void LoadTTDH()
        {
            DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
            List<CTDONHANG> ctdh = dbContext.CTDONHANGs.Where(a => a.MaDH == dh.MaDH).ToList();
            if(ctdh != null)
            {
                txt_XuLy_DonHang_SLHang.Text = ctdh.Count.ToString();
                txt_XuLy_DonHang_TongTien.Text = dh.TongTien.ToString();
                if(dh.NgayGiao != null)
                {
                    dtpicker_XuLy_DonHang_NgayXuatHang.Value = DateTime.Parse(dh.NgayGiao.ToString());
                }
            }
        }

        void EnableOrDisable_Button(bool value)
        {
            btn_XuLy_DonHang_ChinhSua.Enabled = value;
            btn_XuLy_DonHang_Xoa.Enabled = value;
        }

        void EnableOrDisable_Textbox(bool value)
        {
            txt_XuLy_DonHang_MaLK.Enabled = value;
            txt_XuLy_DonHang_DonGia.Enabled = value;
        }

        void ClearTextbox()
        {
            number_SL.Value = 0;
            txt_XuLy_DonHang_DonGia.Text = "";
            txt_XuLy_DonHang_GiamGia.Text = "";
            txt_XuLy_DonHang_MaLK.Text = "";
        }

        void Fill_Find_DGV(List<LINHKIEN> lk)
        {
            dgv_Search.Rows.Clear();
            int rowsnum = 0;
            if(lk.Count > 0)
            {
                for(int i = 0; i < lk.Count; i++)
                {
                    if(lk[i].TinhTrang == true)
                    {
                        int index = dgv_Search.Rows.Add();
                        dgv_Search.Rows[rowsnum].Cells[0].Value = lk[i].MaLK;
                        dgv_Search.Rows[rowsnum].Cells[1].Value = lk[i].TenLK;
                        dgv_Search.Rows[rowsnum].Cells[2].Value = lk[i].DonGia;
                        dgv_Search.Rows[rowsnum].Cells[3].Value = lk[i].SoLuong;
                        rowsnum++;
                    }
                }
            }
        }

        void Fill_DonHang_DGV(List<CTDONHANG> ctdh)
        {
            txt_XuLy_DonHang_TongTien.Text = "0";
            double ThanhTien = 0;
            dgv_ChiTietDonHang.Rows.Clear();
            if(ctdh.Count > 0)
            {
                txt_XuLy_DonHang_SLHang.Text = ctdh.Count.ToString();
                for(int i = 0; i < ctdh.Count; i++)
                {
                    int index = dgv_ChiTietDonHang.Rows.Add();
                    dgv_ChiTietDonHang.Rows[i].Cells[0].Value = (i+1).ToString();
                    dgv_ChiTietDonHang.Rows[i].Cells[1].Value = ctdh[i].MaLK.ToString();
                    dgv_ChiTietDonHang.Rows[i].Cells[2].Value = ctdh[i].LINHKIEN.TenLK.ToString();
                    dgv_ChiTietDonHang.Rows[i].Cells[3].Value = ctdh[i].DonGia.ToString();
                    dgv_ChiTietDonHang.Rows[i].Cells[4].Value = ctdh[i].SoLuong.ToString();
                    dgv_ChiTietDonHang.Rows[i].Cells[5].Value = ctdh[i].GiamGia.ToString();
                    ThanhTien = (ctdh[i].DonGia * ctdh[i].SoLuong) - ctdh[i].GiamGia;
                    txt_XuLy_DonHang_TongTien.Text = (ThanhTien + double.Parse(txt_XuLy_DonHang_TongTien.Text)).ToString();
                    dgv_ChiTietDonHang.Rows[i].Cells[6].Value = ThanhTien.ToString();
                }
            }
        }
        bool CheckSL_Hang()
        {
            LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
            if (int.Parse(number_SL.Value.ToString()) > lk.SoLuong || int.Parse(number_SL.Value.ToString()) <= 0)
            {
                return false;
            }
            return true;
        }

        bool CheckSL_Hang_Sua()
        {
            LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
            CTDONHANG ctdh = dbContext.CTDONHANGs.FirstOrDefault(a => a.MaDH == madh && a.MaLK == txt_XuLy_DonHang_MaLK.Text);
            if(number_SL.Value <= ctdh.SoLuong)
            {
                return true;
            }
            else
            {
                if(number_SL.Value > ctdh.SoLuong)
                {
                    decimal SL = (number_SL.Value - ctdh.SoLuong);
                    if(SL <= lk.SoLuong)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        int Check_Valid_Input(int chucnang)
        {
            LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
            if(string.IsNullOrEmpty(txt_XuLy_DonHang_MaLK.Text) == true || string.IsNullOrEmpty(txt_XuLy_DonHang_DonGia.Text) == true | string.IsNullOrEmpty(txt_XuLy_DonHang_GiamGia.Text) == true)
            {
                return 4; //Thieu du lieu nhap vao
            }
            if(lk == null)
            {
                return 5; // Linh kien khong ton tai 
            }
            if(lk.TinhTrang == false)
            {
                return 6; //linh kien khong dc ban
            }
            if(int.TryParse(txt_XuLy_DonHang_DonGia.Text, out _) == false || int.Parse(txt_XuLy_DonHang_DonGia.Text) < 0 ) 
            {
                return 1; //Don gia am hoac khong hop le
            }
            else
            {
                if(int.TryParse(txt_XuLy_DonHang_GiamGia.Text, out _) == false || int.Parse(txt_XuLy_DonHang_GiamGia.Text) < 0)
                {
                    return 2; //Giam gia am hoac khong hop le
                }
                else
                {
                    CTDONHANG ct = dbContext.CTDONHANGs.FirstOrDefault(a => a.MaDH == madh && a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                    if(ct != null && chucnang == 1)
                    {
                        return 3; //Mat hang da co trong don hang
                    }
                    else
                    {
                        lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                        int? sl = lk.SoLuong - int.Parse(number_SL.Value.ToString());
                        if (sl < 0 | sl == null)
                        {
                            return 5; //so luong khong hop le
                        }
                    }

                }
            }
            return 0;
        }

        private void txt_XuLy_DonHang_TimLK_TextChange(object sender, EventArgs e)
        {
            Loaded = false;
            if(string.IsNullOrEmpty(txt_XuLy_DonHang_TimLK.Text) == false)
            {
                List<LINHKIEN> flk = dbContext.LINHKIENs.Where(a => a.TenLK.Contains(txt_XuLy_DonHang_TimLK.Text) | a.MaLK.Contains(txt_XuLy_DonHang_TimLK.Text)).ToList();
                Fill_Find_DGV(flk);
            }
            else
            {
                Fill_Find_DGV(lks);
            }
            Loaded = true;
        }

        private void dgv_Search_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv_Search.SelectedRows.Count > 0 && Loaded == true)
            {
                btn_BoChon.Visible = true;
                EnableOrDisable_Textbox(false);
                txt_XuLy_DonHang_MaLK.Text = dgv_Search.SelectedRows[0].Cells[0].Value?.ToString();
                txt_XuLy_DonHang_DonGia.Text = dgv_Search.SelectedRows[0].Cells[2].Value?.ToString();
            }
            
        }

        private void btn_BoChon_Click(object sender, EventArgs e)
        {
            EnableOrDisable_Button(false);
            btn_XuLy_DonHang_ThemVao.Enabled = true;
            btn_BoChon.Visible = false;
            ClearTextbox();
            EnableOrDisable_Textbox(true);
        }

        void ThemHang_CTDonHang()
        {
            int check = Check_Valid_Input(1);
            switch (check)
            {
                case 0:
                    if(CheckSL_Hang() == true)
                    {
                        try
                        {
                            String mess = "Xác nhận thêm mới linh kiện " + txt_XuLy_DonHang_MaLK.Text + " với số lượng là " + number_SL.Value.ToString();
                            DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if(dr == DialogResult.OK)
                            {
                                CTDONHANG ct = new CTDONHANG();
                                ct.MaDH = madh;
                                ct.MaLK = txt_XuLy_DonHang_MaLK.Text;
                                ct.SoLuong = int.Parse(number_SL.Value.ToString());
                                ct.DonGia = double.Parse(txt_XuLy_DonHang_DonGia.Text);
                                ct.GiamGia = double.Parse(txt_XuLy_DonHang_GiamGia.Text);
                                LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                                lk.SoLuong = lk.SoLuong - int.Parse(number_SL.Value.ToString());
                                dbContext.CTDONHANGs.Add(ct);
                                dbContext.SaveChanges();
                                ctdhs = dbContext.CTDONHANGs.Where(a => a.MaDH == madh).ToList();
                                Fill_DonHang_DGV(ctdhs);
                                DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
                                dh.TongTien = double.Parse(txt_XuLy_DonHang_TongTien.Text);
                                dbContext.SaveChanges();
                                EnableOrDisable_Textbox(true);
                                btn_BoChon.Visible = false;
                                ClearTextbox();
                                lks = dbContext.LINHKIENs.ToList();
                                Fill_Find_DGV(lks);
                                MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Đã huỷ bỏ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                        LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                        String mess = "Số lượng hàng không thể vượt quá " + lk.SoLuong + " và nhỏ hơn 0!";
                        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case 1:
                    MessageBox.Show("Đơn giá không hợp lệ hoặc nhỏ hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 2:
                    MessageBox.Show("Giảm giá không hợp lệ hoặc nhỏ hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 3:
                    MessageBox.Show("Linh kiện đã có trong đơn hàng, chỉ có thể sửa hoặc xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 4:
                    MessageBox.Show("Vui lòng điền đẩy đủ vào các ô trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 5:
                    MessageBox.Show("Mã linh kiện không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 6:
                    MessageBox.Show("Linh kiện trong trạng thái không được bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void btn_XuLy_DonHang_ThemVao_Click(object sender, EventArgs e)
        {
            Loaded = false;
            ThemHang_CTDonHang();
            Loaded = true;
        }
        private void btn_XuLy_DonHang_ChinhSua_Click(object sender, EventArgs e)
        {
            Loaded = false;
            XuLy_DonHang_ChinhSua();
            Loaded = true;
        }

        private void btn_XuLy_DonHang_InDH_Click(object sender, EventArgs e)
        {
            Report.XuatHoaDon form = new Report.XuatHoaDon(madh);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btn_DatNgayGiao_Click(object sender, EventArgs e)
        {
            DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
            dh.NgayGiao = dtpicker_XuLy_DonHang_NgayXuatHang.Value;
            dbContext.SaveChanges();
            String mess = "Đã đặt ngày giao là " + dtpicker_XuLy_DonHang_NgayXuatHang.Value.ToString();
            MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_ChiTietDonHang_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv_ChiTietDonHang.SelectedRows.Count > 0 && Loaded == true)
            {
                EnableOrDisable_Button(true);
                btn_XuLy_DonHang_ThemVao.Enabled = false;
                btn_BoChon.Visible = true;
                txt_XuLy_DonHang_MaLK.Text = dgv_ChiTietDonHang.SelectedRows[0].Cells[1].Value?.ToString();
                txt_XuLy_DonHang_DonGia.Text = dgv_ChiTietDonHang.SelectedRows[0].Cells[3].Value?.ToString();
                number_SL.Value = int.Parse(dgv_ChiTietDonHang.SelectedRows[0].Cells[4].Value?.ToString());
            }
        }

        void XuLy_DonHang_ChinhSua()
        {
            int check = Check_Valid_Input(2);
            switch (check)
            {
                case 0:
                    if (CheckSL_Hang_Sua() == true)
                    {
                        try
                        {
                            String mess = "Xác nhận chỉnh sửa linh kiện " + txt_XuLy_DonHang_MaLK.Text + " với số lượng là " + number_SL.Value.ToString();
                            DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                CTDONHANG ctc = dbContext.CTDONHANGs.FirstOrDefault(a => a.MaDH == madh && a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                                CTDONHANG ct = ctc;
                                decimal soluongcu = ctc.SoLuong;
                                dbContext.CTDONHANGs.Remove(ctc);
                                dbContext.SaveChanges();
                                ct.SoLuong = int.Parse(number_SL.Value.ToString());
                                ct.DonGia = double.Parse(txt_XuLy_DonHang_DonGia.Text);
                                ct.GiamGia = double.Parse(txt_XuLy_DonHang_GiamGia.Text);
                                LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                                if (soluongcu < number_SL.Value)
                                {
                                    lk.SoLuong = lk.SoLuong - int.Parse((number_SL.Value - soluongcu).ToString());

                                }
                                else
                                {
                                    if (soluongcu > number_SL.Value)
                                    {
                                        lk.SoLuong = lk.SoLuong + int.Parse((soluongcu - number_SL.Value).ToString());
                                    }
                                }
                                dbContext.CTDONHANGs.Add(ct);
                                dbContext.SaveChanges();
                                ctdhs = dbContext.CTDONHANGs.Where(a => a.MaDH == madh).ToList();
                                Fill_DonHang_DGV(ctdhs);
                                DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
                                dh.TongTien = double.Parse(txt_XuLy_DonHang_TongTien.Text);
                                dbContext.SaveChanges();
                                EnableOrDisable_Textbox(true);
                                btn_BoChon.Visible = false;
                                btn_XuLy_DonHang_ThemVao.Enabled = true;
                                ClearTextbox();
                                lks = dbContext.LINHKIENs.ToList();
                                Fill_Find_DGV(lks);
                                MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Đã huỷ bỏ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                            
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Lỗi");
                        }
                    }
                    else
                    {
                    LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                    String mess = "Số lượng hàng tăng thêm không thể vượt quá " + lk.SoLuong + " và số lượng không thể nhỏ hơn 0!";
                    MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case 1:
                    MessageBox.Show("Đơn giá không hợp lệ hoặc nhỏ hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 2:
                    MessageBox.Show("Giảm giá không hợp lệ hoặc nhỏ hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 4:
                    MessageBox.Show("Vui lòng điền đẩy đủ vào các ô trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 5:
                    MessageBox.Show("Mã linh kiện không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        int CheckXoaLK()
        {
            if(string.IsNullOrEmpty(txt_XuLy_DonHang_MaLK.Text) == true)
            {
                return 1; //trong ma lk
            }
            else
            {
                CTDONHANG ct = dbContext.CTDONHANGs.FirstOrDefault(a => a.MaDH == madh && a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                if (ct == null)
                {
                    return 2; // ctdh khong ton tai
                }
            }
            return 0;
        }

        void XoaLK()
        {
            int check = CheckXoaLK();
            switch (check)
            {
                case 0:
                    try
                    {
                        String mess = "Xác nhận xoá linh kiện " + txt_XuLy_DonHang_MaLK.Text + " với số lượng là " + number_SL.Value.ToString();
                        DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            CTDONHANG ctdh = dbContext.CTDONHANGs.FirstOrDefault(a => a.MaDH == madh && a.MaLK == txt_XuLy_DonHang_MaLK.Text);
                            int soluong = ctdh.SoLuong;
                            String malk = ctdh.MaLK;
                            dbContext.CTDONHANGs.Remove(ctdh);
                            dbContext.SaveChanges();
                            if (soluong > 0)
                            {
                                LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == malk);
                                lk.SoLuong = lk.SoLuong + soluong;
                                dbContext.SaveChanges();
                                lks = dbContext.LINHKIENs.ToList();
                                Fill_Find_DGV(lks);
                            }
                            ctdhs = dbContext.CTDONHANGs.Where(a => a.MaDH == madh).ToList();
                            Fill_DonHang_DGV(ctdhs);
                            DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
                            dh.TongTien = double.Parse(txt_XuLy_DonHang_TongTien.Text);
                            dbContext.SaveChanges();
                            EnableOrDisable_Textbox(true);
                            btn_BoChon.Visible = false;
                            btn_XuLy_DonHang_ThemVao.Enabled = true;
                            ClearTextbox();
                            MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đã huỷ bỏ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Mã linh kiện không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void btn_XuLy_DonHang_Xoa_Click(object sender, EventArgs e)
        {
            Loaded = false;
            XoaLK();
            Loaded = true;
        }

        bool CheckDH_Valid()
        {
            DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
            if(dh == null)
            {
                return false;
            }
            return true;
        }

        void XoaDH()
        {
            if(CheckDH_Valid() == true)
            {
                try
                {
                    String mess = "Bạn có chắc chắn xoá đơn hàng " + madh + " hay không? \nThao tác này sẽ không thể khôi phục";
                    DialogResult dr = MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.OK)
                    {
                        List<CTDONHANG> lct = dbContext.CTDONHANGs.Where(a => a.MaDH == madh).ToList();
                        if(lct.Count > 0)
                        {
                            for(int i = 0; i < lct.Count; i++)
                            {
                                String malk = lct[i].MaLK;
                                int soluong = lct[i].SoLuong;
                                if (soluong > 0)
                                {
                                    LINHKIEN lk = dbContext.LINHKIENs.FirstOrDefault(a => a.MaLK == malk);
                                    lk.SoLuong = lk.SoLuong + soluong;
                                    dbContext.SaveChanges();
                                }
                            }
                            dbContext.CTDONHANGs.RemoveRange(lct);
                            dbContext.SaveChanges();
                        }

                        DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
                        dbContext.DONHANGs.Remove(dh);
                        dbContext.SaveChanges();
                        MessageBox.Show("Thao tác thành công! Nhấn OK để thoát", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã huỷ bỏ thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Đơn hàng không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btn_XuLy_DonHang_XoaDonHang_Click(object sender, EventArgs e)
        {
            XoaDH();
        }
    }
}
