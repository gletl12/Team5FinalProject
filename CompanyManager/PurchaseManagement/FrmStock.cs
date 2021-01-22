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
    public partial class FrmStock : CompanyManager.MDIBaseForm
    {
        public FrmStock()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2, "");
            CommonUtil.AddGridTextColumn(dataGridView2, "창고코드", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "창고", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 130);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 150);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목타입", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "재고량", "CompanyName", 80,true,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "단위", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "관리등급", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "비고", "CompanyName", 120);

            checkBox1.Location = new Point(dataGridView2.Location.X + 54, dataGridView2.Location.Y + 5);

            dataGridView2.Rows.Add(null,"R_01","자재창고_01","B_WOOD_K_03","등받이 원판","원자재","6 x 12inch","300","EA");
            dataGridView2.Rows.Add(null,"R_01","자재창고_01","CROSS_BAR_03","의자 다리 CROSS BAR","원자재","12inch","100","EA");
            dataGridView2.Rows.Add(null,"R_01","자재창고_01","L_WOOD_04","의자 다리 원목","원자재","500 * 200","800","EA");
            dataGridView2.Rows.Add(null,"R_01","자재창고_01","S_WOOD_03","SEAT 원판","원자재","12 x 12inch","200","EA");
        }
    }
}
