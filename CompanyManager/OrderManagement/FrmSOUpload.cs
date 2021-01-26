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
    public partial class FrmSOUpload : CompanyManager.MDIBaseForm
    {
        public FrmSOUpload()
        {
            InitializeComponent();
            
        }


        
        private void FrmSOUpload_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.SetDGVDesign_Num(dgvSO);
            CommonUtil.AddGridTextColumn(dgvSO, "planDate", "plan_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "WORK_ORDER_ID", "order_id", 150, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "업체", "company_id", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "업체명", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "품목", "item_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "품명", "item_name", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "MKT", "mkt", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "환종", "currency", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "수량", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "납기일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);


        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            PopupSoUpload popup = new PopupSoUpload();
            if (popup.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
