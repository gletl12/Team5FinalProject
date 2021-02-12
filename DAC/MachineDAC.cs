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


        public int MachineRun(string task_ID, string workUserName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"insert into TBL_MACHINE_RUN (machine_id,run_start,ins_date,ins_emp)
                                        values (@machine_id,@day,@day1,'경훈');
                                        select @@IDENTITY; ";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@machine_id", task_ID);
                    cmd.Parameters.AddWithValue("@ins_emp", workUserName);
                    cmd.Parameters.AddWithValue("@day", DateTime.Now);
                    cmd.Parameters.AddWithValue("@day1", DateTime.Now);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    Dispose();

                    return id;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MachineDAC_MachineRun() 오류", err);

                return -1;
            }
        }

        public bool MachineEnd(int runid, string workUserName)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"update TBL_MACHINE_RUN set run_end=@run_end,
                                                                    up_date=@up_date,
								                                    up_emp=@up_emp
                                                    where run_id=@run_id ";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@run_id", runid);
                    cmd.Parameters.AddWithValue("@run_end", DateTime.Now);
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@up_emp", workUserName);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    Dispose();

                    return iRowAffect > 0;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MachineDAC_MachineEnd() 오류", err);

                return false;
            }
        }
    }
}
