using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using VO;
namespace DAC
{
    public class DispendDAC : CommonDAC
    {
        public List<CodeVO> GetMachineCodes()
        {
            string sql = @"select machine_id code,machine_name name,'MACHINE' category from TBL_MACHINE";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<CodeVO> list = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_GetMachineCode() 오류", err);
                    return null;
                }
            }
        }

        public List<DispendWOVO> GetWorkOrderList(DateTime from, DateTime to)
        {
            string sql = @"select * from VW_DISPENDORDERS
                           where wo_sdate >= @from and wo_sdate <= @to";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    List<DispendWOVO> list = Helper.DataReaderMapToList<DispendWOVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_DispendDAC_GetWorkOrderList() 오류", err);
                    return null;
                }
            }
        }
    }
}
