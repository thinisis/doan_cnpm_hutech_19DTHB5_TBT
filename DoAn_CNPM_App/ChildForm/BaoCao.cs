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

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Report.BaoCaoLinhKien form = new Report.BaoCaoLinhKien();
            form.ShowDialog();
        }

        private void btn_XuatBCNV_Click(object sender, EventArgs e)
        {
            Report.BaoCaoNhanVien form = new Report.BaoCaoNhanVien();
            form.ShowDialog();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Report.BaoCaoNCC form = new Report.BaoCaoNCC();
            form.ShowDialog();
        }
    }
}
