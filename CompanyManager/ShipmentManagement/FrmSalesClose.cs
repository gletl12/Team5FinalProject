using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmSalesClose : CompanyManager.MDIBaseForm
    {
        List<SalesOrderVO> list = new List<SalesOrderVO>();

        public FrmSalesClose()
        {
            InitializeComponent();

        }

        private void GetSO()
        {
            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.SetDGVDesign_Num(dgvSO);
            CommonUtil.AddGridCheckColumn(dgvSO, "");
            CommonUtil.AddGridTextColumn(dgvSO, "SO ID", "so_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "PO ID", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "고객사", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "도착지", "warehouse_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "주문수량", "so_o_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "출하수량", "so_s_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "취소수량", "so_c_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "매출확정수량", "s_cf_qty", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "매출확정금액", "s_cf_price", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "마감일자", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);

            checkBox1.Location = new Point(dgvSO.Location.X + 54, dgvSO.Location.Y + 5);
            SOListRoad();
        }

        private void SOListRoad()
        {
            SalesOrderService service = new SalesOrderService();
            list = service.GetSOList();

            dgvSO.DataSource = list;
            dgvSO.ClearSelection();

        }

        private void FrmSalesClose_Load(object sender, EventArgs e)
        {
            GetSO();
        }
    }
}
