using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmSO : CompanyManager.MDIBaseForm
    {
        SalesOrderService service = new SalesOrderService();
        List<CodeVO> codes = new List<CodeVO>();
        List<SalesOrderVO> list = new List<SalesOrderVO>();
        public FrmSO()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.SetDGVDesign_Num(dgvSO);
            CommonUtil.AddGridImageColumn(dgvSO, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvSO, "WORK_ORDER_ID", "order_id", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "업체", "company_id", 60);
            CommonUtil.AddGridTextColumn(dgvSO, "업체명", "company_name", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "도착지코드", "warehouse_id", 80);
            CommonUtil.AddGridTextColumn(dgvSO, "도착지명", "warehouse_name", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "품목", "item_id", 80);
            CommonUtil.AddGridTextColumn(dgvSO, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "주문수량", "so_o_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "출고수량", "so_s_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "취소수량", "so_c_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "납기일", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "상태", "so_state", 90);
            CommonUtil.AddGridTextColumn(dgvSO, "비고", "so_comment", 80, true, DataGridViewContentAlignment.MiddleCenter);


        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "V")
            {
                btnDown.Text = "ᐱ";
                int size = this.Size.Height;
                btnDown.Location = new Point(btnDown.Location.X, 71);
                btnSearch.Location = new Point(btnSearch.Location.X, 70);



                pnlSearch.Size = new Size(pnlSearch.Size.Width, 114);
                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance + 38;

            }
            else
            {
                btnDown.Text = "V";

                btnDown.Location = new Point(btnDown.Location.X, 38);
                btnSearch.Location = new Point(btnSearch.Location.X, 37);
                pnlSearch.Size = new Size(pnlSearch.Size.Width, pnlSearch.Size.Height * 2 / 3);


                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance - 38;
            }
        }



        private void FrmSO_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = dtpFrom.Value.AddYears(1);
            codes = service.GetAllCodes();
            List<CodeVO> companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0, new CodeVO() { code = "", name = "전체" });
            //var items = (from item in codes where item.category.Equals("ITEM") select item).ToList();
            var states = (from state in codes where state.category.Equals("SO_STATE") select state).ToList();
            var warehouses = (from warehouse in codes where warehouse.category.Equals("WAREHOUSE") select warehouse).ToList();
            states.Insert(0, new CodeVO() { code = "", name = "전체" });
            warehouses.Insert(0, new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            //CommonUtil.BindingComboBox(cboItem, items, "code", "name");
            CommonUtil.BindingComboBox(cboState, states, "code", "name");
            CommonUtil.BindingComboBox(cboDest, warehouses, "code", "name");
            GetAllSO();
        }

        private void GetAllSO()
        {
            list = service.GetAllSO();
            dgvSO.DataSource = list;
        }

        private void dgvSO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit 클릭
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 조회버튼 클릭
            var sResult = (from so in list
                           where
           (so.due_date > dtpFrom.Value && so.due_date < dtpTo.Value) &&
           (cboCompany.SelectedValue.ToString().Length < 1 || so.company_id.Equals(Convert.ToInt32(cboCompany.SelectedValue))) &&
           so.order_id.Contains(txtOrderID.Text) &&
           (cboState.SelectedValue.ToString().Length < 1 || so.so_state.Equals(cboState.Text)) &&
           (txtItem.Text.Length < 1 || so.item_id.Equals(txtItem.Text) || so.item_name.Contains(txtItem.Text)) &&
           (cboDest.SelectedValue.ToString().Length < 1 || so.warehouse_id.Equals(cboDest.SelectedValue.ToString())) &&
           (dtpRegDate.Format != DateTimePickerFormat.Short || so.ins_date.ToShortDateString().Equals(dtpRegDate.Value.ToShortDateString()))
                           select so
           ).ToList();
            if (sResult.Count < 1)
            {
                MessageBox.Show("검색된 결과가 없습니다.");
                return;
            }
            dgvSO.DataSource = null;
            dgvSO.DataSource = sResult;
        }

        private void dtpRegDate_ValueChanged_1(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
        }

        private void btnNewSO_Click(object sender, EventArgs e)
        {
            PopupSO popup = new PopupSO(codes);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                GetAllSO();
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
