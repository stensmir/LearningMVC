using HabrLessonClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HabrLessonWebApplication.Controllers
{
    public class SignUpController : Controller
    {
        //
        // GET: /SignUp/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        private IUserRepository _userepository;
        public SignUpController(IUserRepository userRepository)
        {
            _userepository = userRepository;
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            var user = new HabrLessonClassLibrary.Domain.User();
            return View(user);
        }

        [HttpPost]
        public ActionResult SignUp(HabrLessonClassLibrary.Domain.User user)
        {
            _userepository.Save(user);
            //send email
            return View(user);
        }

    }
}
