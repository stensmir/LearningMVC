using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HabrLessonClassLibrary.Services
{
    public class GoogleAuthenticationService : IAuthenticationService
    {
        private readonly string _baseGoogleRequestCodeUrl = "https://accounts.google.com/o/oauth2/auth?redirect_uri={0}&response_type={1}&client_id={2}&scope={3}";

        public string GetUrlRequest(string redirectUri, string responseType, string clientId, string scope)
        {
            var requestString = string.Format(_baseGoogleRequestCodeUrl, redirectUri, responseType, clientId, scope);
            return requestString;
        }

        public string GetAccessToken(string code, string clientId, string clientSecret, string redirectUri, string grantType)
        {

            
            using (var client = new HttpClient())
            {
                var postData = new List<KeyValuePair<string, string>> 
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("redirect_uri", redirectUri),
                    new KeyValuePair<string, string>("grant_type", grantType)
                };

                var response = client.PostAsync("https://accounts.google.com/o/oauth2/token", new FormUrlEncodedContent(postData)).Result;

                var responseJson = response.Content.ReadAsStringAsync().Result;
                dynamic content = JObject.Parse(responseJson);

                return (string)content.access_token;
            }
        }

        public string GetUserInfo(string accessToken)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(string.Format("https://www.googleapis.com/oauth2/v1/userinfo?access_token={0}", accessToken)).Result;
                var b = 5;
                return "";
            }

        }
    }
}
