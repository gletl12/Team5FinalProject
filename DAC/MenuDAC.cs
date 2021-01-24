using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAC
{
    public class MenuDAC : CommonDAC
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

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return new List<MenuVO>();
            }


        }

        /// <summary>
        /// 메뉴 삭제
        /// </summary>
        /// <param name="menuName">삭제할 메뉴 이름</param>
        /// <returns></returns>
        public bool DeleteMenu(string menuName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SP_DeleteMenu";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MenuName",menuName);
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);


                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Connection = conn;

                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    trans.Commit();
                    Dispose();


                    return Convert.ToInt32(cmd.Parameters["@return"].Value) == 0 ? true : false;

                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }

        }

        /// <summary>
        /// 소메뉴 추가
        /// </summary>
        /// <param name="menuName">추가할 메뉴명</param>
        /// <param name="parentName">부모메뉴명</param>
        /// <returns></returns>
        public bool AddSmallMenu(string menuName, string parentName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SP_AddSmallMenu";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    cmd.Parameters.AddWithValue("@ParentName", parentName);
                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Connection = conn;

                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    trans.Commit();
                    Dispose();


                    return Convert.ToInt32(cmd.Parameters["@return"].Value) > 0 ? false : true;


                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }
        }

        /// <summary>
        /// 대메뉴 추가
        /// </summary>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public bool AddLargeMenu(string menuName)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SP_AddLargeMenu";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    cmd.Parameters.Add("@return", System.Data.SqlDbType.Int);
                    cmd.Parameters["@return"].Direction = System.Data.ParameterDirection.ReturnValue;

                    cmd.Connection = conn;

                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    Dispose();

                    return Convert.ToInt32(cmd.Parameters["@return"].Value) > 0 ? false : true;
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Dispose();

                //로그 오류
                Log.WriteError("DAC_MenuDAC_GetMenus() 오류", err);

                return false;
            }

        }
    }
}
