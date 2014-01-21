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

        [HttpGet]
        public ActionResult Index()
        {
            var user = new HabrLessonClassLibrary.Domain.User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(HabrLessonClassLibrary.Domain.User user)
        {
            var xx = user;
            return View();
        }



        [HttpPost]
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return null;
        }

    }
}
