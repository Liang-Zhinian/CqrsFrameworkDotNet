using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Registration.Infra.Data.Mappings;
using System.Configuration;
using System.Reflection;
using System.Linq;
using Registration.Domain.ReadModel;
using Registration.Domain.ReadModel.Security;

namespace Registration.Infra.Data.Context
{

    public static class DataBaseServer
    {
        public static readonly string SqlServer = "SqlServer";
        public static readonly string MySql = "MySql";
    }

    public static class DbContextOptionsBuilderExt
    {
        public static DbContextOptionsBuilder UseFarmDatabase(this DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            string provider = configuration.GetConnectionString("DataProvider"), 
                connection = configuration.GetConnectionString("ConnectionString");
            if (provider.Equals(DataBaseServer.SqlServer, StringComparison.InvariantCultureIgnoreCase))
            {
                return optionsBuilder.UseSqlServer(connection);
            }
            else if (provider.Equals(DataBaseServer.MySql, StringComparison.InvariantCultureIgnoreCase))
            {
                return optionsBuilder.UseMySQL(connection);
            }
            else
            {
                throw new Exception("No databaseProvider");
            }
        }
    }

    //[DbConfigurationType(typeof(MySqlEFConfiguration))] // this attribute is must
    public class Book2DbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Domain.ReadModel.TimeZone> TimeZones { get; set; }
        public DbSet<Branding> Brandings { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandingMap());
            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new TenantAddressMap());
            modelBuilder.ApplyConfiguration(new TenantContactMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());
            modelBuilder.ApplyConfiguration(new LocationAddressMap());
            modelBuilder.ApplyConfiguration(new LocationContactMap());
            modelBuilder.ApplyConfiguration(new LocationImageMap());
            modelBuilder.ApplyConfiguration(new StaffAddressMap());
            modelBuilder.ApplyConfiguration(new StaffContactMap());
            modelBuilder.ApplyConfiguration(new StaffLoginLocationMap());
            modelBuilder.ApplyConfiguration(new StaffLoginCredentialMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());

            base.OnModelCreating(modelBuilder);
            /*
            var mappingInterface = typeof(IEntityTypeConfiguration<>);
            // Types that do entity mapping
            var mappingTypes = GetType().GetTypeInfo().Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));

            // Get the generic Entity method of the ModelBuilder type
            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(x => x.Name == "Entity" &&
                        x.IsGenericMethod &&
                        x.ReturnType.Name == "EntityTypeBuilder`1");

            foreach (var mappingType in mappingTypes)
            {

                // Get the type of entity to be mapped
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();

                // Get the method builder.Entity<TEntity>
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);

                // Invoke builder.Entity<TEntity> to get a builder for the entity to be mapped
                var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);

                // Create the mapping type and do the mapping
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
            }
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //string connectionString = config.GetConnectionString("ConnectionString");
            // define the database to use
            //optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseMySQL(connectionString);

            optionsBuilder.UseFarmDatabase(config);
        }

    }
}
