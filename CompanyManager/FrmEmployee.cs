using CompanyManager.Properties;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmEmployee : CompanyManager.PopupBaseForm
    {
        List<EmployeeVO> list = new List<EmployeeVO>();
        public FrmEmployee()
        {
            InitializeComponent();
        }

        

        private void FrmEmployee_Load(object sender, EventArgs e)
        {


            GetdgvColumn();
            DataRoad();
            LoadCombobox();

        }

        private void LoadCombobox()
        {
            
        }

        private void DataRoad()
        {
            EmployeeService service = new EmployeeService();
            list = service.GetAllEmployee();

            dgvEmployee.DataSource = list;
            dgvEmployee.ClearSelection();
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign_Num(dgvEmployee);

            CommonUtil.SetDGVDesign_CheckBox(dgvEmployee);
            CommonUtil.AddGridImageColumn(dgvEmployee, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvEmployee, "ID", "emp_id", 80);
            CommonUtil.AddGridTextColumn(dgvEmployee, "Password", "emp_password");
            CommonUtil.AddGridTextColumn(dgvEmployee, "직원명", "emp_name", 70);
            CommonUtil.AddGridTextColumn(dgvEmployee, "부서명", "dept_name", 70);
            CommonUtil.AddGridTextColumn(dgvEmployee, "입사일", "hire_date");
            CommonUtil.AddGridTextColumn(dgvEmployee, "수정자", "up_emp", 80);
            CommonUtil.AddGridTextColumn(dgvEmployee, "수정시간", "up_date", 145);

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.AllowUserToAddRows = false;
        }
    }
}
