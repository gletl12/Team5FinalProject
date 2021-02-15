using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class CompanyDAC : CommonDAC
    {
        public List<CompanyVO> GetCompany()
        {
            try
            {
                string sql = @"select company_id, company_name, o.name as company_type, company_ceo, company_bnum, d.name as company_btype, m.emp_name as company_manager,
                                      company_email, company_phone, company_faxnum, e.name as company_use, company_comment, c.up_date, c.up_emp
                               from TBL_COMPANY c join TBL_COMMON_CODE o on c.company_type = o.code
												  join TBL_COMMON_CODE d on c.company_btype = d.code
												  join TBL_COMMON_CODE e on c.company_use = e.code
												  join TBL_Employee m on c.company_manager = m.emp_id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(cmd.ExecuteReader());
                    Dispose();

                    return list;
                }
            }
            catch (Exception err)
            {
                Dispose();

                //로그 오류
                Log.WriteError("CompanyDAC_GetCompany() 오류", err);

                return new List<CompanyVO>();
            }
        }
    }
}
