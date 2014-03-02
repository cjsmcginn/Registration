using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Security;

namespace Registration.Infrastructure
{
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