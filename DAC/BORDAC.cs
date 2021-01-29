using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class BORDAC : CommonDAC
    {
        public List<CodeVO> GetBORCode()
        {
            string sql = @"select code, category ,name from VW_BORCODE";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<CodeVO> temp = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_BORDAC_GetBORCode() 오류", err);
                return new List<CodeVO>();
            }

        }
    }
}
