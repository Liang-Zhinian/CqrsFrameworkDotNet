﻿using System;
using CqrsFramework.Bus;
using CqrsFramework.Bus.RabbitMQ;
using CqrsFramework.Commands;
using CqrsFramework.Config;
using CqrsFramework.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using SaaSEqt.eShop.Site.Api.Events.EventHandling;
using SaaSEqt.eShop.Site.Api.Infrastructure;

namespace SaaSEqt.eShop.Site.Api.Application.Configurations
{
    /*
    public static class RabbitMQEventBusSetup
    {
        public static IConfiguration Configuration { get; private set; }

        public static IServiceCollection AddRabbitMQEventBusSetup(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;

            RegisterEventBus(services);

            var provider = services.BuildServiceProvider();
            RegisterEventHandlers(provider);
            ReceiveMessages(provider);

            return services;
        }

        private static void RegisterEventBus(IServiceCollection services)
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();


                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"]
                };

                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            services.AddSingleton<RabbitMQBus>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                //var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<RabbitMQBus>>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new RabbitMQBus(rabbitMQPersistentConnection, logger, "book2business", "fanout", "book2events", false, retryCount);
            });

            services.AddSingleton<ICommandSender>(y => y.GetService<RabbitMQBus>());
            services.AddSingleton<IEventPublisher>(y => y.GetService<RabbitMQBus>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<RabbitMQBus>());


        }

        private static void RegisterEventHandlers(IServiceProvider provider) {
            var registrar = new BusRegistrar(new DependencyResolver(provider));
            registrar.Register(typeof(TenantEventHandler));
        }

        private static void ReceiveMessages(IServiceProvider provider){
            provider.GetService<RabbitMQBus>().Start();
        }
    }
    */
}
