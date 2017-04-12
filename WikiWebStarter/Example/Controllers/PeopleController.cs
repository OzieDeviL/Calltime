using System.Web.Mvc;
using WikiWebStarter.Web.Controllers;

namespace WikiWebStarter.Example.Controllers
{
    public class PeopleController : BaseController
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }
    }
}