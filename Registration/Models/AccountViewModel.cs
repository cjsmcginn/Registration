using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models
{
    /// <summary>
    /// This view model represents the users account on the client data tier.
    /// </summary>
    public class AccountViewModel
    {
        public class AccountModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string EmailAddress { get; set; }
            public string EmailAddressConfirm { get; set; }
            public string PasswordConfirm { get; set; }
        }

        public AccountModel Account { get; set; }


        public List<string> Errors
        {
            get { return _errors ?? (_errors = new List<string>()); }
            set { _errors = value; }
        }
        /// <summary>
        /// When a user is authenticated, this should be true
        /// </summary>
        public bool IsAuthenticated { get; set; }
        private List<string> _errors;
    }
}