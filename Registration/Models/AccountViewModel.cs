using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models
{
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
        public bool IsAuthenticated { get; set; }
        private List<string> _errors;
    }
}