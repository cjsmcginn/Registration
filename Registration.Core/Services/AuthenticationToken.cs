using System;

namespace Registration.Core.Services
{
    public class AuthenticationToken 
    {
        public object UserId { get; set; }

        public string UserName { get; set; }

        public DateTime ExpiresOnUtc { get; set; }
    }
}
