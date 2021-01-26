using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class Login : CompanyManager.PopupBaseForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtPassword.Text = "";
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Length < 1 || txtPassword.Text.Length < 1)
            {
                MessageBox.Show("입력 정보를 확인해주세요.");
                return;
            }


        }
    }
}
