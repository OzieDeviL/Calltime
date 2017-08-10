using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calltime.Web.Controllers
{
    [RoutePrefix("production")]
    public class ProductionController : Controller
    {
        // GET: Production
        [Route]
        public ActionResult Index()
        {
            return View();
        }
    }
}