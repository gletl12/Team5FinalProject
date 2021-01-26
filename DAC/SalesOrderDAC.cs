using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using VO;

namespace DAC
{
    public class SalesOrderDAC : CommonDAC
    {
        public bool CommitSO(List<SalesOrderVO> list)
        {
            string sql = @"insert into TBL_SO_MASTER(plan_date, company_id, item_id, order_id, due_date, so_qty, so_comment, mkt, currency, so_state)
				                              values(@plan_date, @company_id, @item_id, @order_id, @due_date, @so_qty, @so_comment, @mkt, @currency, @so_state)";
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Transaction = trans;
                    cmd.Parameters.Add("@plan_date", SqlDbType.Date);
                    cmd.Parameters.Add("@company_id", SqlDbType.Int);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@order_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@due_date", SqlDbType.Date);
                    cmd.Parameters.Add("@so_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@so_comment", SqlDbType.Text);
                    cmd.Parameters.Add("@mkt", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@currency", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@so_state", SqlDbType.NVarChar);
                    foreach (SalesOrderVO item in list)
                    {
                        cmd.Parameters["@plan_date"].Value = item.plan_date;
                        cmd.Parameters["@company_id"].Value = item.company_id;
                        cmd.Parameters["@item_id"].Value = item.item_id;
                        cmd.Parameters["@order_id"].Value = item.order_id;
                        cmd.Parameters["@due_date"].Value = item.due_date;
                        cmd.Parameters["@so_qty"].Value = item.so_qty;
                        cmd.Parameters["@so_comment"].Value = item.so_comment;
                        cmd.Parameters["@mkt"].Value = item.mkt;
                        cmd.Parameters["@currency"].Value = item.currency;
                        cmd.Parameters["@so_state"].Value = "SO001";
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Log.WriteError("DAC_SalesOrderDAC_CommitSO() 오류", err);
                return false;
            }
        }

        public List<CodeVO> GetAllCodes()
        {
            string sql = @"select * from VW_SOCODE";
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
                    Log.WriteError("DAC_SalesOrderDAC_GetAllCodes 오류", err);
                    return null;
                }
            }

        }
    }
}
