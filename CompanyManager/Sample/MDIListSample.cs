using Service;
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
    public partial class MDIListSample : CompanyManager.MDIBaseForm
    {
        public MDIListSample()
        {
            InitializeComponent();
        }

        private void SampleControl_Load(object sender, EventArgs e)
        {
            CommonUtil.SetDGVDesign(dataGridView2);
            MenuService service = new MenuService();
            dataGridView2.DataSource = service.GetMenus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PopupSample frm = new PopupSample();
            frm.Show();
           
        }
    }
}
