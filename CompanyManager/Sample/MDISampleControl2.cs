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
    public partial class MDISampleControl2 : CompanyManager.MDIBaseForm
    {
        public MDISampleControl2()
        {
            InitializeComponent();
        }

        private void MDISampleControl2_Load(object sender, EventArgs e)
        {
            CommonUtil.SetDGVDesign(dataGridView2);
            MenuService service = new MenuService();
            dataGridView2.DataSource = service.GetMenus();

            CommonUtil.SetDGVDesign(dataGridView1);
            dataGridView1.DataSource = service.GetMenus();
        }
    }
}
