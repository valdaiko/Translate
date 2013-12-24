using System;
using System.IO;
using System.Web.Mvc;

namespace Translate.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.Url == null || Request.Url.ToString().Contains("localhost"))
            {
                return;
            }
            else
            {
                using (TextWriter writer = new StreamWriter(Server.MapPath("~/log/log.txt"), true))
                {
                    writer.WriteLine("{0} - {1} - {2} - {3}", DateTime.Now.ToString("HH:mm:ss dd.MM"), Request.UserHostAddress, Request.Url, Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "");
                }
               
            }             
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // ... log stuff after execution
        }

    }
}
