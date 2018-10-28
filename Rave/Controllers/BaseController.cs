using System.Web.Mvc;

namespace Rave.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = HttpContext.Request;            
            string controller = request.RequestContext.RouteData.Values["controller"].ToString();
            string action = request.RequestContext.RouteData.Values["action"].ToString();   
            
            if (controller == "Login")
            {
                return;
            }
           

            bool isValidUsr = Usr.IsValid();
            if (!isValidUsr)
            {
                filterContext.Result = new RedirectResult("/Login");
                return;
            }

        }

    }
}