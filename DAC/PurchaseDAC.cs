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
    public class PurchaseDAC : CommonDAC
    {
        public DataTable GetDGVInfo(DateTime value1, DateTime value2)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SP_Purchase";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Start_DT", value1);
                    da.SelectCommand.Parameters.AddWithValue("@End_DT", value2);

                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception err)
            {
                //로그 오류
                Log.WriteError("DAC_PurchaseDAC_GetDGVInfo() 오류", err);
                return null;
            }
        }

        public List<PurchasesListVO> GetPurchasesList(DateTime from, DateTime to)
        {
            try
            {
                List<PurchasesListVO> list = new List<PurchasesListVO>();
                string sql = @"select purchase_id ,pd_id,company_name,CD2.name purchase_state,PD.item_id,item_name,CD.name unit,due_date,pd_qty,in_qty,in_cqty,pd_qty-isnull(in_cqty,0)-isnull(in_qty,0) Cancellable,
                               	   PD.ins_date,emp_name
                               from TBL_PURCHASE_DETAIL PD JOIN TBL_ITEM I ON PD.item_id = I.item_id
                               						    JOIN TBL_COMPANY C ON C.company_id = I.supply_company
                               							LEFT JOIN TBL_INBOUND B ON B.prod_id = PD.prod_id and B.item_id = PD.item_id
                               							LEFT JOIN TBL_Employee E ON E.emp_id = PD.ins_emp
                               							JOIN TBL_COMMON_CODE CD ON CD.code = item_unit
                               							left JOIN TBL_COMMON_CODE CD2 ON CD2.code = purchase_state
                              where due_date between @Start_DT and @End_DT;";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Start_DT", from);
                    cmd.Parameters.AddWithValue("@End_DT", to);
                    list = Helper.DataReaderMapToList<PurchasesListVO>(cmd.ExecuteReader());
                    return list;
                }
            }
            catch (Exception err)
            {
                //로그 오류
                Log.WriteError("DAC_PurchaseDAC_GetPurchasesList() 오류", err);
                return null;
            }
        }

        public List<CodeVO> GetAllCodes()
        {
            List<CodeVO> list = new List<CodeVO>();
            string sql = @"select  * from VW_PURCHASESLISTCODE";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    list = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_PurchaseDAC_GetAllCodes() 오류", err);
                    return null;
                }
            }
        }

        public bool UpdateDueDate(int pdID, DateTime dueDate)
        {
            string sql = @"update TBL_PURCHASE_DETAIL set due_date = @due_date,
                                                          up_emp = @up_emp,
                                                          up_date = @up_date
                           where pd_id = @pd_id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@pd_id", pdID);
                    cmd.Parameters.AddWithValue("@due_date", dueDate);
                    cmd.Parameters.AddWithValue("@up_emp", "1");
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_PurchaseDAC_UpdateDueDate() 오류", err);
                    return false;
                }
            }
        }

        public bool DeletePurchases(List<int> selectedRows)
        {
            string sql = @"delete from TBL_PURCHASE_DETAIL where pd_id = @pd_id";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.Parameters.Add("@pd_id", SqlDbType.Int);
                    foreach (int pdID in selectedRows)
                    {
                        cmd.Parameters["@pd_id"].Value = pdID;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_PurchaseDAC_DeletePurchases() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool NewPurchases(List<PurchasesVO> selectedRows)
        {
            string sql = @"";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = @"insert into TBL_PURCHASE(purchase_type,  ins_emp)
                                                          values('PUR01', @ins_emp);
                                        select @@IDENTITY; ";
                    cmd.Parameters.AddWithValue(@"@ins_emp", 1);
                    int purchasesID = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.Parameters.Clear();

                    cmd.CommandText = @"insert into TBL_PURCHASE_DETAIL(prod_id, purchase_id, item_id, pd_qty, due_date, warehouse_id, purchase_state, pd_os_use,ins_emp)
						                                         values(@prod_id, @purchase_id, @item_id, @pd_qty, @due_date, @warehouse_id, @purchase_state, @pd_os_use,@ins_emp)";
                    cmd.Parameters.AddWithValue("@pd_os_use", false);
                    cmd.Parameters.AddWithValue("@purchase_id", purchasesID);
                    cmd.Parameters.AddWithValue("@ins_emp", 1);

                    cmd.Parameters.Add("@prod_id", SqlDbType.Int);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@pd_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@due_date", SqlDbType.Date);
                    cmd.Parameters.Add("@warehouse_id", SqlDbType.Int);
                    cmd.Parameters.Add("@purchase_state", SqlDbType.NVarChar);

                    foreach (PurchasesVO item in selectedRows)
                    {
                        cmd.Parameters["@prod_id"].Value = item.prod_id;
                        cmd.Parameters["@item_id"].Value = item.item_id;
                        cmd.Parameters["@pd_qty"].Value = item.p_qty;
                        cmd.Parameters["@due_date"].Value = item.DueDate;
                        cmd.Parameters["@warehouse_id"].Value = item.in_warehouse;
                        cmd.Parameters["@purchase_state"].Value = "PUR01";
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_PurchaseDAC_NewPurchases() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public List<PurchasesVO> GetPurchasesDemand()
        {
            string sql = @"
                           select supply_company,company_name,I.item_id,item_name,P.prod_id,
                            case isnull(sign(sum(P2.prod_qty)),0)
                            	when 0 then P.prod_qty*B.bom_use_qty-(isnull(sum(pd_qty),0)  + isnull(sum(in_rqty),0)) + item_safety_qty
                            	when 1 then P.prod_qty*B.bom_use_qty-item_safety_qty
                            end as p_qty,in_warehouse,warehouse_name,P.start_date DueDate
							from TBL_PRODUCTION_PLAN P JOIN  TBL_BOM B ON P.item_id = B.bom_parent_id
													   JOIN TBL_ITEM I ON B.item = I.item_id
													   JOIN TBL_COMPANY C ON C.company_id = I.supply_company
													   JOIN TBL_WAREHOUSE W ON W.warehouse_id = I.in_warehouse
													   LEFT JOIN TBL_PRODUCTION_PLAN P2 ON P2.start_date<P.start_date and P2.item_id = P.item_id
													   LEFT JOIN TBL_INBOUND N ON N.item_id = I.item_id and I.in_warehouse = N.wh_id
													   LEFT JOIN (select item_id,pd_qty,due_date,prod_id
																  from TBL_PURCHASE_DETAIL where purchase_state='PUR01') PD ON PD.item_id = I.item_id and PD.prod_id =P.prod_id
													   where p.prod_id NOT IN (select prod_id
																  from TBL_PURCHASE_DETAIL where item_id = I.item_id)
                            group by supply_company,company_name,I.item_id,item_name,P.prod_id,P.prod_qty,bom_use_qty,item_safety_qty,P.prod_qty,in_warehouse,warehouse_name,P.start_date
                            order by prod_id";
            List<PurchasesVO> list = new List<PurchasesVO>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    list = Helper.DataReaderMapToList<PurchasesVO>(cmd.ExecuteReader());
                    conn.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                //로그 오류
                Log.WriteError("DAC_PurchaseDAC_GetPurchasesDemand() 오류", err);
                return null;
            }
        }
    }
}
