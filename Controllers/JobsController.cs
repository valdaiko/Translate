using System.Web.Mvc;

namespace Translate.Controllers
{
    public class JobsController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["CurrentPage"] = "Jobs";
            return View();
        }
    }
}
