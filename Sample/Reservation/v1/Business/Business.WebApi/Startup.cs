using System;
using System.Data.Common;
using System.Reflection;
using Business.Application.Services;
using Business.Domain.Services;
using Business.Infra.Data.Context;
using Business.WebApi.Configurations;
using Business.WebApi.Infrastructure.Filters;
using CqrsFramework.EventStore.IntegrationEventLogEF;
using CqrsFramework.EventStore.IntegrationEventLogEF.Services;
using HealthChecks.MySQL;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaaSEqt.IdentityAccess.Infra.Data.Context;

namespace Business.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BusinessDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionString"],
                                 mySqlOptionsAction: sqlOptions =>
                                 {
                                     sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                     //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                     //sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                 });

                // Changing default behavior when client evaluation occurs to throw. 
                // Default in EF Core would be to log a warning when client evaluation is performed.
                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                //Check Client vs. Server evaluation: https://docs.microsoft.com/en-us/ef/core/querying/client-eval
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
            });


            services.AddDbContext<IntegrationEventLogContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionString"],
                                 mySqlOptionsAction: sqlOptions =>
                                 {
                                     sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                     //sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                 });

                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            });
            //services.AddMemoryCache();
    
            RegisterAppInsights(services);

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

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices()
            //全局配置Json序列化处理
            .AddJsonOptions(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            }); ;

            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new MySQLIntegrationEventLogService(c));
            
            services.AddTransient<IIntegrationEventService, IntegrationEventService>();


            services.AddAutoMapperSetup();

            services.AddRabbitMQEventBusSetup(Configuration);

            services.AddApplicationSetup();

            services.AddSwaggerSupport();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
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

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book2 API V1");
                //c.ShowRequestHeaders();
            });

            app.UseMvc();
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
            //    services.AddSingleton<ITelemetryInitializer>((serviceProvider) =>
            //        new FabricTelemetryInitializer());
            //}
        }

        #endregion
    }
}
