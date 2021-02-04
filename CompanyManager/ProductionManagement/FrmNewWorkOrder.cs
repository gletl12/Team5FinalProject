using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using Service;
using VO;   
namespace CompanyManager
{
    
    public partial class FrmNewWorkOrder : CompanyManager.MDIBaseForm
    {
        WorkOrderService service = new WorkOrderService();
        List<NewWorkOrderVO> list = new List<NewWorkOrderVO>();
        public FrmNewWorkOrder()
        {
            InitializeComponent();



            CommonUtil.SetInitGridView(dgvWorkOrder);
            CommonUtil.SetDGVDesign_Num(dgvWorkOrder);
            CommonUtil.SetDGVDesign_CheckBox(dgvWorkOrder);
            CommonUtil.AddGridImageColumn(dgvWorkOrder, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품명", "item_name", 130);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "상태", "wo_state", 80,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비코드", "machine_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비명", "machine_name", 120);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획수량", "plan_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "지시수량", "wo_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획시작일", "wo_sdate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "등록사유", "wo_comment", 80);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "소요시간", "taketime", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획완료일", "wo_edate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "작업지시번호", "wo_id", 120, true, DataGridViewContentAlignment.MiddleCenter);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FrmNewWorkOrder_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = dtpFrom.Value.AddDays(30);
            BindingDGV();
        }

        private void BindingDGV()
        {
            list = service.GetNewWorkOrderList(cboDate.Text, dtpFrom.Value, dtpTo.Value);
            dgvWorkOrder.DataSource = list;
        }
    }
}
