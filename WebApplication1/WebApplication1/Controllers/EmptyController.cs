using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/empty")]
    public class EmptyController : ApiController
    {
        // GET: api/HelloWorld
        //[HttpGet]
        [Route("hello")]
        public string GetHelloWorld()
        {
            return "Hello world";
        }

        [Route("buy")]
        public string GetGoodByeWorld()
        {
            return "Good Bye World";
        }

        [Route("echo/{number}")]
        public int GetEcho(int number)
        {
            return number;
        }

        [Route("sum/{number}/{number2}")]
        public int GetSum(int number, int number2)
        {
            return number + number2;
        }
    }
}
