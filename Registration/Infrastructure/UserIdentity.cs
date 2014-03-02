using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Security;

namespace Registration.Infrastructure
{
    /// <summary>
    /// A custom implementation of a nancy user identity. This allows us to use 
    /// built in helpers that the library provides. Nancy is trained to recognize instances
    /// of IUserIdentity
    /// </summary>
    public class UserIdentity : IUserIdentity
    {
        private readonly string _username;
        private readonly List<string> _claims;

        public UserIdentity(string username)
        {
            _claims = new List<string>();
            _username = username;
        }
        public UserIdentity(string username, List<string> claims)
        {
            _claims = claims;
            _username = username;
        }

        public IEnumerable<string> Claims
        {
            get { return _claims; }
        }

        public string UserName
        {
            get { return _username; }
        }
    }
}