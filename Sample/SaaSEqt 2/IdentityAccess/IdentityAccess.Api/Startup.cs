﻿using System;
using System.Data.Common;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CqrsFramework.EventSourcing;
using CqrsFramework.EventStore.MySqlDB.Services;
using SaaSEqt.Infrastructure.HealthChecks.MySQL;
using SaaSEqt.IdentityAccess.Api.Infrastructure.AutofacModules;
using SaaSEqt.IdentityAccess.Api.Infrastructure.Filters;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaaSEqt.IdentityAccess.Api.Configurations;
using SaaSEqt.IdentityAccess.Application;
using SaaSEqt.IdentityAccess.Infra.Data.Context;

namespace SaaSEqt.IdentityAccess.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddMemoryCache();

            RegisterAppInsights(services);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices() //Injecting Controllers themselves thru DI
            //全局配置Json序列化处理
            .AddJsonOptions(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });

            services.AddHealthChecks(checks =>
            {
                var minutes = 1;
                if (int.TryParse(Configuration["HealthCheck:Timeout"], out var minutesParsed))
                {
                    minutes = minutesParsed;
                }
                checks.AddMySQLCheck("book2db", Configuration["ConnectionString"], TimeSpan.FromMinutes(minutes));
                checks.AddUrlCheck("http://localhost:15672/", TimeSpan.FromMinutes(minutes));

            });

            services.AddDbContext<IdentityAccessDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionString"],
                                 mySqlOptionsAction: sqlOptions =>
                                 {
                                     sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                     //sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                 });

                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }, ServiceLifetime.Scoped);


            services.AddDbContext<EventStoreDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionString"],
                                 mySqlOptionsAction: sqlOptions =>
                                 {
                                     sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                     //sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                 });

                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }, ServiceLifetime.Scoped);

            services.AddSwaggerSupport();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // Add application services.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));

            services.AddTransient<IIdentityAccessIntegrationEventService, IdentityAccessIntegrationEventService>();


            //services.AddAutoMapperSetup();

            services.AddEventStoreSetup();

            services.AddApplicationSetup();

            services.AddRabbitMQEventBusSetup(Configuration);

            services.AddIdentityAccessEventProcessorSetup();

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule());
            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configure logs

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddAzureWebAppDiagnostics();
            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Trace);

            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                loggerFactory.CreateLogger("init").LogDebug($"Using PATH BASE '{pathBase}'");
                app.UsePathBase(pathBase);
            }

            app.UseCors("CorsPolicy");

            app.UseMvcWithDefaultRoute();

            app.UseSwagger()
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book2 IdentityAccess API V1");
                //c.ShowRequestHeaders();
            });

            //app.UseMvc();

            ConfigureEventBus(app);

        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var services = app.ApplicationServices;
            services.GetService<IdentityAccessEventProcessor>().Listen();

            //var eventBus = app.ApplicationServices.GetRequiredService<BuildingBlocks.EventBus.Abstractions.IEventBus>();

            //private static void RegisterIdentityAccessEventProcessor(IServiceCollection services)
            //{
            using (var scope = services.CreateScope())
            {
                //scope.ServiceProvider.AddScoped<SaaSEqt.Common.Events.IEventStore, SaaSEqt.IdentityAccess.Infra.Services.MySqlEventStore>()
                //    .AddScoped<IdentityAccessEventProcessor>(/*y =>
                //{
                //    return new IdentityAccessEventProcessor(y.GetService<SaaSEqt.Common.Events.IEventStore>(),
                //                                            y.GetService<IEventPublisher>());
                //}*/);
                ////}

                ////private static void ConfigureIdentityAccessEventProcessor(IServiceCollection services)
                ////{
                //services.BuildServiceProvider().GetService<IdentityAccessEventProcessor>().Listen();
                //}
            }
        }

        #region additional registration

        private void RegisterAppInsights(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            var orchestratorType = Configuration.GetValue<string>("OrchestratorType");

            //if (orchestratorType?.ToUpper() == "K8S")
            //{
            //    // Enable K8s telemetry initializer
            //    services.EnableKubernetes();
            //}
            //if (orchestratorType?.ToUpper() == "SF")
            //{
            //    // Enable SF telemetry initializer
            //    services.AddScoped<ITelemetryInitializer>((serviceProvider) =>
            //        new FabricTelemetryInitializer());
            //}
        }

        #endregion
    }
}
