using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http;


namespace Rave_API.Controllers
{
    public class HomeController : ApiController
    {

        public CmdResult Index([FromBody] JObject data)
        {
            try
            {
                if (data == null)
                {
                    throw new System.Exception();
                }

                return DAL.HomeInitialize(data);
            }
            catch (System.Exception e)
            {
                return new CmdResult(-1, e.Message);
            }
        }

        
    }
}