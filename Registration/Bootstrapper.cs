using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Registration.Core;
using Registration.Core.Domain;
using Registration.Data;
using Registration.Extensions;

namespace Registration
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {

            container.Register(typeof(CreateDatabaseIfNotExists<>), typeof(RegistrationDbContextInitializer));
            var dbInitializer =
                container.Resolve(typeof(CreateDatabaseIfNotExists<>)) as IDatabaseInitializer<RegistrationDbContext>;
            Database.SetInitializer<RegistrationDbContext>(dbInitializer);
            container.Register<DbContext, RegistrationDbContext>();
            container.Register(typeof (IRepository<Account>), typeof (EfRepository<Account>)).AsSingleton();
            container.Register(typeof(IRepository<AccountProfile>), typeof(EfRepository<AccountProfile>)).AsSingleton();
            container.Register(typeof(IRepository<Country>), typeof(EfRepository<Country>)).AsSingleton();
            //adds current user to pipeline if authenticated
            pipelines.BeforeRequest.AddItemToStartOfPipeline((ctx) =>
            {
                ctx.Authorize();
                return null;
            });
           
        }
    }
}