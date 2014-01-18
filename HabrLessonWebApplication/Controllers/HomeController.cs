using HabrLessonClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HabrLessonWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IUserRepository _userRepository;
        public ActionResult Index(string code)
        {
            var cc = code;
            //var users = _userRepository.GetUserById(0);
            return View();
        }

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    }
}
