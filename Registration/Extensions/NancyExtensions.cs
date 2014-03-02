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
    /// <summary>
    /// Helper classes for Nancy
    /// Contains methods to assist with authentication.
    /// </summary>
    public static class NancyExtensions
    {
        static readonly RegistrationConfiguration RegistrationConfiguration = System.Configuration.ConfigurationManager.GetSection("registrationConfiguration") as RegistrationConfiguration;
        /// <summary>
        /// Given a context assuming the auth cookie is set, this will add our user identity.
        /// This method will also handle decrypting and interrogating the token
        /// </summary>
        /// <param name="context"></param>
        public static void Authorize(this NancyContext context)
        {
            if (!context.Request.Cookies.ContainsKey(RegistrationConfiguration.AuthenticationCookieName)) return;
            var encryptedToken = HttpUtility.UrlDecode(context.Request.Cookies[RegistrationConfiguration.AuthenticationCookieName]).DecryptText();
            var token = JsonConvert.DeserializeObject<AuthenticationToken>(encryptedToken);
            if (token != null && token.ExpiresOnUtc >= System.DateTime.UtcNow)
                context.CurrentUser = new UserIdentity(token.UserName);
        }
        /// <summary>
        /// Sets a cookie representing an Authentication token object. Depending on the Registration Configuration,
        /// this method will set the expiration accordingly
        /// </summary>
        /// <param name="context"></param>
        /// <param name="account"></param>
        public static void SetAuthenticationToken(this NancyContext context, Account account)
        {

            var expiration = RegistrationConfiguration.CreatePersistantCookie
                ? System.DateTime.UtcNow.AddYears(1)
                : System.DateTime.UtcNow.AddMinutes(RegistrationConfiguration.ExpirationMinutes);
            var token = new AuthenticationToken
            {
                UserName = account.Username,
                UserId = account.Id,
                ExpiresOnUtc = expiration
            };
            var serialized = JsonConvert.SerializeObject(token);
            var encrypted = serialized.EncryptText();

            var cookie = new NancyCookie(RegistrationConfiguration.AuthenticationCookieName, encrypted);
            context.Response.WithCookie(cookie);
            
        }
        /// <summary>
        /// Logs out the user by expiring authentication token cookie
        /// </summary>
        /// <param name="context"></param>
        public static void LogOut(this NancyContext context)
        {
     
            var cookie = new NancyCookie(RegistrationConfiguration.AuthenticationCookieName, null);
            cookie.Expires = System.DateTime.MinValue;
            context.Response.WithCookie(cookie);

        }
    }
}