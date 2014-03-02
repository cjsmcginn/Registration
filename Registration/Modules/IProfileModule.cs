using System;
using System.Collections.Generic;
using Registration.Models;

namespace Registration.Modules
{
    /// <summary>
    /// Responsible for secured methods.
    /// Methods are seperated from any pipeline declaration for testability.
    /// </summary>
    public interface IProfileModule
    {
        void SaveProfile(ProfileViewModel model);
        ProfileViewModel GetProfileViewModel();
        List<KeyValuePair<Guid, string>> GetStateProvincesForCountry(Guid countryId);
    }
}