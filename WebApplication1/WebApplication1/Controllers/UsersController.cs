using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Route("get/{id:int}")]
        public string GetByUserId(int id)
        {
            return "user with id: " + id;
        }

        [Route("get/{name}")]
        public string GetByUserName(string name)
        {
            return "user with name: " + name;
        }


    }
}
