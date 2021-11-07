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
        ACCOUNT acc = new ACCOUNT();
        public frmXuLy()
        {
            InitializeComponent();
        }

        private void frmXuLy_Load(object sender, EventArgs e)
        {
            XuLy_DonHang_GetTTNV();
            acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username);
            lv = int.Parse(acc.lv);
            List<DONHANG> dhs = dbContext.DONHANGs.ToList();
            Fill_DGV_DonHang_TimKiemDH(dhs, lv);
        }

        #region DonHang
        
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

        #endregion
    }
}
