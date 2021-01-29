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
    public partial class FrmShiftMent : CompanyManager.MDIBaseForm
    {
        public FrmShiftMent()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
       

        private void FrmShiftMent_Load(object sender, EventArgs e)
        {
            CommonUtil.SetDGVDesign(dataGridView2);
            dataGridView2.AutoGenerateColumns = true;
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;

            ShiftService service = new ShiftService();
            dataGridView2.DataSource= service.GetShiftInfo(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[1].HeaderText = "Shift";
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
