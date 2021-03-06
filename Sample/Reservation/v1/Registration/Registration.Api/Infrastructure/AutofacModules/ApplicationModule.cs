﻿using Autofac;
using CqrsFramework.Caching;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using CqrsFramework.EventSourcing;
using CqrsFramework.EventStore.MySqlDB;
using Microsoft.EntityFrameworkCore;
using Registration.Domain.CommandHandlers.Appointments;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infrastructure.Repositories;
using System;
using System.Reflection;

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

            //builder.RegisterType<Session>()
            //       .As<ISession>()
            //       .InstancePerLifetimeScope();

            //builder.RegisterType<MemoryCache>()
            //       .As<ICache>()
            //       .InstancePerLifetimeScope();

            //builder.Register<MySqlEventStore>(y => new MySqlEventStore(y.Resolve<EventStoreDbContext>().Database.GetDbConnection(),
            //                                                           y.Resolve<IEventPublisher>()))
            //       .As<IEventStore>()
            //       .InstancePerLifetimeScope();

            //builder.Register<CacheRepository>(y => new CacheRepository(new Repository(y.Resolve<IEventStore>()),
                   //                                                    y.Resolve<IEventStore>(),
                   //                                                    y.Resolve<ICache>()
                   //                                                   ))
                   //.As<IRepository>()
                   //.InstancePerLifetimeScope();


            // EfMySqlEventStore
            //services.AddScoped<IEventStore>(y => new MySqlEventStore(y.GetService<EventStoreDbContext>().Database.GetDbConnection(),
            //                                                            y.GetService<IEventPublisher>()));
            
            //services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>()),
                                                                     //y.GetService<IEventStore>(),
                                                                     //y.GetService<ICache>()));


            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(AppointmentCommandHandler).GetTypeInfo().Assembly)
                //.AsClosedTypesOf(typeof(IEventHandler<>));

        }
    }
}
