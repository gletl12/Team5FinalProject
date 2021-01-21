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
    public partial class FrmPurchaseList : CompanyManager.MDIBaseForm
    {
        public FrmPurchaseList()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridTextColumn(dataGridView2, "발주번호", "CompanyName", 130);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "발주상태", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "단위", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "납기일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "발주량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "입고량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "취소량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "취소가능량", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "발주일", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleCenter);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null,  "1394-0001", "(주)시트","발주상태" ,"CHAIR_01", "나무 2인용 의자", "12 * 20 inch", "갯수", "2021-02-01", "200", "0", "0","200", "2021-01-01");
            dataGridView2.Rows.Add(null, "1394-0001", "의자상사", "발주상태","CHAIR_02", "나무 1인용 의자", "5 * 12 inch", "갯수", "2021-02-01", "100", "0", "0","100" ,"2021-01-01");
        }

        private void FrmPurchaseList_Load(object sender, EventArgs e)
        {

        }
    }
}
