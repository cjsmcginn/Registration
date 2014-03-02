using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Data.Entities
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
          
            Property(a => a.CreatedOnUtc).IsRequired();
            Property(a => a.RecoveryEmailAddress).IsRequired().HasMaxLength(200);
            Property(a => a.Password).IsRequired().HasMaxLength(50);
            Property(a => a.Username).IsRequired().HasMaxLength(100);
            
        }
    }
}
