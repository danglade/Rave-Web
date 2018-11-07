using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Rave_API
{
    public static class DAL
    {
        public const string AppName = "Rave REST API";
        private static string _Cnn;
        private static string _Env;


        private static void SetEnv()
        {
            _Cnn = "Server=SQL-01;Database=Rave;User Id=RaveUsr; Password = $.HN)e3eq^*&8M$z; ";
            _Env = "";
        }

        public static string Env
        {
            get
            {
                SetEnv();
                return _Env;
            }
        }

        public static string Cnn
        {
            get
            {
                SetEnv();
                return _Cnn;
            }
        }


        public static CmdResult HomeInitialize(JObject data)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[Get_HomeController]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.Parameters.Add("@data", SqlDbType.Xml).Value = Utils.ConvertJsonToXml(data);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmm);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return new CmdResult(ds);
                }
            }
            catch (Exception ex)
            {
                return new CmdResult(-1, ex.Message);
            }
        }

        public static string GetTblXML(DataTable dt, string filter, string[] cols)
        {
            DataView view = new DataView(dt);
            view.RowFilter = filter;
            DataTable tbl = view.ToTable("tbl", true, cols);
            ChangeMapTypeToSerialize(tbl);
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            tbl.WriteXml(stream);
            return GetMemoryStream(stream);
        }

        public static string GetMemoryStream(System.IO.MemoryStream ms)
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(ms))
            {
                ms.Position = 0;
                string Result = sr.ReadToEnd();
                sr.Close();
                return Result;
            }
        }


        public static void ChangeMapTypeToSerialize(DataTable tbl)
        {
            foreach (DataColumn col in tbl.Columns)
            {
                col.ColumnMapping = MappingType.Element;
                if (col.DataType == typeof(DateTime))
                    col.DateTimeMode = DataSetDateTime.Unspecified;
            }
        }

        public static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }


        public static string[] GetTblColNamesAsStringArray(DataTable tbl, bool toLower = false)
        {
            string[] cols = new string[tbl.Columns.Count - 1 + 1];
            for (int i = 0; i <= tbl.Columns.Count - 1; i++)
            {
                if (toLower)
                    cols[i] = tbl.Columns[i].ColumnName.ToLower();
                else
                    cols[i] = tbl.Columns[i].ColumnName;
            }
            return cols;
        }
    }
}