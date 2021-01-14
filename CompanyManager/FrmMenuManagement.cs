using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class FrmMenuManagement : CompanyManager.MDIBaseForm
    {
        public FrmMenuManagement()
        {
            InitializeComponent();
        }

        private void FrmMenuManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =  Util.CommonExcel.ReadExcelData<MenuVO>("Sheet1");
        }
    }
}
