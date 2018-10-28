

namespace Rave.Utils
{
    public static class Connection
    {
        private static string database = "Rave";
        private static string salt = "RAVE";

        public static string Name { get
            {
                return "Production";
            }
           
        }

        public static string GetCnn(string AppName)
        {
            string hostname = "SQL-01";
            string port = "1433";
            string username = "RaveUsr";
            string password = "$.HN)e3eq^*&8M$z";

            return "Data Source="+hostname + ","+ port + ";Initial Catalog="+ database + "; User ID="+ username + "; Password="+ password + "";
        }

        public static string GetCnnWithCredentialsMaster(string hostname, string port, string username, string password)
        {
            string cnn = "Data Source=[[hostname]],[[port]];Initial Catalog=Master; User ID=[[username]]; Password=[[password]]";
            cnn = cnn.Replace("[[hostname]]", hostname).Replace("[[port]]", port).Replace("[[username]]", username).Replace("[[password]]", password);
            return cnn;
        }

        private static string GetCnnWithCredentials()
        {
            string cnn = "Data Source=[[hostname]],[[port]];Initial Catalog=Master; User ID=[[username]]; Password=[[password]]";
            cnn = cnn.Replace("[[hostname]]", WebUtils.GetAppSetting("hostname")).Replace("[[port]]", WebUtils.GetAppSetting("port")).Replace("[[username]]", Crypto.DecryptStringAES(WebUtils.GetAppSetting("hostname"), salt)).Replace("[[password]]", Crypto.DecryptStringAES(WebUtils.GetAppSetting("password"), salt));
            return cnn;
        }
    }
}
