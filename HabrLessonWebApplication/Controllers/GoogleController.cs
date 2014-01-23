using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HabrLessonClassLibrary.Services;
using HabrLessonClassLibrary.Repository;

namespace HabrLessonWebApplication.Controllers
{
    public class GoogleController : Controller
    {

        private IAuthenticationService _googleAuthenticationService;
        private IUserRepository _userRepository;
        
        public GoogleController(IUserRepository userRepository, IAuthenticationService googleAuthenticationService)
        {
            _googleAuthenticationService = googleAuthenticationService;
            _userRepository = userRepository; 
            
        }
        //public ActionResult Index(string code)
        //{
        //    var urlRequest = _googleAuthenticationService.GetUrlRequest("https://localhost:44300/Google/SignIn", "code", "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "email%20profile");
        //    return Redirect(urlRequest);
            
        //}

        public ActionResult SignUp()
        {
            var urlRequest = _googleAuthenticationService.GetUrlRequest("https://localhost:44300/Google/SignIn", "code", "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "email%20profile");
            return Redirect(urlRequest);
        }


        public ActionResult SignIn(string code)
        {
            var accessToken = _googleAuthenticationService.GetAccessToken(code, "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "wyTBnUJodeGGuHV5L1g3S_SQ", "https://localhost:44300/Google/SignIn", "authorization_code");
            var uInfo = _googleAuthenticationService.GetUserByAccessToken(accessToken);

            if (uInfo != null)
            {
                _userRepository.Save(uInfo);
                var currentUser = _userRepository.GetUserByEmail(uInfo.Email);

                Session["CurrentUser"] = currentUser;
                return RedirectToAction("Index", "Themes");
            }
            else
                return RedirectToAction("Error", "Home", new { errorMessage = "access_denied" });
        }

    }
}
