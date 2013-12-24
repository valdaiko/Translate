using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Translate
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Articles", // Route name
                "articles/{id}", // URL with parameters
                new { controller = "Articles", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }



        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            string hostName = Request.Headers["x-forwarded-host"];
            hostName = string.IsNullOrEmpty(hostName) ? Request.Url.Host : hostName;
            if (!hostName.Contains("www.ulrespect.ru") && !hostName.Contains("localhost"))
            {
                var builder = new UriBuilder(Request.Url)
                {
                    Host = "www.ulrespect.ru",
                    Port = 80
                };

                string redirectUrl = builder.Uri.ToString().Trim('/');
               // Response.RedirectPermanent(redirectUrl);
            }
        }

    }
}