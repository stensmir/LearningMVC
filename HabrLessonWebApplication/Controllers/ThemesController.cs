using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HabrLessonWebApplication.Controllers
{
    public class ThemesController : Controller
    {
        //
        // GET: /Themes/

        public ActionResult Index()
        {
            if (this.Session["CurrentUser"] != null)
            {
                return View(this.Session["CurrentUser"]);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
