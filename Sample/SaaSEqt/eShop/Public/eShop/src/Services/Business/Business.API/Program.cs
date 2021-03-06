﻿using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SaaSEqt.eShop.BuildingBlocks.IntegrationEventLogEF;
using SaaSEqt.eShop.Services.Business.API.Infrastructure;
using SaaSEqt.eShop.Services.Business.Infrastructure;

namespace SaaSEqt.eShop.Services.Business.API
{
    public class Program
    {
        public static void Main(string[] args)
        {         
			BuildWebHost(args)
                .MigrateDbContext<BusinessDbContext>((context,services)=>
                {
                    var env = services.GetService<IHostingEnvironment>();
                    var settings = services.GetService<IOptions<BusinessSettings>>();
                    var logger = services.GetService<ILogger<BusinessDbContextSeed>>();

                    new BusinessDbContextSeed()
                        .SeedAsync(context, env, settings, logger)
                        .Wait();

                })
                .MigrateDbContext<IntegrationEventLogContext>((_,__)=> { })
				.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   //.UseUrls("http://*:8081")
		           .UseStartup<Startup>()
		           .UseApplicationInsights()
                .UseHealthChecks("/hc")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot("Pics")
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    builder.AddConsole();
                    builder.AddDebug();
                })                
                .Build();
    }
}
