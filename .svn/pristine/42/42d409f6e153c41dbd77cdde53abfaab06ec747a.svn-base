using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;

namespace WebApi
{
    public static class Utils
    {
        public static string JsonToXMl(string data)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode("{\"tbl\":" + data + "}", "DocumentElement");
            return doc.InnerXml;
        }

        public static DataSet ConvertXMLToDatase(XmlDocument doc)
        {
            StringReader sr = new StringReader(doc.InnerXml);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            return ds;
        }

        public static string GetTblXML(DataTable dt, string filter, string[] cols)
        {
            DataView view = new DataView(dt);
            view.RowFilter = filter;
            DataTable tbl = view.ToTable("tbl", true, cols);
            ChangeMapTypeToSerialize(tbl);
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            tbl.WriteXml(stream);
            return GetString(stream);
        }        

        public static void ChangeMapTypeToSerialize(DataTable tbl)
        {
            foreach (DataColumn col in tbl.Columns)
                col.ColumnMapping = MappingType.Element;
        }

        public static string GetString(System.IO.MemoryStream ms)
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(ms))
            {
                ms.Position = 0;
                string Result = sr.ReadToEnd();
                sr.Close();
                return Result;
            }
        }
    }
}
