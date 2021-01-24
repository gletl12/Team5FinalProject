using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager.ResourceManagement
{
    public partial class PopupPriceExcel : CompanyManager.PopupBaseForm
    {
        public PopupPriceExcel()
        {
            InitializeComponent();
        }

        private void PopupPriceExcel_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvPrice);
            CommonUtil.SetDGVDesign_Num(dgvPrice);
            CommonUtil.AddGridTextColumn(dgvPrice, "업체", "company_id", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "업체명", "company_name", 100);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            CommonExcel.ReadExcelData("");
        }
    }
}
