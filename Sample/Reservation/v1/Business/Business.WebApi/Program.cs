using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Infra.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using CqrsFramework.EventStore.IntegrationEventLogEF;

namespace Business.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {         
			BuildWebHost(args)
                .MigrateDbContext<BusinessDbContext>((context,services)=>
                {
                    var env = services.GetService<IHostingEnvironment>();
                    var logger = services.GetService<ILogger<BusinessDbContextSeed>>();

                    new BusinessDbContextSeed()
                    .SeedAsync(context,logger)
                    .Wait();

                })
                .MigrateDbContext<IntegrationEventLogContext>((_,__)=> { })
				.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   //.UseUrls("http://*:60000")
		           .UseStartup<Startup>()
		           .UseApplicationInsights()
                .UseHealthChecks("/hc")
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseWebRoot("Pics")
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
