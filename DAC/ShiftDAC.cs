using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class ShiftDAC : CommonDAC
    {


        public List<ShiftVO> GetShift()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select shift_id,machine_id,shift_type,shift_stime,shift_etime,shift_sdate,shift_edate,shift_use,shift_comment
                                                            from TBL_SHIFT";
                    cmd.Connection = conn;
                    List<ShiftVO> temp = Helper.DataReaderMapToList<ShiftVO>(cmd.ExecuteReader());
                    Dispose();

                    return temp;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_ShiftDAC_GetShift() 오류", err);

                return new List<ShiftVO>();
            }


        }
    }
}
