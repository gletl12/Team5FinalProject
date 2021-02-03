using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class BOMDAC : CommonDAC
    {

        /// <summary>
        /// BOM정보를 
        /// </summary>
        /// <returns></returns>
        public List<CodeVO> GetBOMCode()
        {
            string sql = @"select code, category ,name from VW_BOMCBO";

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
                Log.WriteError("DAC_BOMDAC_GetBOMCode() 오류", err);
                return new List<CodeVO>();
            }
        }

        /// <summary>
        /// BOM정보를 추가합니다.
        /// </summary>
        /// <param name="insertList"></param>
        /// <returns></returns>
        public bool AddBOM(List<BOMVO> insertList)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"SP_ADDBOM";




                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@bom_parent_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_id", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bom_use_qty", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@start_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@end_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@bom_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@plan_use", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@auto_deduction", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@bom_comment", System.Data.SqlDbType.Text);
                    cmd.Parameters.Add("@ins_date", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@ins_emp", System.Data.SqlDbType.Int);
                   
                   

                    int result = 0;
                    foreach (BOMVO vo in insertList)
                    {
                        cmd.Parameters["@bom_parent_id"].Value = vo.bom_parent_id;
                        cmd.Parameters["@item_id"].Value = vo.item_id;
                        cmd.Parameters["@bom_use_qty"].Value = vo.bom_use_qty;
                        cmd.Parameters["@start_date"].Value = vo.start_date;
                        cmd.Parameters["@end_date"].Value = vo.end_date;
                        cmd.Parameters["@bom_use"].Value = vo.bom_use;
                        cmd.Parameters["@auto_deduction"].Value = vo.auto_deduction;
                        cmd.Parameters["@plan_use"].Value = vo.plan_use;
                        cmd.Parameters["@bom_comment"].Value = vo.bom_comment == "" ? (object)DBNull.Value : vo.bom_comment;
                        cmd.Parameters["@ins_emp"].Value = vo.ins_emp;
                        cmd.Parameters["@ins_date"].Value = vo.ins_date;

                        result += cmd.ExecuteNonQuery();
                    }

                    if (result == insertList.Count)
                    {
                        trans.Commit();
                        Dispose();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        Dispose();
                        return false;
                    }


                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                conn.Close();
                Log.WriteError("DAC_BORDAC_AddBORList() 오류", err);
                return false;
            }
        }
    }
}
