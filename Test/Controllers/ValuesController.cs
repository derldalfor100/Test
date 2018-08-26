using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class ValuesController : ApiController
    {

        [Route("api/user/get-users")]
        [HttpGet]

        public IHttpActionResult Get()
        {
            DataBaseConn dbConn = new DataBaseConn();
            return Ok(dbConn.getData());// need to do: try and catch
        }
        // GET api/values
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };   
        }*/

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
