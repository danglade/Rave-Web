using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Rave.Utils;

namespace Rave
{
    public static class DAL
    {
        public const string AppName = "DBA Tool 1.0";
        private static string _Cnn;
        private static string _Env;

        
        private static void SetEnv()
        {
            _Cnn = Connection.GetCnn(DAL.AppName);
            _Env = Connection.Name;
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

        public static CmdResult Initialize(string user, string password)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[Initialize]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.Parameters.Add("@login", SqlDbType.VarChar,50).Value = user;
                    cmm.Parameters.Add("@psw", SqlDbType.VarChar,25).Value = password;
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

        

        public static CmdResult Update_UserPassword(int user_id, string password)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[Update_UserPassword]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.Parameters.Add("@psw", SqlDbType.VarChar, 25).Value = password;
                    cmm.Parameters.Add("@user_id", SqlDbType.Int).Value = user_id;
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

        public static CmdResult User_Initialize(int user_id)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[User_Initialize]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.Parameters.Add("@user_id", SqlDbType.Int).Value = user_id;
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
       

        public static CmdResult Add_User(HttpRequestBase Request, int by_user_id, bool reset_password)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[Add_User]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.Parameters.Add("@response", SqlDbType.Xml).Value = WebUtils.GetTblXML(WebUtils.GetTblFromRequest(Request), "", new string[] { });
                    cmm.Parameters.Add("@by_user_id", SqlDbType.Int).Value = by_user_id;
                    cmm.Parameters.Add("@reset_password", SqlDbType.Bit).Value = reset_password;
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

      
        

        public static CmdResult AddRepoInfo(string hostname, string port, string username, string password)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[Add_RepoInfo]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.Parameters.Add("@hostname", SqlDbType.VarChar, 127).Value = hostname;
                    cmm.Parameters.Add("@port", SqlDbType.Int).Value = port;
                    cmm.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;
                    cmm.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = password;
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


    }
}