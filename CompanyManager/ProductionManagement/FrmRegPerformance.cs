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
    public partial class FrmRegPerformance : CompanyManager.MDIBaseForm
    {
        public FrmRegPerformance()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridTextColumn(dataGridView2, "지시일", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "설비ID", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "설비명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "상태", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "양품창고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "불량창고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "지시량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "취소수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "양품수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "잔량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null, "2021-01-25","F_ASSY_01","최종조립반","CHAIR_01","나무 1인용 의자","작업지시","Halb 창고_01","","100","0","0","0","100");
            dataGridView2.Rows.Add(null, "2021-01-26","MF01","SEAT 가공","SEAT_02","SEAT 가공품","작업지시","Halb 창고_01","","200","0","0","100","100");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommonUtil.OpenCreateForm<PopupPerformance>();
        }

        private void FrmRegPerformance_Load(object sender, EventArgs e)
        {

        }
    }
}
