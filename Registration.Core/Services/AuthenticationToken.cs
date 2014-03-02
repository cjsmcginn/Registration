using System;

namespace Registration.Core.Services
{
    /// <summary>
    /// This class represents an authentication token that can be serialized and persisted
    /// via cookies or other mehtods.
    /// </summary>
    public class AuthenticationToken 
    {
        public object UserId { get; set; }

        public string UserName { get; set; }

        public DateTime ExpiresOnUtc { get; set; }
    }
}
