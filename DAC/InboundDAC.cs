using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class InboundDAC : CommonDAC
    {
        public List<InboundVO> GetPurchasesList(DateTime from, DateTime to)
        {
            List<InboundVO> list = new List<InboundVO>();
            string sql = @"select purchase_id,pd_id,cast(PD.ins_date as date) PurchasesDate,PD.prod_id,item_unit,company_name,PD.item_id,item_name,CD.name unit,CD2.name UseCheck,pd_qty,isnull(rqty,0) InQty,
                           pd_qty-isnull(rqty,0) RQty, due_date
                           from TBL_PURCHASE_DETAIL PD JOIN TBL_ITEM I ON PD.item_id = I.item_id
                           							   JOIN TBL_COMPANY C ON I.supply_company = C.company_id
                           							   JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
                           							   LEFT JOIN TBL_COMMON_CODE CD2 ON CD2.code = I.import_inspection
                           							   LEFT JOIN (select sum(in_rqty)-sum(in_cqty) rqty ,prod_id,item_id
                           							   	          from TBL_INBOUND
                           							   	          group by item_id,prod_id) B ON B.prod_id = PD.prod_id and B.item_id = PD.item_id
                          where purchase_state = 'PUR01' and due_date >=@from and due_date<= @to";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    list = Helper.DataReaderMapToList<InboundVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetPurchasesList() 오류", err);
                    return null;
                }
            }
        }

        public bool InboundCommit(List<int> selectedRows)
        {
            string sql = @"SP_INBOUND_COMMIT";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@up_emp", 1);
                    cmd.Parameters.AddWithValue("@up_date", DateTime.Now);
                    cmd.Parameters.Add("@in_id", SqlDbType.Int);

                    foreach (int item in selectedRows)
                    {
                        cmd.Parameters["@in_id"].Value = item;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_InboundCommit() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }

        public List<InboundVO> GetWaitDetail(int pdID)
        {
            List<InboundVO> list = new List<InboundVO>();
            string sql = @"select in_id,purchase_id,cast(PD.ins_date as date) PurchasesDate,B.prod_id,pd_id,company_name,B.item_id,item_name,CD.name unit,CD2.name UseCheck,pd_qty,sum(B.in_rqty) RQty,due_date
from TBL_INBOUND B JOIN TBL_ITEM I ON I.item_id = B.item_id
				   JOIN TBL_PURCHASE_DETAIL PD ON PD.prod_id = B.prod_id and PD.item_id = B.item_id
				   JOIN TBL_COMPANY C ON C.company_id = I.supply_company
				   JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
				   JOIN TBL_COMMON_CODE CD2 ON CD2.code = I.import_inspection
where pd_id = @pd_id
group by in_id,PD.purchase_id,PD.ins_date,B.prod_id,PD.pd_id,C.company_name,B.item_id,I.item_name,CD.name,CD2.name,PD.pd_qty,PD.due_date
";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@pd_id", pdID);
                    list = Helper.DataReaderMapToList<InboundVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetWaitDetail() 오류", err);
                    return null;
                }
            }
        }

        public List<InboundVO> GetWaitList(DateTime from, DateTime to)
        {
            List<InboundVO> list = new List<InboundVO>();
            string sql = @"select purchase_id,pd_id,cast(PD.ins_date as date) PurchasesDate,PD.prod_id,item_unit,company_name,PD.item_id,item_name,CD.name unit,CD2.name UseCheck,pd_qty,isnull(rqty,0) InQty,
                           pd_qty-isnull(rqty,0) RQty, due_date
                           from TBL_PURCHASE_DETAIL PD JOIN TBL_ITEM I ON PD.item_id = I.item_id
                           							   JOIN TBL_COMPANY C ON I.supply_company = C.company_id
                           							   JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
                           							   LEFT JOIN TBL_COMMON_CODE CD2 ON CD2.code = I.import_inspection
                           							   LEFT JOIN (select sum(in_rqty) rqty ,prod_id,item_id
                           							   	          from TBL_INBOUND
																  where in_state !=0
                           							   	          group by item_id,prod_id) B ON B.prod_id = PD.prod_id and B.item_id = PD.item_id
													   JOIN TBL_INBOUND B2 ON B2.prod_id = PD.prod_id and B2.item_id = PD.item_id and B2.in_state = 0
                          where purchase_state = 'PUR01'  and due_date >=@from and due_date<= @to";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    list = Helper.DataReaderMapToList<InboundVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetWaitList() 오류", err);
                    return null;
                }
            }
        }

        public List<CodeVO> GetAllCodes()
        {
            List<CodeVO> list = new List<CodeVO>();
            string sql = @"select * from VW_INBOUNDCODE";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    list = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_GetAllCodes() 오류", err);
                    return null;
                }
            }
        }

        public bool NewInbound(List<InboundVO> selectedRows)
        {
            string sql = @"insert into TBL_INBOUND(prod_id, in_state, item_id, in_qty,in_rqty, wh_id, ins_emp)
				                             values(@prod_id, @in_state, @item_id, @in_qty,@in_rqty, @wh_id, @ins_emp)";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;

                    cmd.Parameters.AddWithValue("@ins_emp", 1);

                    cmd.Parameters.Add("@prod_id", SqlDbType.Int);
                    cmd.Parameters.Add("@in_state", SqlDbType.Bit);
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@in_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@in_rqty", SqlDbType.Int);
                    cmd.Parameters.Add("@wh_id", SqlDbType.Int);

                    foreach (InboundVO item in selectedRows)
                    {
                        cmd.Parameters["@prod_id"].Value =  item.prod_id;
                        cmd.Parameters["@in_state"].Value =  false;
                        cmd.Parameters["@item_id"].Value =  item.item_id;
                        cmd.Parameters["@in_qty"].Value =   item.InQty;
                        cmd.Parameters["@in_rqty"].Value =   item.InQty;
                        cmd.Parameters["@wh_id"].Value = item.warehouse_id;
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_InboundDAC_NewInbound() 오류", err);
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}
