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
    /// Concrete Implementation of ICreateAccountResponse
    /// </summary>
    /// <see cref="ICreateAccountResponse"/>
    public class CreateAccountResponse : ICreateAccountResponse
    {
        public bool Success { get; set; }

        public bool UsernameExists { get; set; }

        public bool InavlidUsername { get; set; }

        public bool InvalidPassword { get; set; }

        public Account Account { get; set; }

        public bool InvalidRecoveryEmailAddress { get; set; }
    }
}
