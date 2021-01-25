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
    public class CodeDAC : CommonDAC
    {
        /// <summary>
        /// 공통코드를 불러오는 메서드
        /// </summary>
        /// <param name="categorys">불러올 카테고리명의 집합</param>
        /// <returns> Dictionary<[카테고리명],List<CodeVO>> </CodeVO> </returns>
        public Dictionary<string, List<CodeVO>> GetCommonCode(string[] categorys)
        {
            string sql = @"select code,name from TBL_COMMON_CODE where category = @category order by code";
            Dictionary<string, List<CodeVO>> codeList = new Dictionary<string, List<CodeVO>>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@category", SqlDbType.NVarChar);
                    foreach (string category in categorys)
                    {
                        cmd.Parameters["@category"].Value = category;
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<CodeVO> temp = Helper.DataReaderMapToList<CodeVO>(reader);
                        codeList.Add(category, temp);
                        reader.Close();
                    }
                    conn.Close();
                    return codeList;
                }
            }
            catch (Exception err)
            {
                Log.WriteError("코드 정보를 불러오는중 오류 발생" + err.Message);
                return null;
            }
        }
    }
}
