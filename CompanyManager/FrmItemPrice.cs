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
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridCheckColumn(dataGridView2,"");
            CommonUtil.AddGridImageColumn(dataGridView2, Properties.Resources.Edit_16x16, "Edit",20);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체", "CompanyName",80);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체명", "CompanyName",100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName",100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName",120);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName",100);
            CommonUtil.AddGridTextColumn(dataGridView2, "단위", "CompanyName",80);
            CommonUtil.AddGridTextColumn(dataGridView2, "Market", "CompanyName",80);
            CommonUtil.AddGridTextColumn(dataGridView2, "환종", "CompanyName",60);
            CommonUtil.AddGridTextColumn(dataGridView2, "현재단가", "CompanyName",80);
            CommonUtil.AddGridTextColumn(dataGridView2, "이전단가", "CompanyName",80);
            CommonUtil.AddGridTextColumn(dataGridView2, "시작일", "CompanyName",80);
            CommonUtil.AddGridTextColumn(dataGridView2, "종료일", "CompanyName",80);
            CommonUtil.AddGridTextColumn(dataGridView2, "비고", "CompanyName",120);
            CommonUtil.AddGridTextColumn(dataGridView2, "사용유무", "CompanyName",80);
        }
    }
}
