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
using System.Globalization;

namespace POP
{
    public partial class FrmPerformance : POP.BaseForm
    {
        
        #region Initialize fields
        private int CurrentPage = 1;
        int PagesCount = 1;
        int PageRows = 20;

        
        

        List<WorkOrderVO> list;
        List<WorkOrderVO> Templist;
        #endregion
        public string Task_ID { get { return lblTaskID.Text; } set { lblTaskID.Text = value; } }
        public string Task_IP { get { return lblIP.Text; } set { lblIP.Text = value; } }
        public string Task_Port { get { return lblPort.Text; } set { lblPort.Text = value; } }
        public string Task_Remark { get { return lblRemark.Text; } set { lblRemark.Text = value; } }

        
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
            PagesCount = Convert.ToInt32(Math.Ceiling(list.Count * 1.0 / PageRows));

            CurrentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();
        }

        private void Control()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                UserControl1 ctrl = new UserControl1();

                ctrl.Name = $"taskControl{i}";
                ctrl.Location = new Point(0,0); 
                ctrl.Size = new Size(300, 200);

                ctrl.Task_ID = tasks[i].taskID;
                ctrl.Task_IP = tasks[i].hostIP;
                ctrl.Task_Port = tasks[i].hostPort;
                ctrl.Task_Remark = tasks[i].remark;

                ctrl.IsTaskEnable = false;

                panel1.Controls.Add(ctrl);
            }
        }

        List<taskItem> tasks = (List<taskItem>)ConfigurationManager.GetSection("taskList");
        //UserControl1 ctrl;
       
        private void ComboBoxBinding()
        {
            MachineService service = new MachineService();
            List<MachineVO> machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "전체" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");
        }
        //List<WorkOrderVO> list;
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
         }
        /// <summary>
        /// 검색
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 오늘날짜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

     
       

       

        private void FrmPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton ToolStripButton = ((ToolStripButton)sender);

                //Determining the current page
                if (ToolStripButton == btnBackward)
                    CurrentPage--;
                else if (ToolStripButton == btnForward)
                    CurrentPage++;
                else if (ToolStripButton == btnLast)
                    CurrentPage = PagesCount;
                else if (ToolStripButton == btnFirst)
                    CurrentPage = 1;
                else
                    CurrentPage = Convert.ToInt32(ToolStripButton.Text, CultureInfo.InvariantCulture);

                if (CurrentPage < 1)
                    CurrentPage = 1;
                else if (CurrentPage > PagesCount)
                    CurrentPage = PagesCount;

                //Rebind the Datagridview with the data.
                RebindGridForPageChange();

                //Change the pagiantions buttons according to page number
                RefreshPagination();
            }
            catch (Exception) { }
        }
        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            //pageStartIndex contains the first button number of pagination.
            int pageStartIndex = 1;

            if (PagesCount > 5 && CurrentPage > 2)
                pageStartIndex = CurrentPage - 2;

            if (PagesCount > 5 && CurrentPage > PagesCount - 2)
                pageStartIndex = PagesCount - 4;

            for (int i = pageStartIndex; i < pageStartIndex + 5; i++)
            {
                if (i > PagesCount)
                {
                    items[i - pageStartIndex].Visible = false;
                }
                else
                {
                    //Changing the page numbers
                    items[i - pageStartIndex].Text = i.ToString(CultureInfo.InvariantCulture);

                    //Setting the Appearance of the page number buttons
                    if (i == CurrentPage)
                    {
                        items[i - pageStartIndex].BackColor = Color.Black;
                        items[i - pageStartIndex].ForeColor = Color.White;
                    }
                    else
                    {
                        items[i - pageStartIndex].BackColor = Color.White;
                        items[i - pageStartIndex].ForeColor = Color.Black;
                    }
                }
            }

            //Enabling or Disalbing pagination first, last, previous , next buttons
            if (CurrentPage == 1)
                btnBackward.Enabled = btnFirst.Enabled = false;
            else
                btnBackward.Enabled = btnFirst.Enabled = true;

            if (CurrentPage == PagesCount)
                btnForward.Enabled = btnLast.Enabled = false;

            else
                btnForward.Enabled = btnLast.Enabled = true;
        }
        private void RebindGridForPageChange()
        {
            //Rebinding the Datagridview with data
            int datasourcestartIndex = (CurrentPage - 1) * PageRows;
            Templist = new List<WorkOrderVO>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + PageRows; i++)
            {
                if (i >= list.Count)
                    break;

                Templist.Add(list[i]);
            }

            dataGridView1.DataSource = Templist;
            dataGridView1.Refresh();
        }
    }
}
