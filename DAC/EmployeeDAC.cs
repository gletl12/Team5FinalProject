using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class EmployeeDAC : CommonDAC
    {
        public (bool, EmployeeVO) GetLogin(string id, string pwd)
        {
            try
            {
                string sql = @"SELECT emp_id, emp_password, emp_name, dept_no, hire_date, up_date, up_emp
                                        FROM TBL_Employee
                                        where emp_id = @id and emp_password = @pwd";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pwd", pwd);

                    SqlDataReader reader = cmd.ExecuteReader();
                    EmployeeVO emp = Helper.DataReaderMapToList<EmployeeVO>(reader)[0];

                    Dispose();

                    return emp == null ? (false, null) : (true, emp);

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("FrmLogin : 로그인 실패", err);

                return (false, null);
            }


        }

        

        public List<EmployeeVO> GetAllEmployee()
        {
            try
            {
                string sql = @"SELECT emp_id, emp_password, emp_name, dept_name, hire_date, up_date, up_emp
                               FROM VW_EMPLOYEE";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<EmployeeVO> list = Helper.DataReaderMapToList<EmployeeVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC : GetAllEmployee", err);

                return new List<EmployeeVO>();
            }

        }

        public List<DeptVO> GetDept()
        {
            try
            {
                string sql = @"SELECT dept_id, dept_name
                               FROM TBL_DEPT
                               ORDER BY dept_name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<DeptVO> list = Helper.DataReaderMapToList<DeptVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("EmployeeDAC : GetDept", err);

                return new List<DeptVO>();
            }

        }

        public bool AddEmployee(EmployeeVO evo)
        {
            try
            {
                string sql = @"insert into TBL_Employee (emp_id, emp_password, emp_name, dept_no, hire_date,  ins_emp,  up_emp)
                               values(@emp_id, @emp_password, @emp_name, @dept_no, @hire_date,  @ins_emp,  @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", evo.emp_id);
                    cmd.Parameters.AddWithValue("@emp_password", evo.emp_password);
                    cmd.Parameters.AddWithValue("@emp_name", evo.emp_name);
                    cmd.Parameters.AddWithValue("@dept_no", evo.dept_no);
                    cmd.Parameters.AddWithValue("@hire_date", evo.hire_date);
                    cmd.Parameters.AddWithValue("@ins_emp", evo.up_emp);
                    cmd.Parameters.AddWithValue("@up_emp", evo.up_emp);

                    int iRows = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("EmployeeDAC : AddEmployee", err);

                return false;
            }
        }

        public bool UpdateEmployee(EmployeeVO evo)
        {
            try
            {
                string sql = @"update TBL_Employee set emp_password = @emp_password, emp_name = @emp_name, 
                                                       dept_no = @dept_no, hire_date = @hire_date, up_emp = @up_emp
                               where emp_id = @emp_id";
                                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", evo.emp_id);
                    cmd.Parameters.AddWithValue("@emp_password", evo.emp_password);
                    cmd.Parameters.AddWithValue("@emp_name", evo.emp_name);
                    cmd.Parameters.AddWithValue("@dept_no", evo.dept_no);
                    cmd.Parameters.AddWithValue("@hire_date", evo.hire_date);
                    cmd.Parameters.AddWithValue("@up_emp", evo.up_emp);

                    int iRows = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("EmployeeDAC : UpdateEmployee", err);

                return false;
            }
        }

        public bool DeleteEmployee(int emp_id)
        {
            try
            {
                string sql = @"Delete From TBL_Employee 
                               where emp_id = @emp_id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@emp_id", emp_id);

                    int iRows = cmd.ExecuteNonQuery();
                    Dispose();
                    if (iRows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("EmployeeDAC : DeleteEmployee", err);

                return false;
            }
        }
    }
}
