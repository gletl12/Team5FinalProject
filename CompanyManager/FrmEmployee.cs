using CompanyManager.Properties;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmEmployee : CompanyManager.PopupBaseForm
    {
        List<EmployeeVO> list = new List<EmployeeVO>();
        EmployeeVO evo = new EmployeeVO();
        List<DeptVO> combobox;
        int id;
        public FrmEmployee(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            GetdgvColumn();
            DataRoad();
            RoadCombobox();
        }

        private void RoadCombobox()
        {
            EmployeeService service = new EmployeeService();
            combobox = service.GetDept();

            cboDept.DisplayMember = "dept_name";
            cboDept.ValueMember = "dept_name";
            List<DeptVO> temp = (from dept in combobox
                                 select dept).ToList();
            temp.Insert(0, new DeptVO { dept_id = 0, dept_name = "" });
            cboDept.DataSource = temp;
        }

        private void RoadDept()
        {
            for(int i = 0; i < combobox.Count; i++)
            {

            }
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

            CommonUtil.AddGridImageColumn(dgvEmployee, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvEmployee, "ID", "emp_id", 80);
            CommonUtil.AddGridTextColumn(dgvEmployee, "Password", "emp_password");
            CommonUtil.AddGridTextColumn(dgvEmployee, "직원명", "emp_name", 70);
            CommonUtil.AddGridTextColumn(dgvEmployee, "부서명", "dept_name", 70);
            CommonUtil.AddGridTextColumn(dgvEmployee, "입사일", "hire_date");
            CommonUtil.AddGridTextColumn(dgvEmployee, "수정자", "up_emp", 80);
            CommonUtil.AddGridTextColumn(dgvEmployee, "수정시간", "up_date", 148);

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.AllowUserToAddRows = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (txtEmpName.Text.Length < 1 && cboDept.SelectedIndex == 0)
            {
                DataRoad();
            }
            else if (txtEmpName.Text.Length > 0 && cboDept.SelectedIndex != 0)
            {
                var sResult = (from emp_id
                                in list
                                where
                                emp_id.emp_name.Contains(txtEmpName.Text) && emp_id.dept_name.Equals(cboDept.SelectedValue)
                                select emp_id).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = sResult;
            }
            else if (txtEmpName.Text.Length > 0 && cboDept.SelectedIndex == 0)
            {
                var sResult = (from emp_id
                            in list
                                where
                                emp_id.emp_name.Contains(txtEmpName.Text)
                                select emp_id).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = sResult;
            }
            else
            {
                var sResult = (from emp_id
                                in list
                                where
                                emp_id.dept_name.Equals(cboDept.SelectedValue)
                                select emp_id).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = sResult;
            }

           
        }

        private void btnEmpRegister_Click(object sender, EventArgs e)
        {
            PopEmployeeCRUD pop = new PopEmployeeCRUD(id);
            if(pop.ShowDialog() == DialogResult.OK)
            {
                DataRoad();
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                evo.emp_id = list[e.RowIndex].emp_id;
                evo.emp_password = list[e.RowIndex].emp_password;
                evo.emp_name = list[e.RowIndex].emp_name;
                evo.dept_name = list[e.RowIndex].dept_name;
                evo.hire_date = list[e.RowIndex].hire_date;
                if (e.ColumnIndex == 0)
                {
                    PopEmployeeCRUD pop = new PopEmployeeCRUD(id, evo, true);
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        DataRoad();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(evo == null)
            {
                MessageBox.Show("삭제할 직원을 선택해주세요.");
                return;
            }

            if(MessageBox.Show($"{evo.dept_name}을 정말로 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EmployeeService service = new EmployeeService();
                if(service.DeleteEmployee(evo.emp_id))
                {
                    MessageBox.Show("직원 정보가 삭제되었습니다.");
                    DataRoad();
                }
                else
                {
                    MessageBox.Show("직원 정보 삭제에 실패하였습니다.");
                }
            }
        }
    }
}
