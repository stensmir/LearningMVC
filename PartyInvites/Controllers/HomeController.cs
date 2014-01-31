using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;
using System.Net.Http;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestRespone guestResponse)
        {
            if (ModelState.IsValid)
            {
                //TODO: Email response to the party organizer
                using (var client = new HttpClient())
                {
                    var response = client.GetStringAsync(string.Format("http://sms.ru/sms/send?api_id=274a8727-80d9-1514-5d69-95ad1fbd45d4&to={0}&text=Хорошей+вечеринки+{1}&from=BobInc", guestResponse.Phone, guestResponse.Name)).Result;
                }
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
	}
}