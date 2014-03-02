using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Data.Entities
{
    public class AccountProfileMap : EntityTypeConfiguration<AccountProfile>
    {
        public AccountProfileMap()
        {
            HasRequired(ap => ap.Account).WithOptional(a => a.AccountProfile).Map(k => k.MapKey("AccountId"));
            Property(ap => ap.Bio).HasMaxLength(1000);
            HasOptional(ap => ap.Country);
            HasOptional(ap => ap.StateProvince);
            Property(ap => ap.FirstName).HasMaxLength(50);
            Property(ap => ap.LastName).HasMaxLength(100);
            Property(ap => ap.City).HasMaxLength(100);

        }
    }
}
