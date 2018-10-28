using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Rave
{
    public class Usr: IReadOnlySessionState        
    {
       
        public static DataRow User() 
        {
            DataSet ses = HttpContext.Current.Session["UsrDs"] as DataSet;
            return ses.Tables[0].Rows[0];
        }

        public static HttpSessionState USession()
        {
            return HttpContext.Current.Session;
        }

        public static DataRow UsrExt()
        {
            DataSet ses = HttpContext.Current.Session["UsrDs"] as DataSet;
            return ses.Tables[1].Rows[0];
        }

        public static DataTable Literals()
        {    
            DataSet ses = USession()["UsrDs"] as DataSet;
            return ses.Tables[2];
        }

        private static DataTable Functions()
        {
            DataSet ses = USession()["UsrDs"] as DataSet;
            return ses.Tables[3];
        } 

        public static bool isFunctionEnabled(string fn)
        {
            return Functions().Select("name'" + fn + "'").Count() > 0;
        }

        public static string GetLiterals(string key)
        {
            DataRow[] ls = Literals().Select("Name = '" + key + "'");
            if (ls.Count() == 0)
            {
                return "";
            }

            return ls[0]["Value"].ToString();
        }

        public static string GetUsrLbl(string lbl)
        {
            try
            {
                return UsrExt()[lbl].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static int UserId()
        {
            return (int)User()["user_id"];
        }

        public static bool IsValid()
        {
            try
            {
                return (DateTime)UsrExt()["expired_at"] > DateTime.Now;
            }
            catch (Exception)
            {
                return false;
            }
        }

       

      

    }
}