using CqrsFramework.Bus;
using CqrsFramework.Cache;
using CqrsFramework.Commands;
using CqrsFramework.Config;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scrutor;
using Business.Api.Code;
using Registration.Domain.ReadModel;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using CqrsFramework.EventStore.MongoDB;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Business.Domain.CommandHandlers.Security;
using Registration.Infra.Data.Context;
using Registration.Domain.Repositories.Interfaces;
using Registration.Infra.Data.Repositories;
using Business.Application.Services.Security;
using Business.Application.Interfaces;
using Business.Api.Configurations;
using Registration.Domain.EventHandlers.Security;
using System;

namespace Business.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<Book2DbContext>(options =>
                //options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));//添加Mysql支持



            // Add framework services.
            services.AddMvc()
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


            ConfigureCqrs(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        public void ConfigureCqrs(IServiceCollection services)
        {
            services.AddMemoryCache();

            //Add Cqrs services
            ConfigureCqrsFramework(services);

            // event store
            RegisterEventStore(services);

            //Scan for commandhandlers and eventhandlers
            RegisterCommandHandlers(services);
            RegisterEventHandlers(services);

            // App service
            RegisterAppService(services);

            // Infra - Data
            RegisterReadDb(services);

            //Register bus
            var serviceProvider = services.BuildServiceProvider();
            var registrar = new BusRegistrar(new DependencyResolver(serviceProvider));
            registrar.Register(typeof(StaffCommandHandler));
            registrar.Register(typeof(TenantEventHandler));


            services.AddAutoMapperSetup();


            //var events = ((SqlEventStore)serviceProvider.GetService<IEventStore>()).GetAllEventsEver();
            //var publisher = serviceProvider.GetService<IEventPublisher>();
            //foreach (var @event in events)
            //{
            //    publisher.Publish<IEvent>((IEvent)@event);
            //}

            //var events = ((MongoEventStore)serviceProvider.GetService<IEventStore>()).GetAllEventsEver();
            //var publisher = serviceProvider.GetService<IEventPublisher>();
            //foreach (var @event in events)
            //{
            //    publisher.Publish<IEvent>((IEvent)@event);
            //}
        }

        private void ConfigureCqrsFramework(IServiceCollection services)
        {
            services.AddSingleton<InProcessBus>(new InProcessBus());
            services.AddSingleton<ICommandSender>(y => y.GetService<InProcessBus>());
            services.AddSingleton<IEventPublisher>(y => y.GetService<InProcessBus>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<InProcessBus>());
            services.AddScoped<ISession, Session>();
        }

        private void RegisterReadDb(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<Book2DbContext>(options => options.UseMySQL(connection));


            services.AddTransient<Book2DbContext>();
            //services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();
            services.AddTransient<IReadModelFacade, ReadModelFacade>();
        }

        private void RegisterAppService(IServiceCollection services)
        {
            // App service
            services.AddScoped<ITenantAppService, TenantService>();
        }

        private void RegisterCommandHandlers(IServiceCollection services){
            services.Scan(scan => scan
                          .FromAssemblies(typeof(StaffCommandHandler).GetTypeInfo().Assembly)
                    .AddClasses(classes => classes.Where(x =>
                    {
                        var allInterfaces = x.GetInterfaces();
                        return
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && (y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICommandHandler<>))) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && (y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IEventHandler<>)));
                    }))
                    .AsSelf()
                    .WithTransientLifetime()
                         );
        }

        private void RegisterEventHandlers(IServiceCollection services) { 

            services.Scan(scan => scan
                          .FromAssemblies(typeof(TenantEventHandler).GetTypeInfo().Assembly)
                    .AddClasses(classes => classes.Where(x =>
                    {
                        var allInterfaces = x.GetInterfaces();
                        return
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && (y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICommandHandler<>))) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && (y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IEventHandler<>)));
                    }))
                    .AsSelf()
                    .WithTransientLifetime()
            );
        }

        private void RegisterEventStore(IServiceCollection services){
            //string connectionString = Configuration.GetConnectionString("SqlEventStore");
            //services.AddSingleton<IEventStore>(y => new SqlEventStore(y.GetService<InProcessBus>(), connectionString));

            // InMemoryEventStore
            services.AddSingleton<IEventStore>(y => new InMemoryEventStore(y.GetService<InProcessBus>()));

            // MongoDbEventStore
            //string connectionString = Configuration.GetConnectionString("MongoDbEventStore");
            //services.AddSingleton<IEventStore>(y => new MongoEventStore(connectionString));

            //string connectionString = Configuration.GetConnectionString("MongoDbEventStore");
            //services.AddSingleton<IEventStore>(y => new MongoDBEventStore(y.GetService<InProcessBus>(), connectionString));

            services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>(), y.GetService<IEventPublisher>()), y.GetService<IEventStore>()));

        }
    }
}
