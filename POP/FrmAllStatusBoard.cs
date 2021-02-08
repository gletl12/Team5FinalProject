using POP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POP
{
    public partial class FrmAllStatusBoard : POP.BaseForm
    {
        public FrmAllStatusBoard()
        {
            InitializeComponent();
        }

        private void machineControl3_Load(object sender, EventArgs e)
        {

        }

        private void FrmAllStatusBoard_Load(object sender, EventArgs e)
        {
            string[] list = { "최종조립반", "Leg_조립반", "SEAT_가공", "LEGS_홀 가공", "외주 작업장"};
            int idx = 1;
            for (int i = 0; i < list.Length; i++)
            {
                if (idx > list.Length)
                    break;
                MachineControl control = new MachineControl();
                control.Name = $"btn{idx}";
                control.Tag = i;
                if(10 + (i * 310)<1000)
                control.Location = new Point(30 + (i * 330), 30 ); //생성위치
                else
                    control.Location = new Point(30 , 440); //생성위치
                control.Size = new Size(310, 383); //버튼 사이즈 
                control.MachinName = list[i];
                control.image = Resources.Leg_조립반;





                panel1.Controls.Add(control);
                idx++;
            }
            //machineControl1.MachinName = "최종조립반";
            //machineControl2.MachinName = "Leg_조립반";
            //machineControl3.MachinName = "SEAT_가공";
            //machineControl4.MachinName = "LEGS_홀 가공";
            //machineControl6.MachinName = "외주 작업장";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
