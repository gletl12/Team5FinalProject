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
    public partial class FrmSO : CompanyManager.MDIBaseForm
    {
        public FrmSO()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridImageColumn(dataGridView2, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dataGridView2, "WORK_ORDER_ID", "CompanyName", 150, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "업체명", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "도착지코드", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "도착지명", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "발주구분", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView2, "주문수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "출고수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "취소수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dataGridView2, "납기일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);


            dataGridView2.Rows.Add(null, "CU1234L-1234A-12350", "CU", "의자상사", "CU", "의자상사", "P/O", "CHAIR_01", "1인용 원목 의자", "100","0","0" ,"2020-05-21");
            dataGridView2.Rows.Add(null, "CU1234L-1234A-12351", "CU", "의자상사", "CU", "의자상사", "P/O", "CHAIR_01", "1인용 원목 의자", "100","0","0", "2020-05-26");
            
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "V")
            {
                this.Size = new Size(this.Size.Width, this.Size.Height * 3 / 2);



                btnDown.Text = "ᐱ";
            }
            else
            {
                btnDown.Text = "V";

            }
        }

        private void dtpRegDate_ValueChanged(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
        }
    }
}
