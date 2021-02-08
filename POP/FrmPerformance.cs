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
using System.Linq;
using System.Diagnostics;
using System.Configuration;

namespace POP
{
    public partial class FrmPerformance : POP.BaseForm
    {
        FrmAction frm;

        public string Task_ID { get { return lblTaskID.Text; } set { lblTaskID.Text = value; } }
        public string Task_IP { get { return lblIP.Text; } set { lblIP.Text = value; } }
        public string Task_Port { get { return lblPort.Text; } set { lblPort.Text = value; } }
        public string Task_Remark { get { return lblRemark.Text; } set { lblRemark.Text = value; } }

        int process_id = 0;
        public FrmPerformance()
        {
            InitializeComponent();
        }

        
        private void FrmInspection_Load(object sender, EventArgs e)
        {
            
            GetdgvColumn();
            DataLoad();
            ComboBoxBinding();
            Control();
         

        }
        List<taskItem> tasks = (List<taskItem>)ConfigurationManager.GetSection("taskList");
        UserControl1 ctrl;
        private void Control()
        {
            

            for (int i = 0; i < tasks.Count; i++)
            {
                ctrl = new UserControl1();

                ctrl.Name = $"taskControl{i}";
                ctrl.Location = new Point(0,0); //(23,2) (23, 35)
                ctrl.Size = new Size(112, 292);

                ctrl.Task_ID = tasks[i].taskID;
                ctrl.Task_IP = tasks[i].hostIP;
                ctrl.Task_Port = tasks[i].hostPort;
                ctrl.Task_Remark = tasks[i].remark;

                ctrl.IsTaskEnable = false;
                ctrl.Visible = false;
                panel1.Controls.Add(ctrl);
            }
        }

        private void ComboBoxBinding()
        {
            MachineService service = new MachineService();
            List<MachineVO> machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "전체" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");
        }
        List<WorkOrderVO> list;
        private void DataLoad()
        {
            WorkOrderService service1 = new WorkOrderService();
            list = service1.GetWorkOrder();
            dataGridView1.DataSource = list;
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            dataGridView1.ColumnHeadersHeight = 50;

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_id", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목 코드", "item_id", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "계획수량", "wo_qty", 350);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시상태", "wo_state", 350);

            CommonUtil.AddGridTextColumn(dataGridView1, "계획번호", "prod_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_people", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "시작시간", "wo_start", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "종료시간", "wo_end", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_emp", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_emp", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "machine_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "machine_name", 130, false);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("검색기간의 설정이 잘못되었습니다.");
                return;
            }
        }
        //int i = 0;
         
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = dataGridView1.CurrentRow.Index;

            textBox1.Text = dataGridView1[0, rowIndex].Value.ToString();
            textBox2.Text = dataGridView1[4, rowIndex].Value.ToString();//4
            textBox3.Text = dataGridView1[6, rowIndex].Value.ToString();//6
            textBox4.Text = dataGridView1[1, rowIndex].Value.ToString();//1
            textBox5.Text = dataGridView1[13, rowIndex].Value.ToString();//13
            textBox6.Text = dataGridView1[7, rowIndex].Value.ToString();//7
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].taskID == dataGridView1[12, rowIndex].Value.ToString())
                {
                    lblTaskID.Text = tasks[i].taskID;
                    lblIP.Text = tasks[i].hostIP;
                    lblPort.Text = tasks[i].hostPort;
                    lblRemark.Text = tasks[i].remark;

                    foreach (var ctrl in panel1.Controls)
                    {
                        if (ctrl is  UserControl1 taskCtrl)
                        {
                            taskCtrl.Visible = false;

                            if (taskCtrl.Task_ID.Equals(tasks[i].taskID))
                            {
                                taskCtrl.Visible = true;
                            }
                        }
                    }
                }

            }
           


            //    UserControl1 ctrl = new UserControl1();

            //    ctrl.Name = $"taskControl{i}";
            //    ctrl.Location = new Point(0, 0); //(23,2) (23, 35)
            //    ctrl.Size = new Size(112, 292);

            //    ctrl.Task_ID = lblTaskID.Text;
            //    ctrl.Task_IP = lblIP.Text;
            //    ctrl.Task_Port = lblPort.Text;
            //    ctrl.Task_Remark = lblRemark.Text;

            //    ctrl.IsTaskEnable = false;

            //    panel1.Controls.Add(ctrl);
            //    i++;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboMachine.Text == "전체")
            {
                var list1 = (from all in list
                             where all.wo_sdate>=dateTimePicker1.Value.AddDays(-1)&&all.wo_sdate<=dateTimePicker2.Value select all).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list1;
            }
            else
            {
                var list1 = (from all in list
                             where all.wo_sdate >= dateTimePicker1.Value.AddDays(-1) && all.wo_sdate <=dateTimePicker2.Value && all.machine_name==cboMachine.Text
                             select all).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 로그보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            frmLogViewer log = new frmLogViewer();
            log.OpenFileName = $"Logs\\{Task_ID}.log";
            log.ShowDialog();
        }
        /// <summary>
        /// 공정가동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click_1(object sender, EventArgs e)
        {
            string server = @"C:\Users\HB\Desktop\파이널팀프\Machine\bin\Debug\Machine.exe";
            Process pro = Process.Start(server, $"{Task_ID} {Task_IP} {Task_Port}");
            process_id = pro.Id;

            frm = new FrmAction(Task_ID, Task_IP, Task_Port);
            frm.Show();
            frm.Hide();

           // IsTaskEnable = true;
        }
        /// <summary>
        /// 화면보이기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            frm.Show();
        }
        /// <summary>
        /// 설비중지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            frm.bExit = true;
            frm.Close();
            //IsTaskEnable = false;

            foreach (Process process in Process.GetProcesses())
            {
                if (process.Id.Equals(process_id))
                {
                    process.Kill();
                }
            }
        }
    }
}
