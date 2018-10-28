using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi
{
    public class AuthenticateController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string user, string password)
        {
            return user + " " + password;
        }

        // POST api/<controller>
        public System.Data.DataSet Post([FromBody]JToken model)
        {
            CmdResult result = DAL.API_Login(model.Value<string>("login"), model.Value<string>("password"));
            return result.DS;
        }

        // PUT api/<controller>/5  
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}