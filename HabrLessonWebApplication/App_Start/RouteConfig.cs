using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HabrLessonWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(null, "", new { controller = "Home", Action = "Index" });
            routes.MapRoute(null, "Google", new { controller = "Google", Action = "Index" });
            routes.MapRoute(null, "Google/SignIn", new { controller = "Google", Action = "SignIn" });
        }
    }
}