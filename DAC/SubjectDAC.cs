using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class SubjectDAC  : CommonDAC
    {
        /// <summary>
        /// 품목관리에서 사용하는 공통코드를 불러옵니다.
        /// </summary>
        /// VW_SUBJECTCBO
        /// <returns></returns>
        public List<CodeVO> GetSubjectCode()
        {
            string sql = @"select code, category ,name from VW_Subjectcbo";

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
                Log.WriteError("DAC_SubjectDAC_GetSubjectCod() 오류", err);
                return new List<CodeVO>();
            }


        }

        public bool AddSubject(List<SubjectVO> insertInfo)
        {
            try
            {
                string sql = "";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<SubjectVO> temp = Helper.DataReaderMapToList<SubjectVO>(cmd.ExecuteReader());
                    conn.Close();
                    return true;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_SubjectDAC_GetSubjectList() 오류", err);
                return false;
            }
        }

        /// <summary>
        /// 품목 데이터 리스트를 불러옵니다.
        /// </summary>
        /// <returns></returns>
        public List<SubjectVO> GetSubjectList()
        {
            string sql = @"select item_id,
                                  item_type,
                                  item_name,
                                  item_unit,
                                  item_unit_qty,
                                  import_inspection,
                                  process_inspection,
                                  shipment_inspection,
                                  free_of_charge,
                                  order_company,
                                  supply_company,
                                  item_leadtime,
                                  item_lorder_qty,
                                  item_delivery_qty,
                                  item_safety_qty,
                                  item_grade,
                                  item_manager,
                                  item_use,
                                  item_comment,
                                  up_date,
                                  up_emp,
                                  in_warehouse,
                                  out_warehouse,
                                  extinction
                             from TBL_ITEM";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<SubjectVO> temp = Helper.DataReaderMapToList<SubjectVO>(cmd.ExecuteReader());
                    conn.Close();
                    return temp;
                }
            }
            catch (Exception err)
            {
                conn.Close();
                Log.WriteError("DAC_SubjectDAC_GetSubjectList() 오류", err);
                return new List<SubjectVO>();
            }
        }
    }
}
