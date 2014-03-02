using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Core.Services
{
    /// <summary>
    /// The ICreateAccountResponse is the counterpart to the ICreateAccountRequest.This interface is use to provide a generalized structure that can be used
    /// by different providers to create accounts. This encapsulates generic account creation properties from 
    /// the underlying strategy to create accounts. Provider specific properties can be included in implementations of this interface.
    /// </summary>
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
