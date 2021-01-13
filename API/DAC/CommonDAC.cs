using EncrytLibrary;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Util;

namespace API.DAC
{
    public class CommonDAC : ConnectionAccess, IDisposable
    {
        private static LoggingUtility _log = new LoggingUtility("MyProject", Level.Error, 30);
        public static LoggingUtility Log { get { return _log; } }

        /// <summary>
        /// ConnectionString
        /// </summary>
        string strConn;
        protected SqlConnection conn;

        public CommonDAC()
        {
            AES enc = new AES();
            strConn = enc.AESDecrypt256(this.ConnectionString);
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