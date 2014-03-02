using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Core.Domain;
using Registration.Data.Entities;

namespace Registration.Data
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext() : base("RegistrationDB")
        {
        }

        public RegistrationDbContext(string connectionStringName) : base(connectionStringName) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AccountProfile> Profiles { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new StateProvinceMap());
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new AccountProfileMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
