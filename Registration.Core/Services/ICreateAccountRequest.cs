using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Services
{
    /// <summary>
    /// The ICreateAccountRequest is the counterpart to the ICreateAccountResponse.This interface is use to provide a generalized structure that can be used
    /// by different providers to create accounts. This encapsulates generic account creation properties from 
    /// the underlying strategy to create accounts. Provider specific properties can be included in implementations of this interface.
    /// </summary>
    /// <see cref="ICreateAccountResponse"/>
    public interface ICreateAccountRequest
    {

        string Username { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string RecoveryEmailAddress { get; set; }
        string RecoveryEmailAddressConfirm { get; set; }
    }
}
