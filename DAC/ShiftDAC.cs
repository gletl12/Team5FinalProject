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
                    cmd.CommandText = @"select 
                                        shift_id,
                                        machine_name,
                                        shift_type,
                                        shift_stime,
                                        shift_etime,
                                        shift_sdate,
                                        shift_edate,
                                        shift_use,
                                        shift_comment,
                                        Directly_Input_Person,
                                        Indirect_Input_Person,
                                        Nomal_Direct_WorkTime,
                                        Nomal_indirect_WorkTime,
                                        Overtime_Directly_WorkTime,
                                        Overtime_Indirect_WorkTime,
                                        Overtime_Directly_Input_Person,
                                        Overtime_Indirect_Input_Person,
                                        Directly_Accident_WorkTime,
                                        Indirect_Accident_WorkTime,
                                        Overtime_Directly_Accident_Time,
                                        Overtime_Indirect_Accident_Time
                            from TBL_SHIFT S inner join TBL_MACHINE M on S.machine_id=M.machine_id";
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
