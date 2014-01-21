using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HabrLessonClassLibrary;

namespace HabrLessonWebApplication.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            var user = new HabrLessonClassLibrary.Domain.User();
            return View(user);
        }

        public ActionResult SignUp()
        {
            return null;
        }

        public ActionResult LogIn()
        {
            return null;
        }

    }
}
