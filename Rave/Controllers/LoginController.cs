using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rave.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View("ForgetPassword");
        }

        public ActionResult Submit()
        {
            try
            {
                ViewBag.user = Request["txtUserName"];
                CmdResult result;

                if (ModelState.IsValid)
                {
                    if (string.IsNullOrWhiteSpace(Request["txtUserName"]) || string.IsNullOrWhiteSpace(Request["txtPassword"]))
                    {
                        result = new CmdResult(-1, "Empty username or password");
                        return View("Index", result);
                    }

                    result = DAL.Initialize(Request["txtUserName"], Request["txtPassword"]);

                    if (result.Code < 0)
                    {
                        return View("Index", result);
                    }

                    HttpContext.Session.Add("UsrDs", result.DS);
                    
                    return RedirectToAction("Index", "Home");
                }

                result = new CmdResult(-1, "Something happened.");
                return View("Index", result);
            }
            catch (System.Exception ex)
            {
                CmdResult result = new CmdResult(-1, ex.Message);
                return View("Index", result);
            }

        }


    }
}