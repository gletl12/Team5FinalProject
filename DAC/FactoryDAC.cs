using System;
using System.Collections.Generic;
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
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select 
                                        factory_grade, 
                                        factory_type, 
                                        factory_name, 
                                        factory_parent, 
                                        factory_use, 
                                        factory_comment,
                                        up_date, 
                                        up_emp
                                        from TBL_FACTORY";
                    cmd.Connection = conn;
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_FactoryVO_GetMachine() 오류", err);

                return new List<FactoryVO>();
            }


        }
    }
}
