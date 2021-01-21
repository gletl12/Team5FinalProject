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
    public partial class FrmCheck : CompanyManager.MDIBaseForm
    {
        public FrmCheck()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridTextColumn(dataGridView2, "검사번호", "CompanyName", 100,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "검사일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체명", "CompanyName",120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "결과", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "입고수량", "CompanyName", 70, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "불량수량", "CompanyName", 70, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "불량사유", "CompanyName", 150);


            dataGridView2.Rows.Add("1001", "2021-01-25", "(주)에이더블유", "L_WOOD_03", "의자 다리 원목", "12 * 20 inch", "합격", "200", "0");
            dataGridView2.Rows.Add("1002", "2021-01-25", "(주)시트", "WOOD_01", "시트", "200 * 200", "합격", "100", "0");
        }


    }
}
