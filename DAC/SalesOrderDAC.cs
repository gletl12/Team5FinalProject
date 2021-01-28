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
            string sql = @"insert into TBL_SO_MASTER(plan_date, company_id, item_id, order_id, due_date, so_o_qty, so_comment, mkt, currency, so_state)
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
                        cmd.Parameters["@so_qty"].Value = item.so_o_qty;
                        cmd.Parameters["@so_comment"].Value = item.so_comment.Length < 1 ? (object)DBNull.Value : item.so_comment;
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

        public bool InsertSO(SalesOrderVO so)
        {
            string sql = @"INSERT INTO TBL_SO_MASTER(plan_date,company_id,item_id,order_id,due_date,so_comment,warehouse_id,so_o_qty,so_s_qty,so_c_qty,mkt,currency,so_state,ins_emp)
                                             VALUES(@plan_date,@company_id,@item_id,@order_id,@due_date,@so_comment,@warehouse_id,@so_o_qty,@so_s_qty,@so_c_qty,@mkt,@currency,@so_state,@ins_emp)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@plan_date", so.plan_date);
                    cmd.Parameters.AddWithValue("@company_id", so.company_id);
                    cmd.Parameters.AddWithValue("@item_id", so.item_id);
                    cmd.Parameters.AddWithValue("@order_id", so.order_id);
                    cmd.Parameters.AddWithValue("@due_date", so.due_date);
                    cmd.Parameters.AddWithValue("@so_comment", so.so_comment.Length < 1 ? (object)DBNull.Value : so.so_comment);
                    cmd.Parameters.AddWithValue("@warehouse_id", so.warehouse_id.Length < 1 ? (object)DBNull.Value : so.warehouse_id);
                    cmd.Parameters.AddWithValue("@so_o_qty", so.so_o_qty);
                    cmd.Parameters.AddWithValue("@so_s_qty", so.so_s_qty);
                    cmd.Parameters.AddWithValue("@so_c_qty", so.so_c_qty);
                    cmd.Parameters.AddWithValue("@mkt", so.mkt);
                    cmd.Parameters.AddWithValue("@currency", so.currency);
                    cmd.Parameters.AddWithValue("@so_state", "SO001");
                    cmd.Parameters.AddWithValue("@ins_emp", 1);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_InsertSO() 오류", err);
                    return false;
                }
            }
        }

        public List<SalesOrderVO> GetAllSO()
        {
            string sql = @"select * from VW_SOLIST";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    List<SalesOrderVO> list = Helper.DataReaderMapToList<SalesOrderVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_SalesOrderDAC_GetAllSO 오류", err);
                    return null;
                }
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
