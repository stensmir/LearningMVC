using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HabrLessonClassLibrary;

namespace HabrLessonWebApplication.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public Domain.User CurrentUser { get; set; }

        public ActionResult Index()
        {
            return View();
        }

    }
}
