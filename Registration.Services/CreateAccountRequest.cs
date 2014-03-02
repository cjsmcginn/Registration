using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Services;

namespace Registration.Services
{
    /// <summary>
    /// Concrete Implementation of ICreateAccountRequest
    /// </summary>
    /// <see cref="ICreateAccountRequest"/>
    public class CreateAccountRequest : ICreateAccountRequest
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RecoveryEmailAddress { get; set; }
        public string RecoveryEmailAddressConfirm { get; set; }
    }
}
