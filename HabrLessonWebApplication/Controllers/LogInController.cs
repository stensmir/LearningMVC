using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HabrLessonClassLibrary.Domain;
using HabrLessonClassLibrary.Repository;

namespace HabrLessonWebApplication.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/
        private IUserRepository _userRepository;
        public LogInController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var domainUser = new User();
            return View(domainUser);
        }

        [HttpPost]
        public ActionResult Index(User domainUser)
        {
            var currentUser = _userRepository.GetUserIdByEmailAndPassword(domainUser.Email, domainUser.Password);
            if (currentUser != null)
            {
                this.Session["CurrentUser"] = currentUser;
                return RedirectToAction("Index", "Themes");
            }
            else
            {
                return View(new User());
            }
        }

    }
}
