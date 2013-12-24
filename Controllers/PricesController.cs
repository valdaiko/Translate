using System.Web.Mvc;

namespace Translate.Controllers
{
    public class PricesController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["CurrentPage"] = "Prices";
            return View();
        }
    }
}
