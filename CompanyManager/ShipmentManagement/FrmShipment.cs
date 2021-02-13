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
    public partial class FrmShipment : CompanyManager.MDIBaseForm
    {
        public FrmShipment()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvShipment);
            CommonUtil.SetDGVDesign_Num(dgvShipment);
            CommonUtil.AddGridTextColumn(dgvShipment, "고객주문번호", "CompanyName", 100,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "납기일", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "PO ID", "CompanyName", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "고객사코드", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "고객사", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "도착지코드", "CompanyName", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "도착지", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dgvShipment, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "주문수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvShipment, "출하수량", "CompanyName", 60, true, DataGridViewContentAlignment.MiddleRight);

            checkBox1.Location = new Point(dgvShipment.Location.X + 54, dgvShipment.Location.Y + 5);

            dgvShipment.Rows.Add(null, "WO2021012501", "2021-02-01", "", "CU", "의자상사", "CU", "의자상사", "CHAIR_01", "나무 1인용 의자", "100", "0");
            dgvShipment.Rows.Add(null, "WO2021012502", "2021-02-01", "", "CU", "의자상사", "CU", "의자상사", "CHAIR_01", "나무 1인용 의자", "200", "0");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
