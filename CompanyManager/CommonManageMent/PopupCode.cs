using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopupCode : CompanyManager.PopupBaseForm
    {
        public string Code 
        {
            get { return txtCode.Text; }
            set { txtCode.Text = value; }
        }
        public string Name
        {
            get { return txtCodeName.Text; }
            set { txtCodeName.Text = value; }
        }
        public string Category
        {
            get { return txtCategory.Text; }
            set { txtCategory.Text = value; }
        }
        public string Pcode
        {
            get { return txtpCode.Text; }
            set { txtpCode.Text = value; }
        }
        public PopupCode()
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "공통코드";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //유효성 검사
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (((TextBox)sender).Text.Length > 10)
            {
                e.Handled = true;
            }
        }
    }
}
