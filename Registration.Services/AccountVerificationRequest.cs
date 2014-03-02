using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Services;

namespace Registration.Services
{
    /// <summary>
    /// Concrete implementation of IAccountVerificationRequest
    /// </summary>
    /// <see cref="IAccountVerificationRequest"/>
    public class AccountVerificationRequest : IAccountVerificationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
