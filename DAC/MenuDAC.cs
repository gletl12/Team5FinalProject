using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    class MenuDAC : CommonDAC
    {
       
        /// <summary>
        /// 모든 메뉴 불러오기
        /// </summary>
        /// <returns></returns>
        public List<MenuVO> GetMenus()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_GetMenu";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    List<MenuVO> temp = Helper.DataReaderMapToList<MenuVO>(cmd.ExecuteReader());
                    Dispose();

                    return temp;
                }
            }
            catch (Exception err)
            {
                Dispose();
                return new List<MenuVO>();
            }


        }


        public void Dispose()
        {
            conn.Close();
        }
    }
}
