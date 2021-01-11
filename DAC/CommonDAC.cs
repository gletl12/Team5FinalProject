using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;
namespace DAC
{
    public class CommonDAC : ConnectionAccess, IDisposable
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        string strConn;
        protected SqlConnection conn;

        public CommonDAC()
        {
            strConn = this.ConnectionString;
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }
    }
}
