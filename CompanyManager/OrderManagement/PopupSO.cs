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
    public partial class PopupSO : CompanyManager.PopupBaseForm
    {
        List<CodeVO> codes = null;
        public PopupSO()
        {
            InitializeComponent();
        }
        public PopupSO(List<CodeVO> codes)
        {
            InitializeComponent();
            this.codes = codes;
        }

        private void PopupSO_Load(object sender, EventArgs e)
        {
            var companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0, new CodeVO() { code = "", name = "선택" });
            var items = (from item in codes where item.category.Equals("ITEM") select item).ToList();
            items.Insert(0, new CodeVO() { code = "", name = "선택" });
            var warehouses = (from warehouse in codes where warehouse.category.Equals("WAREHOUSE") select warehouse).ToList();
            warehouses.Insert(0, new CodeVO() { code = "", name = "선택" });
            var markets = (from market in codes where market.category.Equals("MARKET") select market).ToList();
            markets.Insert(0, new CodeVO() { code = "", name = "선택" });
            var currencies = (from currency in codes where currency.category.Equals("CURRENCY") select currency).ToList();
            currencies.Insert(0, new CodeVO() { code = "", name = "선택" });

            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            CommonUtil.BindingComboBox(cboItem, items, "code", "name");
            CommonUtil.BindingComboBox(cboDest, warehouses, "code", "name");
            CommonUtil.BindingComboBox(cboMkt, markets, "code", "name");
            CommonUtil.BindingComboBox(cboCurrency, currencies, "code", "name");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboCurrency.SelectedValue.ToString().Length < 1 ||
                cboMkt.SelectedValue.ToString().Length < 1 ||
                cboCompany.SelectedValue.ToString().Length < 1 ||
                cboItem.SelectedValue.ToString().Length < 1 ||
                txtOQty.Text.Length < 1
                )
            {
                MessageBox.Show("필수항목을 모두 입력해주십시오.");
                return;
            }
            SalesOrderVO so = new SalesOrderVO()
            {
                company_id = Convert.ToInt32(cboCompany.SelectedValue),
                order_id = txtOrderID.Text,
                warehouse_id = cboDest.SelectedValue.ToString().Length < 1 ? string.Empty : cboDest.SelectedValue.ToString(),
                item_id = cboItem.SelectedValue.ToString(),
                due_date = dtpDueDate.Value,
                so_o_qty = Convert.ToInt32(txtOQty.Text),
                so_s_qty = txtSQty.Text.Length < 1 ? 0 : Convert.ToInt32(txtSQty.Text),
                so_c_qty = txtCQty.Text.Length < 1 ? 0 : Convert.ToInt32(txtCQty.Text),
                plan_date = DateTime.Now,
                mkt = cboMkt.SelectedValue.ToString(),
                currency = cboCompany.SelectedValue.ToString(),
                so_comment = txtComment.Text,
            };
            SalesOrderService service = new SalesOrderService();
            bool result;
            result = service.InsertSO(so);

            if (result)
            {
                MessageBox.Show("등록 성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
