using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;
using Service;
using System.Linq;
namespace CompanyManager
{
    public partial class FrmRelease : CompanyManager.MDIBaseForm
    {
        DispendService service = new DispendService();
        List<DispendWOVO> wos = new List<DispendWOVO>();
        public FrmRelease()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvWorkOrder);
            CommonUtil.SetDGVDesign_Num(dgvWorkOrder);
            CommonUtil.SetDGVDesign_CheckBox(dgvWorkOrder);
            dgvWorkOrder.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획시작일", "wo_sdate", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "작업지시ID", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비ID", "machine_id", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비명", "machine_name", 140, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품목", "item_id", 140, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품목명", "item_name", 160, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "지시수량", "wo_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "단위", "unit", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "상태명", "wo_state", 120, true, DataGridViewContentAlignment.MiddleCenter);



            CommonUtil.SetInitGridView(dgvDispend);
            CommonUtil.SetDGVDesign_Num(dgvDispend);
            CommonUtil.AddGridTextColumn(dgvDispend, "계획시작일자", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "작업지시ID", "CompanyName", 130, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "설비명", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "소진창고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "품목", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "품명", "CompanyName", 130, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "재고량", "CompanyName", 130, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "요청수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvDispend, "단위", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "상태", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);

            dgvDispend.Rows.Add("2021-01-25", "WO2020012510", "최종조립반", "H_01(Halb 창고_01)", "CHAIR_01", "1인용 의자", "100", "갯수", "작업지시");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmRelease_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddDays(14);
            List<CodeVO> codes = service.GetMachineCodes();
            if (codes != null)
            {
                codes.Insert(0, new CodeVO() { name = "전체", code = "" });
                CommonUtil.BindingComboBox(cboMachine, codes, "code", "name");
            }
            BindingWorkOrder();
        }

        private void BindingWorkOrder()
        {
            wos = service.GetWorkOrderList(dtpFrom.Value, dtpTo.Value);
            if (wos == null)
            {
                MessageBox.Show("목록을 불러오는중 오류가 발생했습니다.");
                return;
            }
            dgvWorkOrder.DataSource = wos;
        }



        /// <summary>
        /// 여기부터
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingWorkOrder();
            var searchResult = (from wo in wos
                                where
                                (
                                (txtItem.Text.Length < 1 || wo.item_id.Equals(txtItem.Text) || wo.item_name.Contains(txtItem.Text)) &&
                                (txtWOID.Text.Length < 1 || wo.wo_id.Equals(Convert.ToInt32(txtWOID.Text))) &&
                                (cboMachine.Text.Equals("전체") || wo.machine_id.Equals(cboMachine.SelectedValue.ToString()))
                                )
                                select wo).ToList();
            dgvWorkOrder.DataSource = null;
            dgvWorkOrder.DataSource = searchResult;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<int> selectedRows = new List<int>();
            for (int i = 0; i < dgvWorkOrder.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvWorkOrder[0, i].Value))
                {
                    selectedRows.Add(Convert.ToInt32(dgvWorkOrder["wo_id", i].Value));
                }
            }
            if (selectedRows.Count < 1)
            {
                MessageBox.Show("자재를 불출할 작업을 선택해 주십시오.");
                return;
            }
            bool result = service.GetDispendInfo(selectedRows);

            if (result)
            {
                MessageBox.Show("등록 성공");
                btnSearch.PerformClick();
            }
            else
                MessageBox.Show("등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
        }
    }
}
