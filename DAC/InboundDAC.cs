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
        public List<InboundVO> GetPurchasesList()
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
                           where purchase_state = 'PUR01'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
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

        public bool NewInbound(List<InboundVO> selectedRows)
        {
            string sql = @"insert into TBL_INBOUND(prod_id, in_type, item_id, in_qty,in_rqty, wh_id, ins_emp)
				                             values(@prod_id, @in_type, @item_id, @in_qty,@in_rqty, @wh_id, @ins_emp)";
            SqlTransaction trans = conn.BeginTransaction();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Transaction = trans;

                    cmd.Parameters.AddWithValue("@ins_emp", 1);

                    cmd.Parameters.Add("@prod_id", SqlDbType.Int);
                    cmd.Parameters.Add("@in_type", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@item_id", SqlDbType.Int);
                    cmd.Parameters.Add("@in_qty", SqlDbType.Int);
                    cmd.Parameters.Add("@in_rqty", SqlDbType.Int);
                    cmd.Parameters.Add("@wh_id", SqlDbType.Int);

                    foreach (InboundVO item in selectedRows)
                    {
                        cmd.Parameters["@prod_id"].Value =  item.prod_id;
                        cmd.Parameters["@in_type"].Value =  "IN001";
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
