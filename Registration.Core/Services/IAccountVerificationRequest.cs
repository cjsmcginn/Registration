using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Services
{
    /// <summary>
    /// The IAccountVerificationRequest is the counterpart to the IAccountVerificationResponse.This interface is use to provide a generalized structure that can be used
    /// by different providers to verify accounts. This encapsulates generic account creation properties from 
    /// the underlying strategy to verify accounts. Provider specific properties can be included in implementations of this interface.
    /// </summary>
    /// <see cref="IAccountVerificationResponse"/>
    public interface IAccountVerificationRequest
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
