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
    /// <summary>
    /// Nancy will automatically look for instances of DefaultNancyBootstrapper on startup
    /// if one is found, the application startup method will be called. 
    /// By default, Nancy uses TinyIoC as the IOC system. 
    /// </summary>
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            //Register Context initializer. This instructs code first entities what to do when the db does not exist
            container.Register(typeof(CreateDatabaseIfNotExists<>), typeof(RegistrationDbContextInitializer));
            var dbInitializer =
                container.Resolve(typeof(CreateDatabaseIfNotExists<>)) as IDatabaseInitializer<RegistrationDbContext>;
            Database.SetInitializer<RegistrationDbContext>(dbInitializer);
            container.Register<DbContext, RegistrationDbContext>();
            //In this issue of TinyIoc there is an issue with registering generics as singletons by standard <> notation
            //this could be handled by reflection if there were a large number of entities.
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