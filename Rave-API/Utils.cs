using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Rave_API
{
    public static class Utils
    {
        public static string ConvertJsonToXml(JObject data)
        {
            try
            {
                XDocument doc = JsonConvert.DeserializeXNode(data.ToString(), "tbl");
                XDocument yourResult = new XDocument(new XElement("DocumentElement", doc.Root));

                return yourResult.ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}