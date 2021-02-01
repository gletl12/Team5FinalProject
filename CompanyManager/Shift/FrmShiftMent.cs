using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

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

            DataLoad();
            ComboBoxBinding();
        }

        private void DataLoad()
        {
            CommonUtil.SetDGVDesign(dataGridView2);
            dataGridView2.AutoGenerateColumns = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;

            ShiftService service = new ShiftService();
            dataGridView2.DataSource= service.GetShiftInfo(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[1].HeaderText = "Shift";
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        
        List<CodeVO> code;
        List<MachineVO> machine;

        private void ComboBoxBinding()
        {
            MachineService service = new MachineService();
            machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "전체" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");

            //var shift1 = shift.ConvertAll(o => o);
            //shift1.Insert(0, new ShiftVO { shift_type = "전체" });
            //CommonUtil.BindingComboBoxPart(cboShift, shift1, "shift_type");


            CodeService service1 = new CodeService();
            code = service1.GetAllCommonCode();
            var code1 = (from All in code where All.category == "shift_type" select All).ToList();
            code1.Insert(0, new CodeVO { name = "전체" });
            CommonUtil.BindingComboBox(cboShift, code1, "code", "name");


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
