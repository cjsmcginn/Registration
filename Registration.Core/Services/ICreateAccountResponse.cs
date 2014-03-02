using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Core.Services
{
    public interface ICreateAccountResponse
    {
        bool Success { get; set; }
        bool UsernameExists { get; set; }
        bool InavlidUsername { get; set; }
        bool InvalidPassword { get; set; }
        bool InvalidRecoveryEmailAddress { get; set; }
        Account Account { get; set; }
    }
}
