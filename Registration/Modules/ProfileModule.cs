using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using Registration.Core.Domain;
using Registration.Core.Services;
using Registration.Models;

namespace Registration.Modules
{
    public class ProfileModule:NancyModule, IProfileModule
    {
        private readonly IAccountService _accountService;
        private readonly IAccountProfileService _accountProfileService;
        /// <summary>
        /// Secure module that handles requests to save a users profile
        /// The services are provided provided by IOC container (see the bootstrapper)
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="accountProfileService"></param>
        public ProfileModule(IAccountService accountService
            , IAccountProfileService accountProfileService)
        {
            _accountService = accountService;
            _accountProfileService = accountProfileService;

            //Calling this built in helper will check that the current User Identity is set before methods can be called.
            this.RequiresAuthentication();
            #region Handler Methods
            Get["/profile"] = p =>
            {
                var result = GetProfileViewModel();
                return result;
            };
            Get["/states/{countryId}"] = p =>
            {
                var result = GetStateProvincesForCountry(p.CountryId);
                return result;
            };
            Post["/profile"] = p =>
            {
                var model = this.Bind<ProfileViewModel>();
                SaveProfile(model);
                return model;
            };
            #endregion
        }

        public virtual void SaveProfile(ProfileViewModel model)
        {
            var account = _accountService.GetAccountByUsername(this.Context.CurrentUser.UserName);
            var profile = new AccountProfile
            {
                City = model.City,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CountryId = model.CountryId,
                StateProvinceId = model.StateProvinceId,
                Bio = model.Bio,
                KeepPrivate = model.KeepPrivate
            };
            _accountProfileService.SaveAccountProfile(account, profile);

        }

        public virtual ProfileViewModel GetProfileViewModel()
        {
            var result = new ProfileViewModel();
            var account = _accountService.GetAccountByUsername(this.Context.CurrentUser.UserName);
            result.AccountId = account.Id;

            if (account.AccountProfile != null)
            {
                result.FirstName = account.AccountProfile.FirstName;
                result.LastName = account.AccountProfile.LastName;
                result.City = account.AccountProfile.City;
                result.CountryId = account.AccountProfile.CountryId;
                result.StateProvinceId = account.AccountProfile.StateProvinceId;
                result.Bio = account.AccountProfile.Bio;
                result.KeepPrivate = account.AccountProfile.KeepPrivate;
                result.AvailableStateProvinces =
                    _accountProfileService.GetCountries()
                        .Single(x => x.Id == result.CountryId)
                        .StateProvinces.Select(x => new KeyValuePair<Guid, string>(x.Id, x.Name))
                        .ToList();

            }

            result.AvailableCountries =
                _accountProfileService.GetCountries()
                    .Select(x => new {Id = x.Id, Name = x.Name})
                    .ToList()
                    .Select(x => new KeyValuePair<Guid, string>(x.Id, x.Name))
                    .ToList();
            return result;
        }

        public virtual List<KeyValuePair<Guid, string>> GetStateProvincesForCountry(Guid countryId)
        {
            var result = new List<KeyValuePair<Guid, string>>();
            var country = _accountProfileService.GetCountries()
                .SingleOrDefault(x => x.Id == countryId);
            if (country != null)
            {
                result = country.StateProvinces.Select(x => new {Id = x.Id, Name = x.Name})
                    .ToList()
                    .Select(x => new KeyValuePair<Guid, string>(x.Id, x.Name))
                    .ToList();

            }
            return result;

        }
    }
}