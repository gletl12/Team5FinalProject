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


        public bool InsertMachine(MachinesVO mvo)
        {
            try
            {
                string sql = @"insert into TBL_MACHINE (machine_id, machine_grade, machine_name, use_warehouse_id, ok_warehouse_id, ng_warehouse_id, 
                                                        m_os_use, mcachine_comment, machine_use, ins_date, ins_emp, up_date, up_emp)
                               values(@machine_id, @machine_grade, @machine_name, @use_warehouse_id, @ok_warehouse_id, @ng_warehouse_id, 
                                      @m_os_use, @mcachine_comment, @machine_use, @ins_date, @ins_emp, @up_date, @up_emp)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_id", mvo.machine_id);
                    cmd.Parameters.AddWithValue("@machine_grade", mvo.machine_grade);
                    cmd.Parameters.AddWithValue("@machine_name", mvo.machine_name);
                    cmd.Parameters.AddWithValue("@use_warehouse_id", mvo.use_warehouse_id);
                    cmd.Parameters.AddWithValue("@ok_warehouse_id", mvo.ok_warehouse_id);
                    cmd.Parameters.AddWithValue("@ng_warehouse_id", mvo.ng_warehouse_id);
                    cmd.Parameters.AddWithValue("@m_os_use", mvo.m_os_use);
                    cmd.Parameters.AddWithValue("@mcachine_comment", mvo.machine_comment);
                    cmd.Parameters.AddWithValue("@machine_use", mvo.machine_use);
                    cmd.Parameters.AddWithValue("@ins_date", mvo.up_date);
                    cmd.Parameters.AddWithValue("@ins_emp", mvo.up_emp);
                    cmd.Parameters.AddWithValue("@up_date", mvo.up_date);
                    cmd.Parameters.AddWithValue("@up_emp", mvo.up_emp);

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
                Log.WriteError("MachineDAC_InsertMachine() 오류", err);

                return false;
            }
        }

        public bool UpdateMachine(MachinesVO mvo)
        {
            try
            {
                string sql = @"update TBL_MACHINE set machine_name = @machine_name, use_warehouse_id = @use_warehouse_id,       
                                                      ok_warehouse_id = @ok_warehouse_id, ng_warehouse_id = @ng_warehouse_id,
                                                      m_os_use = @m_os_use, machine_comment = @machine_comment, machine_use = @machine_use, 
                                                      up_date = @up_date, up_emp = @up_emp
                               where machine_id = @machine_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_id", mvo.machine_id);
                    cmd.Parameters.AddWithValue("@machine_name", mvo.machine_name);
                    cmd.Parameters.AddWithValue("@use_warehouse_id", mvo.use_warehouse_id);
                    cmd.Parameters.AddWithValue("@ok_warehouse_id", mvo.ok_warehouse_id);
                    cmd.Parameters.AddWithValue("@ng_warehouse_id", mvo.ng_warehouse_id);
                    cmd.Parameters.AddWithValue("@m_os_use", mvo.m_os_use);
                    cmd.Parameters.AddWithValue("@machine_comment", mvo.machine_comment);
                    cmd.Parameters.AddWithValue("@machine_use", mvo.machine_use);
                    cmd.Parameters.AddWithValue("@up_date", mvo.up_date);
                    cmd.Parameters.AddWithValue("@up_emp", mvo.up_emp);


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
                Log.WriteError("MachineDAC_UpdateMachine() 오류", err);

                return false;
            }
        }

        public List<MachinesVO> GetMachine(int mgrade)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select 
                                        machine_id,
                                        machine_grade,
                                        machine_name,
                                        w.warehouse_name as use_warehouse_id,
                                        w.warehouse_name as ok_warehouse_id,
                                        w.warehouse_name as ng_warehouse_id,
                                        o.name as m_os_use,
                                        machine_comment,
                                        c.name as machine_use,
                                        m.up_date,
                                        m.up_emp
                                        from TBL_MACHINE m inner join TBL_COMMON_CODE c on m.machine_use = c.code
                                                           inner join TBL_COMMON_CODE o on m.m_os_use = o.code 
                                                           inner join TBL_WAREHOUSE w on m.use_warehouse_id = w.warehouse_id
                                        where machine_grade = @machine_grade";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@machine_grade", mgrade);
                    List<MachinesVO> temp = Helper.DataReaderMapToList<MachinesVO>(cmd.ExecuteReader());
                    Dispose();

                    return temp;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MachineDAC_GetMachine(int mgrade) 오류", err);

                return new List<MachinesVO>();
            }
        }


        public bool DeleteMachine(string machine_id)
        {
            try
            {
                string sql = @"delete from TBL_MACHINE where machine_id = @machine_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@machine_id", machine_id);

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
                Log.WriteError("MachineDAC_DeleteMachine() 오류", err);

                return false;
            }
        }
    }
}
