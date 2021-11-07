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
            cbx_BaoCao_NV_Gtinh.SelectedIndex = 0;
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
                if(rbtn_BaoCao_Lk_TuyChon.Checked == true)
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
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Report.BaoCaoNCC form = new Report.BaoCaoNCC();
            form.ShowDialog();
        }

        
    }
}
