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
    public partial class FrmMoveProcess : CompanyManager.MDIBaseForm
    {
        public FrmMoveProcess()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 130);
            CommonUtil.AddGridTextColumn(dataGridView2, "창고코드", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "창고명", "CompanyName", 130, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목타입명", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "현재고", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "이전재고", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "단위", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "유무상구분", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "비고", "CompanyName", 150);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null, "BACK_A_02","등받이","OS","사급창고","반제품","200","100","갯수","5 X 6 inch", "무상");
            dataGridView2.Rows.Add(null, "B_WOOD_K_03","등받이 원판","OS","사급창고","원자재","100","100","갯수","6 X 12 inch", "무상");

            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            CommonUtil.AddGridCheckColumn(dataGridView1, "");
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "CompanyName", 150);
            CommonUtil.AddGridTextColumn(dataGridView1, "품명", "CompanyName", 150);
            CommonUtil.AddGridTextColumn(dataGridView1, "규격", "CompanyName", 130);
            CommonUtil.AddGridTextColumn(dataGridView1, "현재고", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView1, "이동창고", "CompanyName", 150, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "이동일자", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "이동수량", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "비고", "CompanyName", 200);
            checkBox2.Location = new Point(dataGridView1.Location.X + 54, dataGridView1.Location.Y + 5);

            dataGridView1.Rows.Add(null, "BACK_A_02","등받이", "5 * 12 inch","200","H_01(Halb 창고_01)","2020-01-25","200","");
        }
    }
}
