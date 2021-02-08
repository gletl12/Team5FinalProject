using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class MGradeDAC : CommonDAC
    {
        public List<MGradeVO> GetMGrade()
        {
            try
            {
                string sql = @"SELECT machine_grade, mgrade_name, mgrade_code, mgrade_use, mgrade_comment, up_date, up_emp
                               FROM TBL_MACHINE_GRADE
                               ORDER BY machine_grade";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<MGradeVO> list = Helper.DataReaderMapToList<MGradeVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;

                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("MGradeDAC : GetMGrade", err);

                return new List<MGradeVO>();
            }
        }

    }
}
