using System.Linq;
using System.Web;
using Nancy;
using Nancy.Cookies;
using Newtonsoft.Json;
using Registration.Core;
using Registration.Core.Domain;
using Registration.Core.Extensions;
using Registration.Core.Services;
using Registration.Infrastructure;

namespace Registration.Extensions
{
    public static class NancyExtensions
    {
        static RegistrationConfiguration _registrationConfiguration = System.Configuration.ConfigurationManager.GetSection("registrationConfiguration") as RegistrationConfiguration;
        /// <summary>
        /// Given a context assuming the auth cookie is set, this will add our user identity
        /// </summary>
        /// <param name="context"></param>
        public static void Authorize(this NancyContext context)
        {
            if (!context.Request.Cookies.ContainsKey(_registrationConfiguration.AuthenticationCookieName)) return;
            var encryptedToken = HttpUtility.UrlDecode(context.Request.Cookies[_registrationConfiguration.AuthenticationCookieName]).DecryptText();
            var token = JsonConvert.DeserializeObject<AuthenticationToken>(encryptedToken);
            if (token != null && token.ExpiresOnUtc >= System.DateTime.UtcNow)
                context.CurrentUser = new UserIdentity(token.UserName);
        }

        public static void SetAuthenticationToken(this NancyContext context, Account account)
        {

            var expiration = _registrationConfiguration.CreatePersistantCookie
                ? System.DateTime.UtcNow.AddYears(1)
                : System.DateTime.UtcNow.AddMinutes(_registrationConfiguration.ExpirationMinutes);
            var token = new AuthenticationToken
            {
                UserName = account.Username,
                UserId = account.Id,
                ExpiresOnUtc = expiration
            };
            var serialized = JsonConvert.SerializeObject(token);
            var encrypted = serialized.EncryptText();

            var cookie = new NancyCookie(_registrationConfiguration.AuthenticationCookieName, encrypted);
            context.Response.WithCookie(cookie);
            
        }

        public static void LogOut(this NancyContext context)
        {
     
            var cookie = new NancyCookie(_registrationConfiguration.AuthenticationCookieName, null);
            cookie.Expires = System.DateTime.MinValue;
            context.Response.WithCookie(cookie);

        }
    }
}