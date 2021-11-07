using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNPM_App.Report
{
    public partial class XuatHoaDon : Form
    {
        String madh;
        public XuatHoaDon(String madh)
        {
            InitializeComponent();
            this.madh = madh;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XuatHoaDon_Load(object sender, EventArgs e)
        {
            EntityFramework dbContext = new EntityFramework();
            ReportParameter[] param = new ReportParameter[6];
            List<XULY_CTDONHANG> xlct = new List<XULY_CTDONHANG>();
            List<CTDONHANG> ctdh = dbContext.CTDONHANGs.Where(a => a.MaDH == madh).ToList();
            if(ctdh.Count > 0)
            {
                for(int i = 0; i < ctdh.Count; i++)
                {
                    XULY_CTDONHANG xl = new XULY_CTDONHANG();
                    xl.TenLK = ctdh[i].LINHKIEN.TenLK;
                    xl.DonGia = ctdh[i].DonGia;
                    xl.SoLuong = ctdh[i].SoLuong;
                    xl.GiamGia = ctdh[i].GiamGia;
                    xlct.Add(xl);
                }
            }
            DONHANG dh = dbContext.DONHANGs.FirstOrDefault(a => a.MaDH == madh);
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString());
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == acc.MaNV);
            param[0] = new ReportParameter("TenNV", nv.TenNV.ToString());
            param[1] = new ReportParameter("NgayXuat", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            param[2] = new ReportParameter("TongTien", dh.TongTien.ToString());
            if(dh.NgayGiao == null)
            {
                param[3] = new ReportParameter("NgayHenGiao", "Chưa có");
            }
            else
            {
                param[3] = new ReportParameter("NgayHenGiao", dh.NgayGiao.ToString());
            }
            param[4] = new ReportParameter("TenKH", dh.KHACHHANG.TenKH.ToString());
            param[5] = new ReportParameter("MaHD", madh);
            this.reportViewer1.LocalReport.ReportPath = "XuLy_DonHang.rdlc";
            this.reportViewer1.LocalReport.SetParameters(param);
            var reportDataSource = new ReportDataSource("DataSet_XuLyDonHang", xlct);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
