using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class StoreController : ApiController
    {

        [Route("api/user/add-item/{id:int}/{name}/{cost:int}/{description}")]
        [HttpPost]

        public IHttpActionResult Post([FromUri]int id, [FromUri()] string name, [FromUri()] int cost, [FromUri()] string description)
        {
            Store dbConn = new Store();
            return Ok(dbConn.setItem(id, name, cost, description));
        }

        [Route("api/user/add-item/{id:int}/{name}/{cost:int}")]
        [HttpPost]

        public IHttpActionResult Post2([FromUri]int id, [FromUri()] string name, [FromUri()] int cost)
        {
            Store dbConn = new Store();
            return Ok(dbConn.setItem(id, name, cost, ""));
        }

        [Route("api/user/update-item/{param:int}/{id:int}/{name}/{cost:int}/{desc}")]
        [HttpPut]

        public IHttpActionResult Put([FromUri]int param, [FromUri]int id, [FromUri()] string name, [FromUri()] int cost, [FromUri()] string desc)
        {
            Store dbConn = new Store();
            return Ok(dbConn.updateItem(param, id, name, cost, desc));
        }

        [Route("api/user/update-item/{param:int}/{id:int}/{name}/{cost:int}")]
        [HttpPut]

        public IHttpActionResult Put([FromUri]int param, [FromUri]int id, [FromUri()] string name, [FromUri()] int cost)
        {
            Store dbConn = new Store();
            return Ok(dbConn.updateItem(param, id, name, cost, ""));
        }

        [Route("api/user/delete-store/{id:int}")]
        [HttpDelete]

        public IHttpActionResult Delete([FromUri]int id)
        {
            Store dbConn = new Store();
            return Ok(dbConn.deleteItem(id));
        }
    }
}
