using CompanyManager.Properties;
using Service;
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
            DataLoad();
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
            CommonUtil.AddGridTextColumn(dgvShift, "설비코드", "shift_id");
            CommonUtil.AddGridTextColumn(dgvShift, "설비명", "machine_id");
            CommonUtil.AddGridTextColumn(dgvShift, "Shift", "shift_type", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "시작시간", "shift_stime", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "완료시간", "shift_etime", 150);
            CommonUtil.AddGridTextColumn(dgvShift, "적용일자", "shift_sdate");
            CommonUtil.AddGridTextColumn(dgvShift, "적용완료일자", "shift_edate", 120);
            CommonUtil.AddGridTextColumn(dgvShift, "사용유무", "shift_use", 170);
            CommonUtil.AddGridTextColumn(dgvShift, "비고", "shift_comment", 150, false);
            CommonUtil.AddGridTextColumn(dgvShift, "최초등록일", "ins_date", 150, false);
            CommonUtil.AddGridTextColumn(dgvShift, "최초등록자", "ins_emp",100, false);
            CommonUtil.AddGridTextColumn(dgvShift, "최종수정일", "up_date", 120, false);
            CommonUtil.AddGridTextColumn(dgvShift, "최종수정자", "up_emp", 170,false);


            Point heagerCellLocation = dgvShift.GetCellDisplayRectangle(1, -1, true).Location;          
            headerCheckBox.Location = new Point(heagerCellLocation.X + 27, heagerCellLocation.Y + 2);
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += HeaderCheckBox_Click;
            dgvShift.Controls.Add(headerCheckBox);


        }

        private void DataLoad()
        {
            ShiftService service = new ShiftService();
            dgvShift.DataSource= service.GetShift();
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
