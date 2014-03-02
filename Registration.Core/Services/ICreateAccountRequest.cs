using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Services
{
    public interface ICreateAccountRequest
    {

        string Username { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string RecoveryEmailAddress { get; set; }
        string RecoveryEmailAddressConfirm { get; set; }
    }
}
