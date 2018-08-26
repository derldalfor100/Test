using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Models;

namespace Test.Controllers
{
    public class ProductsController : ApiController
    {
        List<Products> products = new List<Products>{
            new Products{Name = "Phone" , Price = 25, Quantity = 88},
            new Products{Name = "TV" , Price = 235, Quantity = 828 },
        };


        [Route("api/get-products"), HttpGet]
        public IEnumerable<Products> Get()
        {
            return products;
        }

        [Route("api/get-product/{name}"), HttpGet]
        public string Get(string name)
        {
            return name;
        }

        [Route("api/add-new-product"), HttpPost]// it's a post method
        public void PostAddNewProduct([FromBody]Products product)// wait for product when your enter: "api/add-new-product"
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
