using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;

namespace Registration.Data.Entities
{
    public class StateProvinceMap : EntityTypeConfiguration<StateProvince>
    {
        public StateProvinceMap()
        {
            HasRequired(sp => sp.Country).WithMany(c => c.StateProvinces).HasForeignKey(sp => sp.CountryId);
            Property(sp => sp.Name).IsRequired().HasMaxLength(50);
            Property(sp => sp.Abbereviation).IsRequired().HasMaxLength(2);

        }
    }
}
