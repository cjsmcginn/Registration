using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;
using Registration.Core.Services;

namespace Registration.Services
{
    /// <summary>
    /// Concrete Implementation of IAccountVerificationResponse
    /// </summary>
    /// <see cref="IAccountVerificationResponse"/>
    public class AccountVerificationResponse : IAccountVerificationResponse
    {
        public bool UsernameDoesNotExist { get; set; }
        public bool InvalidPassword { get; set; }
        public bool AccountLockedOut { get; set; }
        public bool AccountInactive { get; set; }
        public bool Success { get; set; }
        public Account Account { get; set; }
    }
}
