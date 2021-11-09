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
    public partial class BaoCaoDonHang : Form
    {
        int option;
        DateTime begin;
        DateTime end;
        String name;
        List<DONHANG> dh = new List<DONHANG>();
        public BaoCaoDonHang(int option, DateTime begin, DateTime end, String name)
        {
            InitializeComponent();
            this.option = option;
            this.name = name;
            if (option == 3)
            {
                this.begin = begin;
                this.end = end;
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BaoCaoDonHang_Load(object sender, EventArgs e)
        {
            EntityFramework dbContext = new EntityFramework();
            ReportParameter[] param = new ReportParameter[3];
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString());
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == acc.MaNV);
            param[0] = new ReportParameter("NguoiLap", nv.TenNV.ToString());
            param[1] = new ReportParameter("NgayXuat", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            if (string.IsNullOrEmpty(name) == true)
            {
                param[2] = new ReportParameter("TenBC", "Báo cáo");
            }
            else
            {
                param[2] = new ReportParameter("TenBC", name);
            }
            if (option == 1)
            {
                dh = dbContext.DONHANGs.ToList();
            }
            else
            {
                if (option == 2)
                {
                    end = DateTime.Today.AddDays(+1);
                    begin = DateTime.Today.AddDays(-1);
                    dh = dbContext.DONHANGs.Where(a => a.NgayGiao > begin && a.NgayGiao < end).ToList();
                }
                else
                {
                    if (option == 3)
                    {
                        end.AddDays(+1);
                        dh = dbContext.DONHANGs.Where(a => a.NgayGiao >= begin && a.NgayGiao <= end).ToList();
                    }
                }
            }
            this.reportViewer1.LocalReport.ReportPath = "BaoCaoDonHang.rdlc";
            this.reportViewer1.LocalReport.SetParameters(param);
            var reportDataSource = new ReportDataSource("DataSet_DonHang", dh);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
