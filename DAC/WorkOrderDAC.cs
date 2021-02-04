using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
   public class WorkOrderDAC : CommonDAC
    {
        public List<WorkOrderVO> GetWorkOrder()
        {
            string sql = @"SELECT wo_id,
                                    W.item_id,
                                    B.machine_id,
                                    machine_name,
                                    prod_id,
                                    wo_qty,
                                    wo_sdate,
                                    wo_people,
                                    wo_start,
                                    wo_end,
                                    W.ins_date,
                                    W.ins_emp,
                                    W.up_date,
                                    W.up_emp,
                                    wo_state
                                    
                    FROM TBL_WORK_ORDER W inner join TBL_BOR B on B.item_id=W.item_id
						inner join TBL_MACHINE M on M.machine_id=B.machine_id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<WorkOrderVO> temp = Helper.DataReaderMapToList<WorkOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_WorkOrderDAC_GetWorkOrder() 오류", err);
                return new List<WorkOrderVO>();
            }
        }

        
    }
}
