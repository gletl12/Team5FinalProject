using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace Util
{
    public static class CommonExcel
    {
        /// <summary>
        /// 엑셀파일 읽어 List<T>형식으로 반환
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ReadExcelData<T>()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls|Excel Files(*.xlsx)|*.xlsx|All Files(*,*)|*.*";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("파일선택을 하지 않았습니다.");
                return null;
            }

            string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
            string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

            string fileName = dlg.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string strConn = string.Empty;
            string sheetName = string.Empty;

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
                // sheet명 가져오기
                conn.Open();
                DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                conn.Close();

                string sql = "select * from [" + sheetName + "]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                //OleDbDataReader reader = cmd.ExecuteReader();
                result = Helper.DataReaderMapToList<T>(cmd.ExecuteReader());
            }

            return result;
        }

        /// <summary>
        /// 엑셀파일 읽어 List<T>형식으로 반환, 파일경로 같이 반환
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static (List<T>,string) ReadExcelAndReturnPath<T>()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls|Excel Files(*.xlsx)|*.xlsx|All Files(*,*)|*.*";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("파일선택을 하지 않았습니다.");
                return (null,null);
            }

            string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
            string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

            string fileName = dlg.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string strConn = string.Empty;
            string sheetName = string.Empty;

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
                // sheet명 가져오기
                conn.Open();
                DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                conn.Close();

                string sql = "select * from [" + sheetName + "]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                //OleDbDataReader reader = cmd.ExecuteReader();
                result = Helper.DataReaderMapToList<T>(cmd.ExecuteReader());
            }

            return (result,fileName);
        }

        /// <summary>
        /// 엑셀파일 읽어 DataTable형식으로 반환
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheetName">시트 명</param>
        /// <returns></returns>
        public static (DataTable, string) ReadExcelData()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls|Excel Files(*.xlsx)|*.xlsx|All Files(*,*)|*.*";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("파일선택을 하지 않았습니다.");
                return (null, null);
            }


            string fileName = dlg.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string strConn = string.Empty;
            string sheetName = string.Empty;
            string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
            string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

            switch (fileExtension)
            {
                case ".xls":
                    strConn = string.Format(Excel03ConString, fileName, "Yes");
                    break;
                case ".xlsx":
                    strConn = string.Format(Excel07ConString, fileName, "Yes");
                    break;
            }
            try
            {
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();
                    DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                    conn.Close();

                    conn.Open();
                    string sql = "select * from [" + sheetName + "]";
                    OleDbDataAdapter oda = new OleDbDataAdapter(sql, conn);
                    //OleDbDataReader reader = cmd.ExecuteReader();
                    oda.Fill(dtSchema);
                    conn.Close();
                    return (dtSchema, fileName);
                }
            }
            catch (Exception)
            {
                return (new DataTable(), string.Empty);
            }

        }

        /// <summary>
        /// 엑셀 양식을 다운로드한다.
        /// </summary>
        /// <param name="FileName"></param>
        public static void ExportExcelData(string FileName)
        {

        }

        /// <summary>
        /// 엑셀 양식에 데이터를 추가해 출력한다.
        /// </summary>
        /// <param name="FileName"></param>
        public static void ExportExcelData<T>(string FileName, T Data)
        {
            //저장할 디렉토리 설정
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Files(*.xls)|*.xls";
            dlg.Title = "엑셀파일로 내보내기";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(0);



                xlWorkBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlWorkbookNormal);
                xlWorkBook.Close(true);
                xlApp.Quit();


                MessageBox.Show("Excel Export가 완료되었습니다.");
            }
        }
        /// <summary>
        /// 액셀익스포트
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList"></param>
        /// <param name="exceptColumns"></param>
        /// <returns></returns>
        public static string ExportToDataGridView<T>(List<T> dataList, string exceptColumns) //exceptColumns : 제외하고 싶은 컬럼
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Application.Workbooks.Add(true);

                int columnIndex = 0;

                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (!exceptColumns.Contains(prop.Name))
                    {
                        columnIndex++;
                        excel.Cells[1, columnIndex] = prop.Name;
                    }
                }

                int rowIndex = 0;

                foreach (T data in dataList)
                {
                    rowIndex++;
                    columnIndex = 0;
                    foreach (PropertyInfo prop in typeof(T).GetProperties())
                    {
                        if (!exceptColumns.Contains(prop.Name))
                        {
                            columnIndex++;
                            if (prop.GetValue(data, null) != null)
                            {
                                excel.Cells[rowIndex + 1, columnIndex] = prop.GetValue(data, null).ToString();
                            }
                        }
                    }
                }
                excel.Columns.AutoFit();
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                worksheet.Activate();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
