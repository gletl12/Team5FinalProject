using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace POP
{
    public partial class FrmPerformance : POP.BaseForm
    {
        public FrmPerformance()
        {
            InitializeComponent();
        }

        private void FrmInspection_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersHeight = 50;
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_id", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목 코드", "item_id", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "계획수량", "wo_qty", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시상태", "wo_state", 350);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "prod_id", 130,false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_people", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_start", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_end", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_emp", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_emp", 130, false);


            MachineService service = new MachineService();
            List<MachineVO> machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "전체" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");

            WorkOrderService service1 = new WorkOrderService();
            dataGridView1.DataSource= service1.GetWorkOrder();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("검색기간의 설정이 잘못되었습니다.");
                return;
            }
        }
    }
}
