using HabrLessonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HabrLessonWebApplication.Controllers
{
    public class GoogleAuthController : Controller
    {
        //
        // GET: /GoogleAuth/
       

        public ActionResult Index()
        {
            var urlRequest = new BasicAuth().GetUrlRequest("https://localhost:44300/GoogleAuth/SignIn", "code", "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "email%20profile");
            return Redirect(urlRequest);
        }


        public ActionResult SignIn(string code)
        {
            var basicAuth = new BasicAuth();
            var token = basicAuth.GetAuthToken(code, "195877203613-644j0q6hmmha74lrtc01s2mupao32q1f.apps.googleusercontent.com", "wyTBnUJodeGGuHV5L1g3S_SQ", "https://localhost:44300/GoogleAuth/SignIn", "authorization_code");
            var uInfo = basicAuth.GetUserInfo(token);


            //var x = new HabrLessonClassLibrary.Domain.User {  FirstName = "x", LastName  = "y"};
            return RedirectToAction("GetUserInfo", new { customUser = "val", customer = "val2"});
        }

        public ActionResult GetUserInfo(string[] customUser)
        {
            var x = customUser;
            return View();
        }
    }
}
