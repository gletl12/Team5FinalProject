using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class FactoryDAC : CommonDAC
    {
        public List<FactoryVO> GetFactory()
        {
            try
            {
                string sql = @"select factory_grade, factory_type, factory_name, factory_parent, factory_use, 
                                      factory_comment, up_date, up_emp
                               from TBL_FACTORY";
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_GetFactory 오류", err);

                return new List<FactoryVO>();
            }
        }
        public bool AddFactory(FactoryVO vo)
        {
            try
            {
                string sql = @"insert into TBL_FACTORY 
                               values(@factory_grade, @factory_type, @factory_name, @factory_parent, 
                                      @factory_use, @factory_comment, @ins_date, @ins_emp, @up_date, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@factory_grade", vo.factory_grade);
                    cmd.Parameters.AddWithValue("@factory_type", vo.factory_type);
                    cmd.Parameters.AddWithValue("@factory_name", vo.factory_name);
                    cmd.Parameters.AddWithValue("@factory_parent", vo.factory_parent);
                    cmd.Parameters.AddWithValue("@factory_use", vo.factory_use);
                    cmd.Parameters.AddWithValue("@factory_comment", vo.factory_comment);
                    cmd.Parameters.AddWithValue("@ins_date", vo.up_date.ToString("G"));
                    cmd.Parameters.AddWithValue("@ins_emp", vo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", vo.up_date.ToString("G"));
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
                Log.WriteError("DAC_AddFactory() 오류", err);

                return false;
            }

        }
        public List<FactoryVO> GetFactory(string str, string str2)
        {
            try
            {
                string sql = @"select factory_grade, factory_type, factory_name, factory_parent, factory_use,
                                      factory_comment, up_date, up_emp
                               from TBL_FACTORY
                               where factory_grade = @factory_grade and factory_name like '%@factory_name%'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@factory_grade", str);
                    cmd.Parameters.AddWithValue("@factory_name", str2);
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_GetFactory(str,str) 오류", err);

                return new List<FactoryVO>();
            }

        }
    }
}
