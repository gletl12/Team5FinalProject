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
        public List<EmployeeVO> GetLogin(string id, string pwd)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT emp_no, emp_password, emp_name, dept_no, hire_date, up_date, up_emp
                                        FROM TBL_Employee
                                        where emp_no = @id and emp_password = @pwd";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pwd", pwd);

                    cmd.Connection = conn;
                    List<EmployeeVO> list = Helper.DataReaderMapToList<EmployeeVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_FactoryVO_GetMachine() 오류", err);

                return new List<EmployeeVO>();
            }


        }
    }
}
