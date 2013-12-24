using System.Web.Mvc;

namespace Translate.Controllers
{
    public class AboutController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["CurrentPage"] = "About";
            return View();
        }
    }
}
