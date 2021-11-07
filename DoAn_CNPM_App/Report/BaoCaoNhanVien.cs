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
        int option;
        bool value; //true la nu, false la nam
        String name;
        List<NHANVIEN> listNhanVien = new List<NHANVIEN>();
        public BaoCaoNhanVien(int option, bool value, String name)
        {
            InitializeComponent();
            this.option = option;
            this.value = value;
            this.name = name;
        }

        private void BaoCaoNhanVien_Load(object sender, EventArgs e)
        {
            EntityFramework dbContext = new EntityFramework(); //Khai bao EntityFramework 
            ReportParameter[] param = new ReportParameter[3];
            ACCOUNT acc = dbContext.ACCOUNTs.FirstOrDefault(a => a.username == Properties.Settings.Default.Username.ToString());
            NHANVIEN nv = dbContext.NHANVIENs.FirstOrDefault(a => a.MaNV == acc.MaNV);
            param[0] = new ReportParameter("NguoiLap", nv.TenNV.ToString());
            param[1] = new ReportParameter("NgayXuat", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            if(option == 1)
            {
                listNhanVien = dbContext.NHANVIENs.ToList();
            }
            else
            {
                if(option == 2)
                {
                    listNhanVien = dbContext.NHANVIENs.Where(a => a.Phai == value).ToList();
                }
            }
            if(string.IsNullOrEmpty(name) == true)
            {
                param[2] = new ReportParameter("TenBC", "BÁO CÁO");
            }
            else
            {
                param[2] = new ReportParameter("TenBC", name);
            }
            this.reportViewer1.LocalReport.ReportPath = "BaoCaoNhanVien.rdlc";
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
