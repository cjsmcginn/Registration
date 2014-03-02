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

        public AccountModule(IAccountService accountService)
        {
            _accountService = accountService;

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
        }
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
        private void SetUser(Account account)
        {
            //facilitate testing, should never be null in hosted environment 
            if (this.Context != null)
            {

                this.After += ctx => ctx.SetAuthenticationToken(account);
                  
            }
        }
        public void Logout()
        {

            this.After += ctx => ctx.LogOut();
        }
    }
}