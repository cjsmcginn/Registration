using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Data
{
   /// <summary>
   /// This contrext initializer is provider to seed new databases the first time the application is run in a new
   /// environment, and also provides support for unique index creation abscent from code first entity mapping attributes.
   /// </summary>
    public class RegistrationDbContextInitializer : CreateDatabaseIfNotExists<RegistrationDbContext>
    {
     
        protected override void Seed(RegistrationDbContext context)
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "United States",
                    ThreeLetterIsoCode = "USA",
                    TwoLetterIsoCode = "US",
                    StateProvinces = new List<StateProvince>
                    {
                        new StateProvince {Name = "AA (Armed Forces Americas)", Id = Guid.NewGuid(), Abbereviation = "AA"},
                        new StateProvince {Name = "AE (Armed Forces Europe)", Id = Guid.NewGuid(), Abbereviation = "AE"},
                        new StateProvince {Name = "Alabama", Id = Guid.NewGuid(), Abbereviation = "AL"},
                        new StateProvince {Name = "Alaska", Id = Guid.NewGuid(), Abbereviation = "AK"},
                        new StateProvince {Name = "American Samoa", Id = Guid.NewGuid(), Abbereviation = "AS"},
                        new StateProvince {Name = "AP (Armed Forces Pacific)", Id = Guid.NewGuid(), Abbereviation = "AP"},
                        new StateProvince {Name = "Arizona", Id = Guid.NewGuid(), Abbereviation = "AZ"},
                        new StateProvince {Name = "Arkansas", Id = Guid.NewGuid(), Abbereviation = "AR"},
                        new StateProvince {Name = "California", Id = Guid.NewGuid(), Abbereviation = "CA"},
                        new StateProvince {Name = "Colorado", Id = Guid.NewGuid(), Abbereviation = "CO"},
                        new StateProvince {Name = "Connecticut", Id = Guid.NewGuid(), Abbereviation = "CT"},
                        new StateProvince {Name = "Delaware", Id = Guid.NewGuid(), Abbereviation = "DE"},
                        new StateProvince {Name = "District of Columbia", Id = Guid.NewGuid(), Abbereviation = "DC"},
                        new StateProvince {Name = "Federated States of Micronesia", Id = Guid.NewGuid(), Abbereviation = "FM"},
                        new StateProvince {Name = "Florida", Id = Guid.NewGuid(), Abbereviation = "FL"},
                        new StateProvince {Name = "Georgia", Id = Guid.NewGuid(), Abbereviation = "GA"},
                        new StateProvince {Name = "Guam", Id = Guid.NewGuid(), Abbereviation = "GU"},
                        new StateProvince {Name = "Hawaii", Id = Guid.NewGuid(), Abbereviation = "HI"},
                        new StateProvince {Name = "Idaho", Id = Guid.NewGuid(), Abbereviation = "ID"},
                        new StateProvince {Name = "Illinois", Id = Guid.NewGuid(), Abbereviation = "IL"},
                        new StateProvince {Name = "Indiana", Id = Guid.NewGuid(), Abbereviation = "IN"},
                        new StateProvince {Name = "Iowa", Id = Guid.NewGuid(), Abbereviation = "IA"},
                        new StateProvince {Name = "Kansas", Id = Guid.NewGuid(), Abbereviation = "KS"},
                        new StateProvince {Name = "Kentucky", Id = Guid.NewGuid(), Abbereviation = "KY"},
                        new StateProvince {Name = "Louisiana", Id = Guid.NewGuid(), Abbereviation = "LA"},
                        new StateProvince {Name = "Maine", Id = Guid.NewGuid(), Abbereviation = "ME"},
                        new StateProvince {Name = "Marshall Islands", Id = Guid.NewGuid(), Abbereviation = "MH"},
                        new StateProvince {Name = "Maryland", Id = Guid.NewGuid(), Abbereviation = "MD"},
                        new StateProvince {Name = "Massachusetts", Id = Guid.NewGuid(), Abbereviation = "MA"},
                        new StateProvince {Name = "Michigan", Id = Guid.NewGuid(), Abbereviation = "MI"},
                        new StateProvince {Name = "Minnesota", Id = Guid.NewGuid(), Abbereviation = "MN"},
                        new StateProvince {Name = "Mississippi", Id = Guid.NewGuid(), Abbereviation = "MS"},
                        new StateProvince {Name = "Missouri", Id = Guid.NewGuid(), Abbereviation = "MO"},
                        new StateProvince {Name = "Montana", Id = Guid.NewGuid(), Abbereviation = "MT"},
                        new StateProvince {Name = "Nebraska", Id = Guid.NewGuid(), Abbereviation = "NE"},
                        new StateProvince {Name = "Nevada", Id = Guid.NewGuid(), Abbereviation = "NV"},
                        new StateProvince {Name = "New Hampshire", Id = Guid.NewGuid(), Abbereviation = "NH"},
                        new StateProvince {Name = "New Jersey", Id = Guid.NewGuid(), Abbereviation = "NJ"},
                        new StateProvince {Name = "New Mexico", Id = Guid.NewGuid(), Abbereviation = "NM"},
                        new StateProvince {Name = "New York", Id = Guid.NewGuid(), Abbereviation = "NY"},
                        new StateProvince {Name = "North Carolina", Id = Guid.NewGuid(), Abbereviation = "NC"},
                        new StateProvince {Name = "North Dakota", Id = Guid.NewGuid(), Abbereviation = "ND"},
                        new StateProvince {Name = "Northern Mariana Islands", Id = Guid.NewGuid(), Abbereviation = "MP"},
                        new StateProvince {Name = "Ohio", Id = Guid.NewGuid(), Abbereviation = "OH"},
                        new StateProvince {Name = "Oklahoma", Id = Guid.NewGuid(), Abbereviation = "OK"},
                        new StateProvince {Name = "Oregon", Id = Guid.NewGuid(), Abbereviation = "OR"},
                        new StateProvince {Name = "Palau", Id = Guid.NewGuid(), Abbereviation = "PW"},
                        new StateProvince {Name = "Pennsylvania", Id = Guid.NewGuid(), Abbereviation = "PA"},
                        new StateProvince {Name = "Puerto Rico", Id = Guid.NewGuid(), Abbereviation = "PR"},
                        new StateProvince {Name = "Rhode Island", Id = Guid.NewGuid(), Abbereviation = "RI"},
                        new StateProvince {Name = "South Carolina", Id = Guid.NewGuid(), Abbereviation = "SC"},
                        new StateProvince {Name = "South Dakota", Id = Guid.NewGuid(), Abbereviation = "SD"},
                        new StateProvince {Name = "Tennessee", Id = Guid.NewGuid(), Abbereviation = "TN"},
                        new StateProvince {Name = "Texas", Id = Guid.NewGuid(), Abbereviation = "TX"},
                        new StateProvince {Name = "Utah", Id = Guid.NewGuid(), Abbereviation = "UT"},
                        new StateProvince {Name = "Vermont", Id = Guid.NewGuid(), Abbereviation = "VT"},
                        new StateProvince {Name = "Virgin Islands", Id = Guid.NewGuid(), Abbereviation = "VI"},
                        new StateProvince {Name = "Virginia", Id = Guid.NewGuid(), Abbereviation = "VA"},
                        new StateProvince {Name = "Washington", Id = Guid.NewGuid(), Abbereviation = "WA"},
                        new StateProvince {Name = "West Virginia", Id = Guid.NewGuid(), Abbereviation = "WV"},
                        new StateProvince {Name = "Wisconsin", Id = Guid.NewGuid(), Abbereviation = "WI"},
                        new StateProvince {Name = "Wyoming", Id = Guid.NewGuid(), Abbereviation = "WY"}

                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Canada",
                    ThreeLetterIsoCode = "CAN",
                    TwoLetterIsoCode = "CA",
                    StateProvinces = new List<StateProvince>
                    {
                        new StateProvince {Name = "Alberta", Id = Guid.NewGuid(), Abbereviation = "AB"},
                        new StateProvince {Name = "British Columbia", Id = Guid.NewGuid(), Abbereviation = "BC"},
                        new StateProvince {Name = "Manitoba", Id = Guid.NewGuid(), Abbereviation = "MB"},
                        new StateProvince {Name = "New Brunswick", Id = Guid.NewGuid(), Abbereviation = "NB"},
                        new StateProvince {Name = "Newfoundland and Labrador", Id = Guid.NewGuid(), Abbereviation = "NL"},
                        new StateProvince {Name = "Northwest Territories", Id = Guid.NewGuid(), Abbereviation = "NT"},
                        new StateProvince {Name = "Nova Scotia", Id = Guid.NewGuid(), Abbereviation = "NS"},
                        new StateProvince {Name = "Nunavut", Id = Guid.NewGuid(), Abbereviation = "NU"},
                        new StateProvince {Name = "Ontario", Id = Guid.NewGuid(), Abbereviation = "ON"},
                        new StateProvince {Name = "Prince Edward Island", Id = Guid.NewGuid(), Abbereviation = "PE"},
                        new StateProvince {Name = "Quebec", Id = Guid.NewGuid(), Abbereviation = "QC"},
                        new StateProvince {Name = "Saskatchewan", Id = Guid.NewGuid(), Abbereviation = "SK"},
                        new StateProvince {Name = "Yukon Territory", Id = Guid.NewGuid(), Abbereviation = "YU"}
                    }
                }
            };

            countries.ForEach(x => context.Countries.Add(x));
            base.Seed(context);
            //typically would be done by enabling DB migration
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.Accounts ADD CONSTRAINT UC_Username UNIQUE (Username)", new object[] { });
            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.Accounts ADD CONSTRAINT UC_Email UNIQUE (RecoveryEmailAddress)", new object[] { }); 
        }
    }
}
