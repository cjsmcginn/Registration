using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Registration.Core.Domain;

namespace Registration.Models
{
    /// <summary>
    /// This object represents the users profile on the client data tier.
    /// </summary>
    public class ProfileViewModel
    {
        public Guid AccountId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string City { get; set; }
        public virtual Guid? CountryId { get; set; }
        public virtual Guid? StateProvinceId { get; set; }
        public List<KeyValuePair<Guid,String>> AvailableCountries { get; set; }

        public List<KeyValuePair<Guid, String>> AvailableStateProvinces { get; set; }

        public bool KeepPrivate { get; set; }

        public string Bio { get; set; }
    }
}