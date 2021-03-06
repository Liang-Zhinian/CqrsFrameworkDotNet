﻿using System;
using System.IO;
using System.Linq;
using Business.Infrastructure.Context;
using CqrsFramework.EventStore.IntegrationEventLogEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Registration.Infrastructure.Context;
using SaaSEqt.IdentityAccess.Infra.Data.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DatabaseInitializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string provider = config["DataProvider"],
                connectionString = config["ConnectionString"];

            var optionsBuilder = new DbContextOptionsBuilder<BusinessDbContext>();
            optionsBuilder.UseMySql(connectionString);
            var reportingDbOptionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
            reportingDbOptionsBuilder.UseMySql(connectionString);
            var identityAccessDbOptionsBuilder = new DbContextOptionsBuilder<IdentityAccessDbContext>();
            identityAccessDbOptionsBuilder.UseMySql(connectionString);
            var eventLogDbOptionsBuilder = new DbContextOptionsBuilder<IntegrationEventLogContext>();
            eventLogDbOptionsBuilder.UseMySql(connectionString);



            if (args.Length > 0)
            {
                connectionString = args[0];
            }

            // Use BusinessDbContext as entry point for dropping and recreating DB
            using (var context = new BusinessDbContext(optionsBuilder.Options))
            {
                if (context.Database.EnsureDeleted())
                    context.Database.Migrate();
            }

            DbContext[] contexts = new DbContext[] {
                    new ReservationDbContext(reportingDbOptionsBuilder.Options),
                    new IdentityAccessDbContext(identityAccessDbOptionsBuilder.Options),
                    new IntegrationEventLogContext(eventLogDbOptionsBuilder.Options),
                };

            foreach (DbContext context in contexts)
            {
                context.Database.Migrate();

                context.Dispose();
            }
        }
    }
}
