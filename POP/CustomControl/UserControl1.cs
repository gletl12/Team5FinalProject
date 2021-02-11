using Machine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace POP
{
    public partial class UserControl1 : UserControl
    {
        FrmAction frm;

        public FrmPerformance ControlMDI { get; set; }
        public FrmAction Frm { get; set; }
        public string Task_ID { get { return lblTaskID.Text; } set { lblTaskID.Text = value; } }
        public string Task_IP { get { return lblIP.Text; } set { lblIP.Text = value; } }
        public string Task_Port { get { return lblPort.Text; } set { lblPort.Text = value; } }
        public string Task_Remark { get { return lblRemark.Text; } set { lblRemark.Text = value; } }

        public string Order_Num { get { return lblOrderNum.Text; } set { lblOrderNum.Text = value; } }

        int process_id = 0;

        public bool IsTaskEnable
        {
            get
            {
                return btnStop.Enabled;
            }
            set
            {
                if (value)
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    btnShow.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    btnShow.Enabled = false;
                }
            }
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //string server = @"C:\Users\HB\Desktop\파이널팀프\Machine\bin\Debug\Machine.exe";
            string server = ConfigurationManager.AppSettings["MachineEXE"];
            
            Process pro = Process.Start(server, $"{Task_ID} {Task_IP} {Task_Port} {Order_Num}");
            process_id = pro.Id;
            //Machine.Service1 ser = new Service1();
            //ser.Total(200);

            frm = new FrmAction(Task_ID, Task_IP, Task_Port, "test01", "test02", "test03", "test04", int.Parse(Order_Num));
            frm.Show();
            frm.Hide();

            IsTaskEnable = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //CommonUtil.OpenCreateFormPOP<FrmAction>(true, ControlMDI.ParentForm);
            //FrmAction frm = new FrmAction();
            frm.MdiParent = ControlMDI.ParentForm;
      
            frm.Dock = DockStyle.Fill;
            frm.Show();




        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            frm.bExit = true;
            frm.Close();
            IsTaskEnable = false;

            foreach (Process process in Process.GetProcesses())
            {
                if (process.Id.Equals(process_id))
                {
                    process.Kill();
                }
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmLogViewer log = new frmLogViewer();
            log.OpenFileName = $"Logs\\{Task_ID}.log";
            log.ShowDialog();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
