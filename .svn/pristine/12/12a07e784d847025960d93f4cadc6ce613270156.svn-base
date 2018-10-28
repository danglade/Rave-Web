using System;
using System.Data;
using System.Data.SqlClient;
using Env_Rave;

namespace WebApi
{

    static class DAL
    {
        private static string _appName = "Webapi-Rave";
        private static string _Cnn;
        private static string _Env;
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
        public static string AppName
        {
            get
            {
                return _appName;
            }

            set
            {
                _appName = value;
            }
        }
        private static void SetEnv()
        {
            if ((_Cnn != null))
                return;

            _Cnn = Env_Rave.Env_Rave.GetCnn(AppName);
        }
        private static DataSet _InitDS;
        public static DataSet InitDS
        {
            get
            {
                if ((_InitDS) == null)
                    return null;
                return _InitDS;
            }
        }
        public static DataTable Literals
        {
            get
            {
                if ((_InitDS) == null)
                    return null;
                return _InitDS.Tables[0];
            }
        }

        public static object GetLiteral(string name)
        {
            try
            {
                return Literals.Select("Name ='" + name + "'")[0]["Value"];
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static CmdResult TTT()
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[XBT_AgentInitialize]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmm);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    CmdResult result = new CmdResult(ds);
                    _InitDS = ds;

                    return result;
                }
            }
            catch (Exception ex)
            {                
                return new CmdResult(-1, ex.Message);
            }
        }

        public static CmdResult API_Login(string login, string password)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[API_Login]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    cmm.Parameters.Add("@login", SqlDbType.VarChar,20).Value = login;
                    cmm.Parameters.Add("@psw", SqlDbType.VarChar, 25).Value = password;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmm);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    CmdResult result = new CmdResult(ds);

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new CmdResult(-1, ex.Message);
            }
        }

        public static CmdResult X__(string login, string password)
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(Cnn))
                {
                    SqlCommand cmm = new SqlCommand("[dbo].[XBT_TickerSave1DData]", objConn);
                    cmm.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmm.Parameters.Add("@symbol", SqlDbType.VarChar, 50).Value = symbol;
                    //cmm.Parameters.Add("@response", SqlDbType.Xml).Value = Utils.GetTblXML(tbl, "", new string[] { });
                    SqlDataAdapter adapter = new SqlDataAdapter(cmm);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    CmdResult result = new CmdResult(ds);

                    return result;
                }
            }
            catch (Exception ex)
            {
                //EndPointLog("XBTSave1DData: " + "Symbol: " + symbol + " " + ex.Message, -1);
                return new CmdResult(-1, ex.Message);
            }
        }
       


    }
}
