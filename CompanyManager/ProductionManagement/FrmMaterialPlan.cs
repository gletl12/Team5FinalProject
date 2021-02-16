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
    public partial class FrmMaterialPlan : CompanyManager.MDIBaseForm
    {
        public FrmMaterialPlan()
        {
            InitializeComponent();
        }

        private void FrmMaterialPlan_Load(object sender, EventArgs e)
        {
            dtpend.Value = dtpstart.Value.AddDays(30);

            btnsearch.PerformClick();

        }
        private void SetDGV()
        {
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            dataGridView1.AutoGenerateColumns = true;
            CommonUtil.AddGridTextColumn(dataGridView1, "설비", "item_id", 200, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dataGridView1, "공정", "item_name", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "item_type", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "품목", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "항목", "항목", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "회사", "company_name", 120, false, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "창고", "warehouse_name", 120, false, DataGridViewContentAlignment.MiddleCenter);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpstart.Value, dtpend.Value) > 0)
            {
                MessageBox.Show("종료일자는 시작일자보다 커야합니다.");
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            SetDGV();

            Service.PlanService service = new Service.PlanService();
            
            DataTable dt = service.GetMeterialPlan(dtpstart.Value, dtpend.Value);

            //품목정보로 검색
            var temp = from plan in dt.AsEnumerable()
                       where (plan.Field<string>("company_name").ToString().Contains(cboCompany.Text) &&
                                    plan.Field<string>("항목").ToString().Contains(txtItem.Text) &&
                                    plan.Field<string>("warehouse_name").ToString().Contains(cbowarehouse.Text))
                       select plan;

            dataGridView1.DataSource = temp.AsDataView();

        }
    }
}
