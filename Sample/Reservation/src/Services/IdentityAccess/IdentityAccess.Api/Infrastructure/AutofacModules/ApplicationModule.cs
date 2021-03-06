﻿using Autofac;
using SaaSEqt.IdentityAccess.Domain.Repositories;
using SaaSEqt.IdentityAccess.Infra.Data.Repositories;
using System;

namespace SaaSEqt.IdentityAccess.Api.Infrastructure.AutofacModules
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

            builder.RegisterType<GroupRepository>()
                   .As<IGroupRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<RoleRepository>()
                   .As<IRoleRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                   .As<IUserRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<TenantRepository>()
                   .As<ITenantRepository>()
                .InstancePerLifetimeScope();
            

            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
                //.AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
