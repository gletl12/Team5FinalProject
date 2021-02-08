using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;
using Service;
namespace CompanyManager
{
    public partial class FrmRegPerformance : CompanyManager.MDIBaseForm
    {
        PerformanceService service = new PerformanceService();
        List<PerformanceVO> list = new List<PerformanceVO>();
        public FrmRegPerformance()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvPerformance);
            CommonUtil.SetDGVDesign_Num(dgvPerformance);
            CommonUtil.AddGridCheckColumn(dgvPerformance, "");
            CommonUtil.AddGridTextColumn(dgvPerformance, "지시일", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "설비ID", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "설비명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "품목", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "품명", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvPerformance, "상태", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "양품창고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "불량창고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "지시량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPerformance, "취소수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPerformance, "양품수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPerformance, "잔량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);

            checkBox1.Location = new Point(dgvPerformance.Location.X + 54, dgvPerformance.Location.Y + 5);

            dgvPerformance.Rows.Add(null, "2021-01-25","F_ASSY_01","최종조립반","CHAIR_01","나무 1인용 의자","작업지시","Halb 창고_01","","100","0","0","0","100");
            dgvPerformance.Rows.Add(null, "2021-01-26","MF01","SEAT 가공","SEAT_02","SEAT 가공품","작업지시","Halb 창고_01","","200","0","0","100","100");
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
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddMonths(1);
            //list = service.GetPerformanceList(dtpFrom.Value, dtpTo.Value);
            dgvPerformance.DataSource = list;   
        }
    }
}
