using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Deployment.Application;

namespace POP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<taskItem> tasks = (List<taskItem>)ConfigurationManager.GetSection("taskList");

            for(int i=0; i<tasks.Count; i++)
            {
                TaskControl ctrl = new TaskControl();

                ctrl.Name = $"taskControl{i}";
                ctrl.Location = new Point(23, 2+(i*60)); //(23,2) (23, 35)
                ctrl.Size = new Size(737, 60);

                ctrl.Task_ID = tasks[i].taskID;
                ctrl.Task_IP = tasks[i].hostIP;
                ctrl.Task_Port = tasks[i].hostPort;
                ctrl.Task_Remark = tasks[i].remark;

                ctrl.IsTaskEnable = false;

                panel1.Controls.Add(ctrl);
            }
        }

        private void chkEnable_Click(object sender, EventArgs e)
        {
            foreach (var ctrl in panel1.Controls)
            {
                if (ctrl is TaskControl item)
                {
                    item.chkEnable.Checked = chkEnable.Checked;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("체크된 Task를 모두 시작하시겠습니까?", "시작확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var ctrl in panel1.Controls)
                {
                    if (ctrl is TaskControl item)
                    {
                        if (item.chkEnable.Checked && (!item.IsTaskEnable))
                        {
                            item.btnStart.PerformClick();
                        }
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("체크된 Task를 모두 중지하시겠습니까?", "중지확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var ctrl in panel1.Controls)
                {
                    if (ctrl is TaskControl item)
                    {
                        if (item.chkEnable.Checked && (item.IsTaskEnable))
                        {
                            item.btnStop.PerformClick();
                        }
                    }
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
