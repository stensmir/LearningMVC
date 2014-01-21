using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Services
{
    public interface IAuthenticationService
    {
        string GetUrlRequest(string redirectUri, string responseType, string clientId, string scope);
        string GetAccessToken(string code, string clientId, string clientSecret, string redirectUri, string grantType);
        Domain.User GetUserByAccessToken(string accessToken);

    }
}
