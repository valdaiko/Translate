using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Translate.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();
            else
                return View(id);
        }

    }
}
