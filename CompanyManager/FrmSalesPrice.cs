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
    public partial class FrmSalesPrice : CompanyManager.MDIBaseForm
    {
        public FrmSalesPrice()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridImageColumn(dataGridView2, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체명", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "단위", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "Market", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "환종", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dataGridView2, "현재단가", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "이전단가", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "시작일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "종료일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "비고", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "사용유무", "CompanyName", 80);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null, null, "OS", "(주)에이더블유", "CHAIR_01", "나무 2인용 의자", "12 * 20 inch", "갯수", "내수", "KRW", "400.00", "300", "2021-01-01", "9999-01-01");
            dataGridView2.Rows.Add(null, null, "CU", "의자상사", "CHAIR_02", "나무 1인용 의자", "5 * 12 inch", "갯수", "내수", "KRW", "200.00", "0", "2021-01-01", "9999-01-01");

        }

        private void btnNewPrice_Click(object sender, EventArgs e)
        {
            CommonUtil.OpenCreateForm<PopupItemPrice>();
        }
    }
}
