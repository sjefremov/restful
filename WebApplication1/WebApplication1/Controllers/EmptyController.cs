using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EmptyController : ApiController
    {
        // GET: api/HelloWorld
        //[HttpGet]
        //TODO redefine the routes in WebApiConfig.cs so the methods could be called
        public string GetHelloWorld()
        {
            return "Hello world";
        }
        
        public string GetGoodByeWorld()
        {
            return "Good Bye World";
        }
    }
}
