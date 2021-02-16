using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Mvc.DAC
{
    public class OrderDAC : IDisposable
    {
        SqlConnection conn;

        #region 생성
        public OrderDAC()
        {
            string strConn = WebConfigurationManager.ConnectionStrings["MyChart"].ConnectionString;
            conn = new SqlConnection(strConn);
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }

        #endregion

        //----------------------------------------------

        public List<OrderStats> GetOrderBestProduct()
        {
            string sql = @"select sum(Quantity) Qty, Month(OrderDate) MM, ProductName
from orders o inner join [Order Details] od on o.OrderID = od.OrderID
				inner join Products p on od.ProductID = p.ProductID
where orderdate between '1997-01-01' and '1997-12-31'
   and od.ProductID in (56,59,60)
group by Month(OrderDate), od.ProductID, ProductName";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                List<OrderStats> list = Helper.DataReaderMapToList<OrderStats>(cmd.ExecuteReader());
                conn.Close();

                return list;
            }
        }
    }
}