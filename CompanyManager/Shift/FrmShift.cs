using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class FrmShift : CompanyManager.MDIBaseForm
    {
        public FrmShift()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PopupShift popup = new PopupShift();
            popup.Show();
        }
    }
}
