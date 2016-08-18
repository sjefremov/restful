using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/actions")]
    public class ActionsController : ApiController
    {
        [Route("testvoid")]
        public void GetTestVoid()
        {

        }

        [Route("teststring")]
        public string GetTestString()
        {
            return "test-string";
        }

        [Route("testint")]
        public int GetTestInt()
        {
            return 1;
        }
        [Route("response")]
        public HttpResponseMessage GetResponse()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotFound);
            return response;
        }

        [Route("actionresult")]
        public IHttpActionResult GetResult()
        {
            return NotFound();
        }

        [Route("integer/{id:int}")]
        [HttpGet]
        public IHttpActionResult ReturnInteger(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
