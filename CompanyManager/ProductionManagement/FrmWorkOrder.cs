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
    public partial class FrmWorkOrder : CompanyManager.MDIBaseForm
    {
        public FrmWorkOrder()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridTextColumn(dataGridView2, "투입시간", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter) ;
            CommonUtil.AddGridTextColumn(dataGridView2, "지시일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter) ;
            CommonUtil.AddGridTextColumn(dataGridView2, "설비코드", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "설비명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "상태", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 130);
            CommonUtil.AddGridTextColumn(dataGridView2, "지시량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "취소량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "양품량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "불량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "완료일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null, "2021-01-25", "2021-01-20", "MF01", "SEAT_가공", "작업완료", "SEAT_02", "의자 SEAT", "100", "0", "0", "0", "2021-01-25");
            dataGridView2.Rows.Add(null, "2021-01-25", "2021-01-22", "H_ASSY_01", "Leg_조립반", "작업지시", "LEG_02", "의자 SEAT", "50", "0", "0", "0");

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
