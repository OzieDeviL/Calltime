using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Calltime.Web.Models;
using Calltime.Web.Models.Requests;
using Calltime.Web.Models.Responses;
using Calltime.Web.Services;
using Calltime.Web.Classes;

namespace Calltime.Web.Controllers.Api
{
    [RoutePrefix("api/people")]
    public class PeopleApiController : ApiController
    {
        [Route]
        [HttpPost]
        public HttpResponseMessage Create()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "You maid it work");
        }
    }
}
