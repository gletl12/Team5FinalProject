using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class MachineDAC :CommonDAC
    {
        public List<MachineVO> GetMachine()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select 
                                        machine_id,
                                        machine_grade,
                                        machine_name,
                                        use_warehouse_id,
                                        ok_warehouse_id,
                                        ng_warehouse_id,
                                        m_os_use,
                                        mcachine_comment,
                                        machine_use,
                                        ins_date,
                                        ins_emp,
                                        up_date,
                                        up_emp
                                        from TBL_MACHINE";
                    cmd.Connection = conn;
                    List<MachineVO> temp = Helper.DataReaderMapToList<MachineVO>(cmd.ExecuteReader());
                    Dispose();

                    return temp;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MachineDAC_GetMachine() 오류", err);

                return new List<MachineVO>();
            }


        }
    }
}
