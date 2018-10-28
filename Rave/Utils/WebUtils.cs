using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Rave.Utils
{

    public static class WebUtils
    {
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

        public static void ChangeMapTypeToSerialize(DataTable tbl)
        {
            foreach (DataColumn col in tbl.Columns)
            {
                col.ColumnMapping = MappingType.Element;
                col.ColumnName = col.ColumnName.ToLower();
                if (col.DataType == typeof(DateTime))
                    col.DateTimeMode = DataSetDateTime.Unspecified;
            }
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

        public static DataTable GetTblFromRequest(HttpRequestBase request)
        {
            DataTable dt = new DataTable();
            DataRow rw = dt.NewRow();

            foreach (string key in request.Form)
            {
                if (key.Contains("chk_"))
                {
                    dt.Columns.Add(key, typeof(bool));
                    rw[key] = bool.Parse(request[key].Split(',')[0].ToString());
                    continue;
                }

                dt.Columns.Add(key, typeof(string));
                rw[key] = request[key];
            }

            dt.Rows.Add(rw);
            return dt;
        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public static string GetAppSetting(string key)
        {
            try
            {
                var configFile = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    return "";
                }
                else
                {
                    return settings[key].Value;
                }

            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }

}