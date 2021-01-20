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
    public partial class FrmFactoryList : CompanyManager.MDIBaseForm
    {
        public FrmFactoryList()
        {
            InitializeComponent();
        }

        private void FrmFactoryList_Load(object sender, EventArgs e)
        {
            GetdgvColumn();
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign(dgvFactory);

            CommonUtil.AddGridTextColumn(dgvFactory, "No.", "no");
            CommonUtil.AddGridCheckColumn(dgvFactory, "");
            CommonUtil.AddGridCheckColumn(dgvFactory, "No.");
            CommonUtil.AddGridTextColumn(dgvFactory, "No.", "no");
            CommonUtil.AddGridTextColumn(dgvFactory, "No.", "no");
            CommonUtil.AddGridTextColumn(dgvFactory, "No.", "no");
            CommonUtil.AddGridTextColumn(dgvFactory, "No.", "no");
        }
    }
}
