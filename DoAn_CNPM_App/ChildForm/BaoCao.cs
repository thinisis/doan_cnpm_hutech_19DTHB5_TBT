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
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            BaoCao_LK_DateTimePicker_CustomFormat();
            BaoCao_DH_DateTimePicker_CustomFormat();
            cbx_BaoCao_NV_Gtinh.SelectedIndex = 0;
            cbx_BaoCao_KH.SelectedIndex = 0;
        }
        #region BaoCaoLK

        void BaoCao_LK_DateTimePicker_CustomFormat()
        {
            dtpick_BaoCao_LK_TuyChon_begin.Format = DateTimePickerFormat.Custom;
            dtpick_BaoCao_LK_TuyChon_begin.CustomFormat = "dd/MM/yyyy";
            dtpick_BaoCao_LK_TuyChon_end.Format = DateTimePickerFormat.Custom;
            dtpick_BaoCao_LK_TuyChon_end.CustomFormat = "dd/MM/yyyy";
        }

        int BaoCao_LK_Select()
        {
            if(rbtn_BaoCao_Lk_All.Checked == true)
            {
                return 1; //Xuat tat ca
            }
            else
            {
                if(rbtn_BaoCao_Lk_3Thang.Checked == true)
                {
                    return 2; //Xuat 3 thang gan nhat
                }

                if (dtpick_BaoCao_LK_TuyChon_begin.Value > dtpick_BaoCao_LK_TuyChon_end.Value)
                {
                    return 4; //ngay bat dau khong the lon hon ngay ket thuc
                }
                if (rbtn_BaoCao_Lk_TuyChon.Checked == true)
                {
                    return 3; //Xuat theo tuy chon
                }
            }
            return 0;
        }
        private void btn_BaoCao_LK_Xuat_Click(object sender, EventArgs e)
        {
            int check = BaoCao_LK_Select();
            switch (check)
            {
                case 0:
                    MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    Report.BaoCaoLinhKien form1 = new Report.BaoCaoLinhKien(1, DateTime.Now, DateTime.Now, txt_BaoCao_LK_TenBC.Text);
                    form1.ShowDialog();
                    break;
                case 2:
                    Report.BaoCaoLinhKien form2 = new Report.BaoCaoLinhKien(2, DateTime.Now, DateTime.Now, txt_BaoCao_LK_TenBC.Text);
                    form2.ShowDialog();
                    break;
                case 3:
                    Report.BaoCaoLinhKien form3 = new Report.BaoCaoLinhKien(3, dtpick_BaoCao_LK_TuyChon_begin.Value, dtpick_BaoCao_LK_TuyChon_end.Value, txt_BaoCao_LK_TenBC.Text);
                    form3.ShowDialog();
                    break;
                case 4:
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        #endregion

        #region BaoCaoNV
        int BaoCao_NV_Select()
        {
            if(rbtn_BaoCao_NV_All.Checked == true)
            {
                return 1; //Xuat tat ca nhan vien
            }
            else
            {
                if(rbtn_BaoCao_NV_TheoGT.Checked == true)
                {
                    return 2;
                }
            }
            return 0;
        }
        private void btn_XuatBCNV_Click(object sender, EventArgs e)
        {
            int check = BaoCao_NV_Select();
            switch(check)
            {
                case 0:
                    MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    Report.BaoCaoNhanVien form1 = new Report.BaoCaoNhanVien(1, false, txt_BaoCao_NV_TenBC.Text);
                    form1.ShowDialog();
                    break;
                case 2:
                    if(cbx_BaoCao_NV_Gtinh.SelectedIndex == 0)
                    {
                        Report.BaoCaoNhanVien form2 = new Report.BaoCaoNhanVien(2, false, txt_BaoCao_NV_TenBC.Text);
                        form2.ShowDialog();
                    }
                    else
                    {
                        Report.BaoCaoNhanVien form2 = new Report.BaoCaoNhanVien(2, true, txt_BaoCao_NV_TenBC.Text);
                        form2.ShowDialog();
                    }
                    
                    break;
            }
        }

        #endregion

        #region BaoCaoNCC
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Report.BaoCaoNCC form = new Report.BaoCaoNCC();
            form.ShowDialog();
        }

        #endregion

        #region BaoCaoKH
        int BaoCao_KH_Select()
        {
            if (rbtn_BaoCao_KH_All.Checked == true)
            {
                return 1; //Xuat tat ca kh
            }
            else
            {
                if (rbtn_BaoCao_KH_Gioitinh.Checked == true)
                {
                    return 2;
                }
            }
            return 0;
        }
        private void btn_BaoCao_XuatBCKhachHang_Click(object sender, EventArgs e)
        {
            int check = BaoCao_KH_Select();
            switch (check)
            {
                case 0:
                    MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    Report.BaoCaoKhachHang form1 = new Report.BaoCaoKhachHang(1, false, txt_BaoCao_KhachHang.Text);
                    form1.ShowDialog();
                    break;
                case 2:
                    if (cbx_BaoCao_KH.SelectedIndex == 0)
                    {
                        Report.BaoCaoKhachHang form2 = new Report.BaoCaoKhachHang(2, false, txt_BaoCao_KhachHang.Text);
                        form2.ShowDialog();
                    }
                    else
                    {
                        Report.BaoCaoKhachHang form2 = new Report.BaoCaoKhachHang(2, true, txt_BaoCao_KhachHang.Text);
                        form2.ShowDialog();
                    }

                    break;
            }
        }
        #endregion

        #region BaoCaoDonHang
        void BaoCao_DH_DateTimePicker_CustomFormat()
        {
            dtpick_BaoCao_DH_TuyChon_begin.Format = DateTimePickerFormat.Custom;
            dtpick_BaoCao_DH_TuyChon_begin.CustomFormat = "dd/MM/yyyy";
            dtpick_BaoCao_DH_TuyChon_end.Format = DateTimePickerFormat.Custom;
            dtpick_BaoCao_DH_TuyChon_end.CustomFormat = "dd/MM/yyyy";
        }

        int BaoCao_DH_Select()
        {
            if (rbtn_BaoCao_DH_All.Checked == true)
            {
                return 1; //Xuat tat ca
            }
            else
            {
                if (rbtn_BaoCao_DH_Today.Checked == true)
                {
                    return 2; //Xuat ngay hom nay
                }

                if (dtpick_BaoCao_DH_TuyChon_begin.Value > dtpick_BaoCao_DH_TuyChon_end.Value)
                {
                    return 4; //ngay bat dau khong the lon hon ngay ket thuc
                }
                if (rbtn_BaoCao_DH_TuyChon.Checked == true)
                {
                    return 3; //Xuat theo tuy chon
                }
            }
            
            return 0;
        }
        private void btn_BaoCao_DH_Xuat_Click(object sender, EventArgs e)
        {
            int check = BaoCao_DH_Select();
            switch (check)
            {
                case 0:
                    MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    Report.BaoCaoDonHang form1 = new Report.BaoCaoDonHang(1, DateTime.Now, DateTime.Now, txt_BaoCao_DonHang.Text);
                    form1.ShowDialog();
                    break;
                case 2:
                    Report.BaoCaoDonHang form2 = new Report.BaoCaoDonHang(2, DateTime.Now, DateTime.Now, txt_BaoCao_DonHang.Text);
                    form2.ShowDialog();
                    break;
                case 3:
                    Report.BaoCaoDonHang form3 = new Report.BaoCaoDonHang(3, dtpick_BaoCao_DH_TuyChon_begin.Value, dtpick_BaoCao_DH_TuyChon_end.Value, txt_BaoCao_DonHang.Text);
                    form3.ShowDialog();
                    break;
                case 4:
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        #endregion
    }
}
