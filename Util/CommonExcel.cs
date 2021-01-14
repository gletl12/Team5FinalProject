using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Util
{
    public static class CommonExcel
    {
        /// <summary>
        /// 엑셀파일 읽어 List<T>형식으로 반환
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheetName">시트 명</param>
        /// <returns></returns>
        public static List<T> ReadExcelData<T>(string sheetName)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls|Excel Files(*.xlsx)|*.xlsx|All Files(*,*)|*.*";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("파일선택을 하지 않았스빈다");
                return null;
            }

            string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
            string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

            string fileName = dlg.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string strConn = string.Empty;
           

            switch (fileExtension)
            {
                case ".xls":
                    strConn = string.Format(Excel03ConString, fileName, "Yes");
                    break;
                case ".xlsx":
                    strConn = string.Format(Excel07ConString, fileName, "Yes");
                    break;
            }
            List<T> result = new List<T>();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                string sql = "select * from [" + sheetName + "$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                result = Helper.DataReaderMapToList<T>(cmd.ExecuteReader());
            }

            return result;
        }

    }
}
