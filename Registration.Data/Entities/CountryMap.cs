using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Data.Entities
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.ThreeLetterIsoCode).IsRequired().HasMaxLength(3);
            Property(c => c.TwoLetterIsoCode).IsRequired().HasMaxLength(2);
        }
    }
}
