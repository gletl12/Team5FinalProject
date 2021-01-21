using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager
{
    public partial class FrmPurchase : CompanyManager.MDIBaseForm
    {
        public FrmPurchase()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CommonUtil.OpenCreateForm<PopupPurchase>();
        }
    }
}
