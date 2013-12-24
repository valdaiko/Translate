using System.Web.Mvc;

namespace Translate.Controllers
{
    public class ContactsController : BaseController
    {
        public new ActionResult Index()
        {
            ViewData["CurrentPage"] = "Contacts";
            return View();
        }

    }
}
