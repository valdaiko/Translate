using System.Web.Mvc;

namespace Translate.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }

}
