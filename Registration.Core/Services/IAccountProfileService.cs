﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Core.Services
{
    public interface IAccountProfileService
    {
        IQueryable<Country> GetCountries();
        AccountProfile SaveAccountProfile(Account account, AccountProfile accountProfile);
    }
}
