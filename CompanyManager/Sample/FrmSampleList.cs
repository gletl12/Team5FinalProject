using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager.Sample
{
    public partial class FrmSampleList : CompanyManager.MDIBaseForm
    {
        public FrmSampleList()
        {
            InitializeComponent();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "V")
            {
                this.Size = new Size(this.Size.Width, this.Size.Height * 3 / 2);
                


                btnDown.Text = "ᐱ";
            }
            else
            {
                btnDown.Text = "V";
               
            }
        }
    }
}
