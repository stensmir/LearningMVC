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
            routes.MapRoute(null, "Home/Error", new { controller = "Home", Action = "Error" });


            routes.MapRoute(null, "Google", new { controller = "Google", Action = "SignUp" });
            routes.MapRoute(null, "Google/SignIn", new { controller = "Google", Action = "SignIn" });

            routes.MapRoute(null, "SignUp", new { controller = "SignUp", Action = "SignUp" });
            routes.MapRoute(null, "SignUp/SignUp", new { controller = "SignUp", Action = "SignUp" });

            routes.MapRoute(null, "Themes", new { controller = "Themes", Action = "Index" });

            routes.MapRoute(null, "Login", new { controller = "Login", Action = "Index" });
            routes.MapRoute(null, "Login/Index", new { controller = "Login", Action = "Index" });


            


            routes.MapRoute(null, "User/Index", new { controller = "User", Action = "Index" });
            routes.MapRoute(null, "User/SignIn", new { controller = "User", Action = "SignIn" });
            routes.MapRoute(null, "User/LogIn", new { controller = "User", Action = "LogIn" });

        }
    }
}