using Registration.Core.Domain;

namespace Registration.Core.Services
{
    /// <summary>
    /// The IAccountVerificationResponse is the counterpart to the IAccountVerificationRequest.This interface is use to provide a generalized structure that can be used
    /// by different providers to verify accounts. This encapsulates generic account creation properties from 
    /// the underlying strategy to verify accounts. Provider specific properties can be included in implementations of this interface.
    /// </summary>
    /// <see cref="IAccountVerificationRequest"/>
    public interface IAccountVerificationResponse
    {
        bool UsernameDoesNotExist { get; set; }
        bool InvalidPassword { get; set; }
        bool AccountLockedOut { get; set; }
        bool AccountInactive { get; set; }
        bool Success { get; set; }
        Account Account { get; set; }
    }
}
