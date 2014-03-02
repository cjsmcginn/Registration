using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core;
using Registration.Core.Domain;
using Registration.Core.Services;

namespace Registration.Services
{

    public class AccountProfileService : IAccountProfileService
    {
        
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Country> _countryRepository;
        public AccountProfileService(IRepository<Account> accountRepository
            , IRepository<Country> countryRepository)
        {
            _accountRepository = accountRepository;
            _countryRepository = countryRepository;
        }

        public IQueryable<Country> GetCountries()
        {
            return _countryRepository.Table;
        }

        public AccountProfile SaveAccountProfile(Account account, AccountProfile accountProfile)
        {
            if (account.AccountProfile == null)
                account.AccountProfile = new AccountProfile {Id = Guid.NewGuid()};
            account.AccountProfile.City = accountProfile.City;
            account.AccountProfile.CountryId = accountProfile.CountryId;
            account.AccountProfile.StateProvinceId = accountProfile.StateProvinceId;
            account.AccountProfile.FirstName = accountProfile.FirstName;
            account.AccountProfile.LastName = accountProfile.LastName;
            account.AccountProfile.KeepPrivate = accountProfile.KeepPrivate;
            account.AccountProfile.Bio = accountProfile.Bio;
            _accountRepository.Update(account);
            return account.AccountProfile;

        }
    }
}
