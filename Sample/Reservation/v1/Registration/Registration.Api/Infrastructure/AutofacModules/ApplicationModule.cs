using Autofac;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Repositories;
using System;

namespace Registration.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule
        : Autofac.Module
    {

        //public string QueriesConnectionString { get; }

        public ApplicationModule(/*string qconstr*/)
        {
            //QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            //builder.Register(c => new OrderQueries(QueriesConnectionString))
                //.As<IOrderQueries>()
                //.InstancePerLifetimeScope();

            builder.RegisterType<TenantRepository>()
                   .As<ITenantRepository>()
                   .InstancePerLifetimeScope();
            
            builder.RegisterType<SiteRepository>()
                   .As<ISiteRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LocationRepository>()
                   .As<ILocationRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<ServiceItemRepository>()
                   .As<IServiceItemRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<ServiceCategoryRepository>()
                   .As<IServiceCategoryRepository>()
                   .InstancePerLifetimeScope();

            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
                //.AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
