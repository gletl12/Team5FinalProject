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
    public partial class FrmItemPrice : CompanyManager.MDIBaseForm
    {
        public FrmItemPrice()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dgvPrice);
            CommonUtil.SetDGVDesign_Num(dgvPrice);
            CommonUtil.SetDGVDesign_CheckBox(dgvPrice);
            CommonUtil.AddGridImageColumn(dgvPrice, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvPrice, "업체", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "업체명", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvPrice, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "단위", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "Market", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "환종", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dgvPrice, "현재단가", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "이전단가", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "시작일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "종료일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "비고", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvPrice, "사용유무", "CompanyName", 80);

            CommonUtil.AddGridTextColumn(dgvPrice, "업체", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "업체명", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvPrice, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "단위", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "Market", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "환종", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dgvPrice, "현재단가", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "이전단가", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "시작일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "종료일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "비고", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvPrice, "사용유무", "CompanyName", 80);

            //checkBox1.Location = new Point(dgvPrice.Location.X + 54, dgvPrice.Location.Y + 5);
            //dgvPrice.Scroll += DgvPrice_Scroll;
            dgvPrice.Rows.Add(null, null, "GD", "구디", "L_WOOD_04", "의자 다리 원목", "500 * 200", "갯수", "내수", "KRW", "700.00", "650.00", "2021-01-01", "9999-01-01");
            dgvPrice.Rows.Add(null, null, "OS", "(주)에이더블유", "BACK_A_02", "등받이", "5 * 12 inch", "갯수", "내수", "KRW", "200.00", "0", "2021-01-01", "9999-01-01");

        }


        //private void DgvPrice_Scroll(object sender, ScrollEventArgs e)
        //{
        //    if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
        //    {
        //        checkBox1.Location = new Point(checkBox1.Location.X - (e.NewValue - e.OldValue), checkBox1.Location.Y);
        //        checkBox1.Visible = checkBox1.Location.X > dgvPrice.Location.X + 50;
        //    }
        //}
    }
}
