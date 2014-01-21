﻿using System;
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

        private IAuthenticationService _googleAuth;
        private IUserRepository _userRepository;
        
        public GoogleController(IUserRepository userRepository)
        {
            _googleAuth = DependencyResolver.Current.GetServices<IAuthenticationService>().Single();
            _userRepository = userRepository; //DependencyResolver.Current.GetService<IUserRepository>();
            
        }
        public ActionResult Index(string code)
        {
            //var urlRequest = new BasicAuth().GetUrlRequest("https://localhost:44300/Google/SignIn", "code", "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "email%20profile");
            var urlRequest = _googleAuth.GetUrlRequest("https://localhost:44300/Google/SignIn", "code", "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "email%20profile");
            return Redirect(urlRequest);
            
        }


        public ActionResult SignIn(string code)
        {
            //var basicAuth = new BasicAuth();
            var accessToken = _googleAuth.GetAccessToken(code, "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "wyTBnUJodeGGuHV5L1g3S_SQ", "https://localhost:44300/Google/SignIn", "authorization_code");
            var uInfo = _googleAuth.GetUserByAccessToken(accessToken);

            _userRepository.Save(uInfo);

            Session["User"] = uInfo;
            return RedirectToAction("Index", "Home");
        }

    }
}
