using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class CheckDAC : CommonDAC
    {
        public List<CodeVO> GetCompanyList()
        {
            string sql = @"select company_name name, company_id code 
                            from TBL_CHECK_HISTORY CH JOIN TBL_ITEM I ON CH.item_id = I.item_id 
						                              JOIN TBL_COMPANY C ON C.company_id = I.supply_company";
            List<CodeVO> codes = new List<CodeVO>();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    codes = Helper.DataReaderMapToList<CodeVO>(cmd.ExecuteReader());
                    return codes;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_CheckDAC_GetCompanyList() 오류", err);
                    return null;
                }
            }

        }

        public List<CheckVO> GetCheckList(DateTime from, DateTime to)
        {
            string sql = @"select CH.ch_id,cast(CH.ins_date as date) ins_date,company_name,CH.item_id,I.item_name,CD.name unit,ch_qty,good_qty,bad_qty,bad_comment
from TBL_CHECK_HISTORY CH JOIN TBL_ITEM I ON CH.item_id = I.item_id
						  JOIN TBL_COMPANY C ON C.company_id = I.supply_company
						  LEFT JOIN TBL_BAD B ON CH.ch_id = B.ch_id
						  JOIN TBL_COMMON_CODE CD ON CD.code = I.item_unit
where CH.ins_date>=@from and CH.ins_date<=@to";
            List<CheckVO> list = new List<CheckVO>();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    list = Helper.DataReaderMapToList<CheckVO>(cmd.ExecuteReader());
                    return list;
                }
                catch (Exception err)
                {
                    Log.WriteError("DAC_CheckDAC_GetCheckList() 오류", err);
                    return null;
                }
            }

        }
    }
}
