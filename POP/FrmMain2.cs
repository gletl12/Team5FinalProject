using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Util;

namespace POP
{
    public partial class FrmMain2 : POP.BaseForm
    {
        public FrmMain2(string name)
        {
            InitializeComponent();
            Name = name;
        }
        public string Name { get; set; }
        private void customTabControl1_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain2_Load(object sender, EventArgs e)
        {
            //기본폼 3개 생성
            string appName = Assembly.GetEntryAssembly().GetName().Name;

            CommonUtil.OpenCreateForm_POP(this, Type.GetType($"{appName}.{"FrmPerformance"}"));
            CommonUtil.OpenCreateForm_POP(this, Type.GetType($"{appName}.{"FrmAllStatusBoard"}"));
            CommonUtil.OpenCreateForm_POP(this, Type.GetType($"{appName}.{"FrmInspection"}"));


            //customTabControl1.InsertTab("설비관리", "FrmAllStatusBoard");





            //FrmPerformance frm = new FrmPerformance();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //frm.Show();

            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;



        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //FrmPerformance frm = new FrmPerformance();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //frm.Show();
            //CommonUtil.OpenCreateFormPOP<FrmPerformance>(true, this);
            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //FrmAllStatusBoard frm = new FrmAllStatusBoard();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //frm.Show();
            //CommonUtil.OpenCreateFormPOP<FrmAllStatusBoard>(true, this);
            lbl1.Visible = false;
            lbl2.Visible = true;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FrmInspection frm = new FrmInspection();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //frm.Show();
            //CommonUtil.OpenCreateFormPOP<FrmInspection>(true, this);
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = true;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //CommonUtil.OpenCreateFormPOP<FrmAction>(true,this);
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = true;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //CommonUtil.OpenCreateFormPOP<FrmAction>(true);
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = true;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = true;
            lbl7.Visible = false;
            lbl8.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = true;
            lbl8.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = true;
        }
    }
}
