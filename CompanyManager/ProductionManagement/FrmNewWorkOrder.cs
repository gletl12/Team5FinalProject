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
    public partial class FrmNewWorkOrder : CompanyManager.MDIBaseForm
    {
        public FrmNewWorkOrder()
        {
            InitializeComponent();



            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridImageColumn(dataGridView2, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 130);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "상태", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "설비코드", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "설비명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "계획수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "지시수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "계획시작일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "등록사유", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "소요시간", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "계획완료일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "작업지시번호", "CompanyName", 120, true, DataGridViewContentAlignment.MiddleCenter);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null, null, "CHAIR_03", "1인용 나무 의자", "12 x 6 inch", "작업생성", "F_ASSY_01", "최종조립반", "100", "100", "2020-01-01", "","300", "2020-01-01", "");
            dataGridView2.Rows.Add(null, null, "BACK_02", "등받이", "5 x 12inch", "작업생성", "OS", "외주작업장", "100", "100", "2020-01-01", "","100", "2020-01-01", "");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
