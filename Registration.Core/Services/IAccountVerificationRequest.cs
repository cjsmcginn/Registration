using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Services
{
    public interface IAccountVerificationRequest
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
