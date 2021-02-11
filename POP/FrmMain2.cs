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

            
            CommonUtil.OpenCreateForm_POP(this, Type.GetType($"{appName}.{"FrmAllStatusBoard"}"));
            CommonUtil.OpenCreateForm_POP(this, Type.GetType($"{appName}.{"FrmInspection"}"));
            CommonUtil.OpenCreateForm_POP(this, Type.GetType($"{appName}.{"FrmPerformance"}"));

            //customTabControl1.InsertTab("설비관리", "FrmAllStatusBoard");
        }

      

        private void button3_Click(object sender, EventArgs e)
        {

           
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

     

        
    }
}
