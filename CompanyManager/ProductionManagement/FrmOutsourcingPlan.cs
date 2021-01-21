using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class FrmOutsourcingPlan : CompanyManager.MDIBaseForm
    {
        public FrmOutsourcingPlan()
        {
            InitializeComponent();
        }

        private void FrmOutsourcingPlan_Load(object sender, EventArgs e)
        {
            MessageBox.Show("📁");
        }
    }
}
