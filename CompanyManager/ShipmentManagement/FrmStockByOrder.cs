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
    public partial class FrmStockByOrder : CompanyManager.MDIBaseForm
    {
        public FrmStockByOrder()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridTextColumn(dataGridView2, "주문번호", "CompanyName", 130,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "납기일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "잔여수량", "CompanyName",60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "From창고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "재고", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "To창고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "비고", "CompanyName", 130, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "이동수량", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleRight);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null,"WO2021012501","CHAIR_01","나무 1인용 의자","5 X 12 X 24 inch","2020-02-01", "200","Halb 창고_01","200","제품창고","","");
        }
    }
}
