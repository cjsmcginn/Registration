using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Core.Services
{
    /// <summary>
    /// Provide methods to assist with operations on Accounts
    /// </summary>
    public interface IAccountService
    {
        Account GetAccount(string username, string password);
        Account GetAccountById(Guid id);

        Account GetAccountByUsername(string username);

        ICreateAccountResponse CreateAccount(ICreateAccountRequest request);
        void SaveAccount(Account account);

        void DeleteAccount(Account account);

        IAccountVerificationResponse VerifyAccount(IAccountVerificationRequest request);

    }
}
