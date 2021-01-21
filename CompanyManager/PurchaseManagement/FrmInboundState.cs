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
    public partial class FrmInboundState : CompanyManager.MDIBaseForm
    {
        public FrmInboundState()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvInbound);
            CommonUtil.SetDGVDesign_Num(dgvInbound);
            CommonUtil.AddGridCheckColumn(dgvInbound, "");
            CommonUtil.AddGridTextColumn(dgvInbound, "발주번호", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvInbound, "업체", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "품목", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvInbound, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvInbound, "단위", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "검사여부", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "취소량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주유형", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주일자", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고일자", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);


            checkBox1.Location = new Point(dgvInbound.Location.X + 54, dgvInbound.Location.Y + 5);

            dgvInbound.Rows.Add(null, "202101251025", "다리상사", "L_WOOD_03", "의자 다리 원목", "12 * 20 inch", "갯수", "사용", "400", "0","400", "정규발주", "2021-01-25", "2021-01-26");
            dgvInbound.Rows.Add(null, "202101251025", "(주)시트", "SHEET_02", "의자 다리 원목", "12 * 20 inch", "갯수", "사용", "100", "0","100", "외주발주", "2021-01-25", "2021-01-26");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
