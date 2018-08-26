using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class ValuesMrRobotController : ApiController
    {

        Consumer consumer = new Consumer();

        [Route("api/user/get-users-pass")]
        [HttpGet]

        public IHttpActionResult Get()
        {
            DataBaseMrRobotConn dbConn = new DataBaseMrRobotConn();
            //DataBaseConn dbConn = new DataBaseConn();
            return Ok(dbConn.getData());// need to do: try and catch
        }
        /*// GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        
        [Route("api/user/get-users-pass/{id:int}")]
        [HttpGet]

        public IHttpActionResult Get(int id)
        {
            DataBaseMrRobotConn dbConn = new DataBaseMrRobotConn();
            
            return Ok(dbConn.getCount());// need to do: try and catch
        }

        [Route("api/user/get-user-id/{name}")]
        [HttpGet]

        public IHttpActionResult Get(String name)
        {
            DataBaseMrRobotConn dbConn = new DataBaseMrRobotConn();

            return Ok(dbConn.getID(name));// need to do: try and catch
        }
        // GET api/<controller>/5
        /*
        public string Get(int id)
        {
            return "value";
        }
        */
        [Route("api/user/set-users-pass/{name}/{id:int}")]
        [HttpPost]

        public IHttpActionResult Post([FromUri]String name, [FromUri()] int id)
        {
            DataBaseMrRobotConn dbConn = new DataBaseMrRobotConn();
            return Ok(dbConn.setData(name, id));
        }
        // POST api/<controller>
        /*
        public void Post([FromBody]string value)
        {
        }
        */
        /*
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }
        */
    


        /*
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        */
        [Route("api/user/delete-user-pass/{id:int}")]
        [HttpDelete]

        public IHttpActionResult Delete(int id)
        {
            DataBaseMrRobotConn dbConn = new DataBaseMrRobotConn();

            return Ok(dbConn.deleteData(id));// need to do: try and catch
        }
    }
}