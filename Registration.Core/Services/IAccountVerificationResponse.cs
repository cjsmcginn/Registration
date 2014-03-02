using Registration.Core.Domain;

namespace Registration.Core.Services
{
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
