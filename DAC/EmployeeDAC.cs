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
                using (SqlCommand cmd = new SqlCommand(sql,conn))
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
    }
}
