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
    public partial class BaoCaoNhanVien : Form
    {
        public BaoCaoNhanVien()
        {
            InitializeComponent();
        }

        private void BaoCaoNhanVien_Load(object sender, EventArgs e)
        {
            this.Controls.Add(reportViewer1);
            EntityFramework dbContext = new EntityFramework();
            List<NHANVIEN> listNhanVien = dbContext.NHANVIENs.ToList();
            ReportParameter[] param = new ReportParameter[2];
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString());
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == acc.MaNV);
            param[0] = new ReportParameter("NguoiLap", nv.TenNV.ToString());
            param[1] = new ReportParameter("NgayXuat", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            this.reportViewer1.LocalReport.ReportPath = "BaoCaoNhanVien.rdlc"; //nh copy report->debug
            this.reportViewer1.LocalReport.SetParameters(param);
            var reportDataSource = new ReportDataSource("DataSet_NhanVien", listNhanVien);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
