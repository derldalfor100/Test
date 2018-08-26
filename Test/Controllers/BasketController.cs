using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class BasketController : ApiController
    {
        [Route("api/user/get-store/")]
        [HttpGet]

        public IHttpActionResult Get()// get the store table
        {
            BasketConn dbConn = new BasketConn();

            return Ok(dbConn.getStore());// need to do: try and catch
        }


        [Route("api/user/get-basket/{id:int}")]
        [HttpGet]

        public IHttpActionResult Get(int id)// get the basket table of the user with id
        {
            BasketConn dbConn = new BasketConn();

            return Ok(dbConn.getItems(id));// need to do: try and catch
        }

        [Route("api/user/get-exist/{item:int}/{user:int}")]
        [HttpGet]

        public IHttpActionResult GetItemExistance(int item, int user)// get the basket table of the true of false, depending on existance of itemId
        {
            BasketConn dbConn = new BasketConn();

            return Ok(dbConn.getExist(item, user));// need to do: try and catch
        }

        [Route("api/user/set-item/{item:int}/{user:int}/{amount:int}")]
        [HttpPost]

        public IHttpActionResult Post([FromUri]int item, [FromUri()] int user, [FromUri()] int amount)
        {
            BasketConn dbConn = new BasketConn();
            return Ok(dbConn.setItem(item, user, amount));
        }

        [Route("api/user/change-item/{item:int}/{user:int}/{amount:int}")]
        [HttpPut]

        public IHttpActionResult Put([FromUri]int item, [FromUri()] int user, [FromUri()] int amount)
        {
            BasketConn dbConn = new BasketConn();
            return Ok(dbConn.changeItemAmount(item, user, amount));
        }

        [Route("api/user/delete-item/{item:int}/{user:int}")]
        [HttpDelete]

        public IHttpActionResult Delete([FromUri]int item, [FromUri()] int user)
        {
            BasketConn dbConn = new BasketConn();
            return Ok(dbConn.deleteItem(item, user));
        }
    }
}
