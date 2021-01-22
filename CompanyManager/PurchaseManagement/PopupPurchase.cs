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
    public partial class PopupPurchase : CompanyManager.PopupBaseForm
    {
        public PopupPurchase()
        {
            InitializeComponent();


            CommonUtil.SetInitGridView(dgvCompany);
            CommonUtil.SetDGVDesign_Num(dgvCompany);
            CommonUtil.AddGridCheckColumn(dgvCompany, "");
            CommonUtil.AddGridTextColumn(dgvCompany, "업체", "CompanyName", 200,true,DataGridViewContentAlignment.MiddleCenter);

            checkBox1.Location = new Point(dgvCompany.Location.X + 54, dgvCompany.Location.Y + 5);

            dgvCompany.Rows.Add(null,"(주)시트");
            dgvCompany.Rows.Add(null,"다리상사");
            dgvCompany.Rows.Add(null,"대한등받이");
            dgvCompany.Rows.Add(null,"크로스바백화점");

            CommonUtil.SetInitGridView(dgvItem);
            CommonUtil.SetDGVDesign_Num(dgvItem);
            CommonUtil.AddGridCheckColumn(dgvItem, "");
            CommonUtil.AddGridTextColumn(dgvItem, "업체", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvItem, "담당자", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvItem, "품목", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvItem, "품명", "CompanyName", 150, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvItem, "창고", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvItem, "납기일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);

            checkBox2.Location = new Point(dgvItem.Location.X + 54, dgvItem.Location.Y + 5);
            dgvItem.Rows.Add(null, "(주)시트", "", "S_WOOD_03", "SEAT 원판", "자재창고_01", "2021-02-01");
            dgvItem.Rows.Add(null, "다리상사", "", "L_WOOD_04", "의자 다리 원목", "자재창고_01", "2021-02-01");
            dgvItem.Rows.Add(null, "다리상사", "", "L_WOOD_04", "의자 다리 원목", "자재창고_01", "2021-02-03");
            dgvItem.Rows.Add(null, "대한등받이", "", "B_WOOD_K_03", "등받이 원판", "자재창고_01", "2021-02-01");
            dgvItem.Rows.Add(null, "대한등받이", "", "B_WOOD_K_03", "등받이 원판", "자재창고_01", "2021-02-01");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
