using System;
using System.IO;
using System.Linq;
using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Registration.Infra.Data.Context;
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
            string provider = config.GetConnectionString("DataProvider"),
                connectionString = config.GetConnectionString("ConnectionString");


            if (args.Length > 0)
            {
                connectionString = args[0];
            }

            // Use ConferenceContext as entry point for dropping and recreating DB
            using (var context = new BusinessDbContext())
            {
                if (context.Database.EnsureDeleted())
                    context.Database.Migrate();
            }

            DbContext[] contexts =
                new DbContext[]
                {
                    new ReservationDbContext(),
                };

            foreach (DbContext context in contexts)
            {
                context.Database.Migrate();

                context.Dispose();
            }
        }
    }
}
