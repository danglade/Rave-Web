using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        void RegisterRoutes(RouteCollection routes)
        {

            routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);




            //routes.MapPageRoute("SalesDetailRoute",
            //    "SalesReportDetail/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            //    false);

            //routes.MapPageRoute("SalesCurrentYearRoute",
            //    "SalesReportCurrent/{locale}/{year}/{*queryvalues}", "~/sales.aspx",
            //    false,
            //    new RouteValueDictionary
            //        { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } });

            //routes.MapPageRoute("ExpenseCurrentYearRoute",
            //    "ExpenseReportCurrent/{locale}", "~/expenses.aspx",
            //    false,
            //    new RouteValueDictionary
            //        { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } },
            //    new RouteValueDictionary
            //        { { "locale", "[a-z]{2}" }, { "year", @"\d{4}" } });

            //routes.MapPageRoute("ExpenseDetailRoute",
            //    "ExpenseReportDetail/{locale}/{year}/{*queryvalues}", "~/expenses.aspx",
            //    false,
            //    new RouteValueDictionary
            //        { { "locale", "US" }, { "year", DateTime.Now.Year.ToString() } },
            //    new RouteValueDictionary
            //        { { "locale", "[a-z]{2}" }, { "year", @"\d{4}" } },
            //    new RouteValueDictionary
            //        { { "account", "1234" }, { "subaccount", "5678" } });
        }

    }
}