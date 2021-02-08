using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace POP
{
    public partial class FrmMain2 : POP.BaseForm
    {
        public FrmMain2()
        {
            InitializeComponent();
        }

        private void customTabControl1_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain2_Load(object sender, EventArgs e)
        {

            lblSelect1.Visible = false;
            lblSelect2.Visible = false;
            lblSelect3.Visible = false;
            button4.Visible = false;
            lblSelect4.Visible = false;


        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmPerformance frm = new FrmPerformance();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            lblSelect1.Visible = true;
            lblSelect2.Visible = false;
            lblSelect3.Visible = false;
            lblSelect4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FrmAllStatusBoard frm = new FrmAllStatusBoard();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            lblSelect1.Visible = false;
            lblSelect2.Visible = true;
            lblSelect3.Visible = false;
            lblSelect4.Visible = false;
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInspection frm = new FrmInspection();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            lblSelect1.Visible = false;
            lblSelect2.Visible = false;
            lblSelect3.Visible = false;
            lblSelect4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
