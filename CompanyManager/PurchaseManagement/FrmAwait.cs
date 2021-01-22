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
    public partial class FrmAwait : CompanyManager.MDIBaseForm
    {
        public FrmAwait()
        {
            InitializeComponent();


            CommonUtil.SetInitGridView(dgvWait);
            CommonUtil.SetDGVDesign_Num(dgvWait);
            CommonUtil.AddGridCheckColumn(dgvWait, "");
            CommonUtil.AddGridTextColumn(dgvWait, "발주일자", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "업체", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvWait, "품목", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvWait, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvWait, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvWait, "단위", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "검사여부", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "발주량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWait, "입고량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWait, "잔량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWait, "납기일자", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "발주유형", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "비고", "CompanyName", 120);


            checkBox1.Location = new Point(dgvWait.Location.X + 54, dgvWait.Location.Y + 5);

            dgvWait.Rows.Add(null, "2021-01-25", "다리상사", "L_WOOD_03", "의자 다리 원목", "12 * 20 inch", "갯수", "사용", "400", "0","300", "2021-01-01", "정규발주");
            dgvWait.Rows.Add(null, "2021-01-25", "(주)시트", "SHEET_02", "시트", "200 * 100", "갯수", "사용", "100", "0","100", "2021-01-01", "외주발주");



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
            CommonUtil.AddGridTextColumn(dgvInbound, "입고량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주유형", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주일자", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고일자", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);


            checkBox2.Location = new Point(dgvInbound.Location.X + 54, dgvInbound.Location.Y + 5);

            dgvInbound.Rows.Add(null, "202101251025", "다리상사", "L_WOOD_03", "의자 다리 원목", "12 * 20 inch", "갯수", "사용", "400", "400", "정규발주","2021-01-25", "2021-01-26");
            dgvInbound.Rows.Add(null, "202101251025", "(주)시트", "SHEET_02", "의자 다리 원목", "12 * 20 inch", "갯수", "사용", "100", "100", "외주발주", "2021-01-25", "2021-01-26");
        }
    }
}
