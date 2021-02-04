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
            
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            dataGridView1.ColumnHeadersHeight = 50;
            
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_id", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목 코드", "item_id", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "계획수량", "wo_qty", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시상태", "wo_state", 350);

            CommonUtil.AddGridTextColumn(dataGridView1, "계획번호", "prod_id", 130,false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_people", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "시작시간", "wo_start", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "종료시간", "wo_end", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_emp", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_emp", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "machine_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "machine_name", 130, false);


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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;

            textBox1.Text = dataGridView1[0,rowIndex].Value.ToString();
            textBox2.Text = dataGridView1[4,rowIndex].Value.ToString();//4
            textBox3.Text = dataGridView1[6,rowIndex].Value.ToString();//6
            textBox4.Text = dataGridView1[1,rowIndex].Value.ToString();//1
            textBox5.Text = dataGridView1[13,rowIndex].Value.ToString();//13
            textBox6.Text = dataGridView1[7,rowIndex].Value.ToString();//7
        }
    }
}
