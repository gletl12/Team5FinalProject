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
            string sql = @"SELECT wo_id, item_id, prod_id, wo_qty, wo_sdate, wo_people, wo_start, wo_end, ins_date, ins_emp, up_date, up_emp,wo_state
                            FROM TBL_WORK_ORDER";

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
