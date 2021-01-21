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
    public partial class FrmSOUpload : CompanyManager.MDIBaseForm
    {
        public FrmSOUpload()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridTextColumn(dataGridView2, "planDate", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "WORK_ORDER_ID", "CompanyName", 150, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체명", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "MKT", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "발주구분", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "구분", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "입고P/NO", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "수량", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "납기일", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleCenter);


            dataGridView2.Rows.Add("2020-01-01","CU1234L-1234A-12350","CU","의자상사","2","양산","P/O","CHAIR_01", "CHAIR_01","1인용 원목 의자","100","2020-05-21");
            dataGridView2.Rows.Add("2020-01-01","CU1234L-1234A-12351","CU","의자상사","2", "양산","P/O","CHAIR_01", "CHAIR_01","1인용 원목 의자","100","2020-05-26");
        }
    }
}
