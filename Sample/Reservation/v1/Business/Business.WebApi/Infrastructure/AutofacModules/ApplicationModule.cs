using Autofac;
using Business.Domain.Repositories;
using Business.Infra.Data.Repositories;
using System;

namespace Business.WebApi.Infrastructure.AutofacModules
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

            builder.RegisterType<TenantAddressRepository>()
                   .As<ITenantAddressRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<TenantContactRepository>()
                   .As<ITenantContactRepository>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
                //.AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
