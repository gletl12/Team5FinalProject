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
    public partial class FrmItemHistory : CompanyManager.MDIBaseForm
    {
        public FrmItemHistory()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridTextColumn(dataGridView2, "입출고일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "구분", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "카테고리", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "FROM창고", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "창고", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목형태", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "관리등급", "CompanyName", 60,true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "수불량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "단가", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "금액", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "환종", "CompanyName", 60,true,DataGridViewContentAlignment  .MiddleCenter);


            dataGridView2.Rows.Add("2020-01-25", "출고",  "자재차감","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "입고",  "실적등록","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "출고",  "자재차감","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "입고",  "실적등록","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "출고",  "자재차감","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "입고",  "실적등록","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "출고",  "자재차감","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "입고",  "실적등록","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "출고",  "자재차감","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "입고",  "실적등록","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "출고",  "자재차감","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "입고",  "실적등록","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");
            dataGridView2.Rows.Add("2020-01-25", "출고",  "자재차감","", "Halb 창고_01", "SEAT_01", "의자 SEAT", "12 * 20 inch", "반제품", "", "100", "0", "0", "-");

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }
    }
}
