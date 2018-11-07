using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Rave_API.Controllers
{
    public class HomeController : ApiController
    {
        // GET: Home
        public string Index([FromBody] JObject data)
        {
            return "";
        }
    }
}