using System;
using System.Linq;
using Registration.Core;
using Registration.Core.Domain;
using Registration.Core.Extensions;
using Registration.Core.Services;

namespace Registration.Services
{
    /// <summary>
    /// AccountService prescribes to the single responsibility principle and serves as what should be the 
    /// single place where operations involving Accounts are performed.
    /// This class provides CRUD operations on Accounts, and should be the only place where this is performed.
    /// </summary>
    public class AccountService : IAccountService
    {
        static readonly RegistrationConfiguration RegistrationConfiguration = System.Configuration.ConfigurationManager.GetSection("registrationConfiguration") as RegistrationConfiguration;
        private readonly IRepository<Account> _accountRepository;

        #region IAccountService Implementation

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccount(string username, string password)
        {
            return _accountRepository.Table.SingleOrDefault(x => x.Username == username && x.Password == password);
        }

        public Account GetAccountById(Guid id)
        {
            return _accountRepository.Table.SingleOrDefault(x => x.Id == id);
        }


        public Account GetAccountByUsername(string username)
        {
            return _accountRepository.Table.SingleOrDefault(x => x.Username.Equals(username,StringComparison.InvariantCultureIgnoreCase));
        }
        public void SaveAccount(Account account)
        {
            //inserts are not allowed as accounts created through CreateAccount
            _accountRepository.Update(account);

        }


        public ICreateAccountResponse CreateAccount(ICreateAccountRequest request)
        {
            var result = new CreateAccountResponse();
            result.InvalidPassword = request.Password.Length < RegistrationConfiguration.MinimumPasswordLength || request.Password.Length > RegistrationConfiguration.MaximumPasswordLength;
            var acct = new Account
            {
                Active = true,
                CreatedOnUtc = DateTime.UtcNow,
                Encrypted = RegistrationConfiguration.EncryptPassword,
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password,
                RecoveryEmailAddress = request.RecoveryEmailAddress
            };


            result.UsernameExists = _accountRepository.Table.Any(
                 x => x.Username.Equals(acct.Username, StringComparison.InvariantCultureIgnoreCase));


            result.InavlidUsername = acct.Username.Length < RegistrationConfiguration.MinimumUsernameLength || acct.Username.Length > RegistrationConfiguration.MaximumUsernameLength;

            result.InvalidRecoveryEmailAddress = String.IsNullOrEmpty(acct.RecoveryEmailAddress) ||
                                                 acct.RecoveryEmailAddress.Length >= 200;
         
            if (!result.UsernameExists & !result.InavlidUsername & !result.InvalidPassword & !result.InvalidRecoveryEmailAddress)
            {
                if (RegistrationConfiguration.EncryptPassword)
                {
                    acct.Password = request.Password.EncryptText();
                    acct.Encrypted = true;
                }
                _accountRepository.Insert(acct);
                result.Success = true;
                result.Account = acct;
            }
            return result;

        }
        public void DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public IAccountVerificationResponse VerifyAccount(IAccountVerificationRequest request)
        {
            var result = new AccountVerificationResponse();
            var account = _accountRepository.Table.SingleOrDefault(
                x => x.Username.Equals(request.Username, StringComparison.InvariantCultureIgnoreCase));
            if (account == null)
                result.UsernameDoesNotExist = true;
            else
            {
                if (account.Encrypted)
                    request.Password = request.Password.EncryptText();

                result.InvalidPassword = request.Password != account.Password;
                if (!result.InvalidPassword)
                    result.AccountInactive = !account.Active;
                else
                {
                    account.RetryCount += 1;
                    //TODO:Configurable
                    if (account.RetryCount > 9)
                    {
                        account.IsLockedOut = true;
                        result.AccountLockedOut = true;
                    }
                }
                result.Success = !result.AccountLockedOut & !result.AccountInactive & !result.InvalidPassword &
                                   !result.UsernameDoesNotExist;
                if (result.Success)
                    account.LastLogin = DateTime.UtcNow;


            }
            if (account != null)
            {
                _accountRepository.Update(account);
                result.Account = account;
            }
            return result;


        }
        
        #endregion


    }
}
