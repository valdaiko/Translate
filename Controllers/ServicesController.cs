using System.Web.Mvc;

namespace Translate.Controllers
{
    public class ServicesController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["CurrentPage"] = "Services";
            return View();
        }
    }
}
