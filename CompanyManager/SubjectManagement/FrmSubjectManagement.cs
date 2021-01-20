using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class FrmSubjectManagement : CompanyManager.MDIBaseForm
    {
        public FrmSubjectManagement()
        {
            InitializeComponent();
        }

        private void FrmSubjectManagement_Load(object sender, EventArgs e)
        {
           
            Image img = Properties.Resources.Edit_16x16;
            //Util.CommonUtil.SetDGVDesign();
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit");
            Util.CommonUtil.AddGridTextColumn(dataGridView1,"dfdf","aa");
            //Util.CommonUtil.AddGridTextColumn(dataGridView1,");
       
        }
    }
}
