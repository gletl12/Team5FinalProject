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
    public partial class SampleControl : CompanyManager.MDIBaseForm
    {
        public SampleControl()
        {
            InitializeComponent();
        }

        private void SampleControl_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Util.CommonExcel.ReadExcelData<MenuVO>("Sheet1");
        }
    }
}
