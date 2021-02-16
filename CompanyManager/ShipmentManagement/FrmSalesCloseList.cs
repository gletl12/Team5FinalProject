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
    public partial class FrmSalesCloseList : CompanyManager.MDIBaseForm
    {
        public FrmSalesCloseList()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridTextColumn(dataGridView2, "SO ID", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "PO ID", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "고객사", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "도착지", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "주문수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "출하수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "취소수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "매출확정수량", "CompanyName", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "매출확정금액", "CompanyName", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "마감일자", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null, "10002", "", "의자상사", "의자상사", "CHAIR_01", "나무 1인용 의자", "200", "200", "0", "100", "100,000", "2021-01-30");
            dataGridView2.Rows.Add(null, "10003", "", "의자상사", "의자상사", "CHAIR_01", "나무 1인용 의자", "300", "300", "0", "100", "100,000", "2021-01-30");
        }


    }
}
