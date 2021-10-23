using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_CNPM_App
{
    public partial class Loading : Form
    {
        
        public Action Worker { get; set; }
        public Loading(Action worker)
        {
            InitializeComponent();
            if (worker == null) throw new ArgumentNullException();
            Worker = worker;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            ProgressBar(500);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        void ProgressBar(int max)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = max;
            
            for (int i = 0; i <= max; i++)
            {
                progressBar.Value = i; //Gán giá trị cho progressBar
            }
        }
    }
}
