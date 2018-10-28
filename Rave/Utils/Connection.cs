

namespace Rave.Utils
{
    public static class Connection
    {
        private static string database = "DBANow";
        private static string salt = "DBA";

        public static string Name { get
            {
                return "Production";
            }
           
        }

        public static string GetCnn(string AppName)
        {
            string hostname = WebUtils.GetAppSetting("hostname");
            string port = WebUtils.GetAppSetting("port");
            string username = Crypto.DecryptStringAES( WebUtils.GetAppSetting("username"), salt);
            string password = Crypto.DecryptStringAES(WebUtils.GetAppSetting("password"), salt);

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
