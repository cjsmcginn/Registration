using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Nancy;
using Registration.Core.Domain;
using Registration.Extensions;
using Nancy.ModelBinding;
using Registration.Core.Services;
using Registration.Models;
using Registration.Services;

namespace Registration.Modules
{
    public class AccountModule : NancyModule, IAccountModule
    {
        private readonly IAccountService _accountService;
        /// <summary>
        /// This module handles requests that allow a user to register, login and logout.
        /// The services are provided provided by IOC container (see the bootstrapper)
        /// </summary>
        /// <param name="accountService"></param>
        public AccountModule(IAccountService accountService)
        {
            _accountService = accountService;
            #region Handler Methods
            Get["/account"] = p =>
            {
                var result = new AccountViewModel
                {
                    Account = new AccountViewModel.AccountModel(),
                    IsAuthenticated = this.Context.CurrentUser != null
                };

                if (this.Context.CurrentUser != null)
                {
                    result.Account.Username = this.Context.CurrentUser.UserName;
                }

                return result;
            };
            Post["/login"] = p =>
            {
                var model = this.Bind<AccountViewModel>();
                Login(model);
                return model;
            };
            Post["/register"] = p =>
            {
                var model = this.Bind<AccountViewModel>();
                try
                {
                    this.Response.Context.Response = new Response();
                    RegisterAccount(model);
                    this.Response.Context.Response.StatusCode = HttpStatusCode.OK;
                    return model;
                }
                catch (System.Exception ex)
                {
                    //Log or something
                    return HttpStatusCode.BadRequest;
                }
            };
            Post["/logout"] = p =>
            {
                Logout();
                return HttpStatusCode.OK;
            };
            #endregion
        }

        #region IAccountModule Implementation
        /// <summary>
        /// Registers a new account, sets authenticated property to true if successful.
        /// If registration is success SetUser will be called to set the authentication token.
        /// </summary>
        /// <param name="model"></param>
        public void RegisterAccount(AccountViewModel model)
        {
            var request = new CreateAccountRequest
            {
                ConfirmPassword = model.Account.PasswordConfirm,
                Password = model.Account.Password,
                Username = model.Account.Username,
                RecoveryEmailAddress = model.Account.EmailAddress,
                RecoveryEmailAddressConfirm = model.Account.EmailAddressConfirm

            };
            var response = _accountService.CreateAccount(request);
            if (!response.Success)
            {
                if (response.UsernameExists)
                    model.Errors.Add("An account with this username already exists");
                if (response.InavlidUsername)
                    model.Errors.Add("Invalid Username");
                if (response.InvalidPassword)
                    model.Errors.Add("Invalid Password");
                if (response.InvalidRecoveryEmailAddress)
                    model.Errors.Add("Invalid Email Address");
            }
            else
            {
               SetUser(response.Account);
               model.IsAuthenticated = true;
            }

        }
        /// <summary>
        /// Using bound account view model, attempt to login 
        /// and set authenticated property appropritely.
        /// If login is success SetUser will be called to set the authentication token.
        /// </summary>
        /// <param name="model"></param>
        public void Login(AccountViewModel model)
        {
            var request = new AccountVerificationRequest
            {
                Password = model.Account.Password,
                Username = model.Account.Username
            };

            var response = _accountService.VerifyAccount(request);

            if (!response.Success)
            {
                if (response.AccountInactive)
                    model.Errors.Add("Account is Inactive");
                if (response.AccountLockedOut)
                    model.Errors.Add("Account is Locked Out");
                if (response.InvalidPassword)
                    model.Errors.Add("Invalid Password");
                if (response.UsernameDoesNotExist)
                    model.Errors.Add("Invalid Username or Password");
            }
            else
            {
                SetUser(response.Account);
                model.IsAuthenticated = true;
               
            }


        }
        /// <summary>
        /// Unsets the authentication token
        /// </summary>
        public void Logout()
        {
            this.After += ctx => ctx.LogOut();
        }
        #endregion

        #region Class Methods
        /// <summary>
        /// Sets the authentication token, bypass provided for testability.
        /// </summary>
        /// <param name="account"></param>
        private void SetUser(Account account)
        {
            //facilitate testing, should never be null in hosted environment 
            if (this.Context != null)
            {

                this.After += ctx => ctx.SetAuthenticationToken(account);

            }
        }
        #endregion
    }
}