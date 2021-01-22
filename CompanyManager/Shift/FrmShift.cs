using CompanyManager.Properties;
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
    public partial class FrmShift : CompanyManager.MDIBaseForm
    {
        CheckBox headerCheckBox = new CheckBox();
        public FrmShift()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PopupShift popup = new PopupShift();
            popup.Show();
        }

        private void FrmShift_Load(object sender, EventArgs e)
        {

            GetdgvColumn();
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign_Num(dgvShift);

            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = "chk";
            col.HeaderText = "";
            col.Width = 30;
            dgvShift.Columns.Add(col);
            CommonUtil.AddGridImageColumn(dgvShift, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvShift, "설비코드", "factory_grade");
            CommonUtil.AddGridTextColumn(dgvShift, "설비명", "factory_type");
            CommonUtil.AddGridTextColumn(dgvShift, "Shift", "factory_name", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "시작시간", "factory_parent", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "완료시간", "factory_comment", 150);
            CommonUtil.AddGridTextColumn(dgvShift, "적용일자", "factory_use");
            CommonUtil.AddGridTextColumn(dgvShift, "적용완료일자", "up_emp", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "사용유무", "up_date", 170);
                        Point heagerCellLocation = dgvShift.GetCellDisplayRectangle(1, -1, true).Location;          
            headerCheckBox.Location = new Point(heagerCellLocation.X + 27, heagerCellLocation.Y + 2);
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += HeaderCheckBox_Click;
            dgvShift.Controls.Add(headerCheckBox);

            dgvShift.Rows.Add(null, null, "회사", "공장", "(주)Sidiz", "", "", "사용", "관리자", "2021-01-22");
            dgvShift.Rows.Add(null, null, "회사", "공장", "(주)Sidiz", "", "", "사용", "관리자", "2021-01-22");

            DataLoad();


        }

        private void DataLoad()
        {
            
        }

        /// <summary>
        /// 체크박스
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderCheckBox_Click(object sender, EventArgs e)
        {
            //현재 cell의 편집모드를 종료 =>commit같은 거
            dgvShift.EndEdit();

            foreach (DataGridViewRow row in dgvShift.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                chk.Value = headerCheckBox.Checked;

            }
        }
    }
}
