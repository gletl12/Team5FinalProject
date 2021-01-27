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
                MessageBox.Show("아이디 또는 비밀번호를 확인해주세요.");
                return;
            }
            //EmployeesDB epDB = new EmployeesDB();
            //Employees member = epDB.Login(idtxt.Text.Trim(), pwdtxt.Text.Trim());
            //epDB.Dispose();
            //if (member == null)
            if(true)
            {
                MessageBox.Show("아이디 또는 비밀번호가 일치하지 않습니다. 다시 확인해 주세요.");
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                //if ()
                //{
                //    MessageBox.Show($"{member.Name}님 로그인");

                //}
            }


        }
    }
}
