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
                string sql = @"SELECT machine_grade, mgrade_name, mgrade_code, c.name as mgrade_use, mgrade_comment, up_date, up_emp
                                      FROM TBL_MACHINE_GRADE m inner join TBL_COMMON_CODE c on m.mgrade_use = c.code
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

        public bool DeleteMGrade(int machine_grade)
        {
            try
            {
                string sql = @"Delete from TBL_MACHINE_GRADE where machine_grade = @machine_grade";
                
                               
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_grade", machine_grade);
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
                Log.WriteError("MGradeDAC : DeleteMGrade", err);

                return false;
            }
        }

        public bool UpdateMGrade(MGradeVO vo)
        {
            try
            {
                string sql = @"update TBL_MACHINE_GRADE set mgrade_name = @mgrade_name,
                                                            mgrade_code = @mgrade_code, mgrade_use = @mgrade_use, mgrade_comment = @mgrade_comment,
                                                            up_emp = @up_emp
                               where machine_grade = @machine_grade";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_grade", vo.machine_grade);
                    cmd.Parameters.AddWithValue("@mgrade_name", vo.mgrade_name);
                    cmd.Parameters.AddWithValue("@mgrade_code", vo.mgrade_code);
                    cmd.Parameters.AddWithValue("@mgrade_use", vo.mgrade_use);
                    cmd.Parameters.AddWithValue("@mgrade_comment", vo.mgrade_comment);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);

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
                Log.WriteError("MGradeDAC : UpdateMGrade", err);

                return false;
            }
        }

        public bool InsertMGrade(MGradeVO vo)
        {
            try
            {
                string sql = @"insert into TBL_MACHINE_GRADE (machine_grade, mgrade_name, mgrade_code, mgrade_use, mgrade_comment, 
                                                              ins_emp, up_emp)
                               values(@machine_grade, @mgrade_name, @mgrade_code, @mgrade_use, @mgrade_comment, 
                                      @ins_emp, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_grade", vo.machine_grade);
                    cmd.Parameters.AddWithValue("@mgrade_name", vo.mgrade_name);
                    cmd.Parameters.AddWithValue("@mgrade_code", vo.mgrade_code);
                    cmd.Parameters.AddWithValue("@mgrade_use", vo.mgrade_use);
                    cmd.Parameters.AddWithValue("@mgrade_comment", vo.mgrade_comment);
                    cmd.Parameters.AddWithValue("@ins_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_emp", vo.up_emp);

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
                Log.WriteError("MGradeDAC : InsertMGrade", err);

                return false;
            }
        }
    }
}
