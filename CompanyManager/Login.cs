using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class Login : CompanyManager.PopupBaseForm
    {
        List<EmployeeVO> employee = new List<EmployeeVO>();
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
            EmployeeService emp = new EmployeeService();
            employee = emp.GetLogin(txtID.Text, txtPassword.Text);
            
            if (employee.Count < 1)
            {
                MessageBox.Show("아이디 또는 비밀번호가 일치하지 않습니다. 다시 확인해 주세요.");
                return;
            }
            


        }
    }
}
