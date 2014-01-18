using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HabrLessonWebApplication.Models
{
    public class BasicAuth
    {
        private readonly string _baseGoogleRequestCodeUrl = "https://accounts.google.com/o/oauth2/auth?redirect_uri={0}&response_type={1}&client_id={2}&scope={3}";
        //private readonly string _baseGoogleRequesTokenUrl = "code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type={4}";


        public virtual string GetUrlRequest(string redirectUri, string responseType, string clientId, string scope)
        {
            var requestString = string.Format(_baseGoogleRequestCodeUrl, redirectUri, responseType, clientId, scope);
            return requestString;
            
        }


        public virtual string GetAuthToken(string code, string clientId, string clientSecret, string redirectUri, string grantType)
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
                var con = response.Content.ReadAsStringAsync().Result; 


                return "";
            }
        }

        public virtual string GetUserInfo(string authToken)
        {
            throw new NotImplementedException();
        }
    }
}