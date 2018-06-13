using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Business.Infra.Data.Mappings;
using System.Configuration;
using System.Reflection;
using System.Linq;
using Business.Domain.Models;
using Business.Domain.Models.Security;

namespace Business.Infra.Data.Context
{
    public class TestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

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
                return optionsBuilder.UseMySql(connection);
            }
            else
            {
                throw new Exception("No databaseProvider");
            }
        }
    }

    //[DbConfigurationType(typeof(MySqlEFConfiguration))] // this attribute is must
    public class BusinessDbContext : DbContext
    {
        //public DbSet<TestModel> TestModels { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Business.Domain.Models.TimeZone> TimeZones { get; set; }

        public DbSet<Branding> Brandings { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleLayout> ScheduleLayouts { get; set; }

        //public Book2DbContext(DbContextOptions<Book2DbContext> options) : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new BrandingMap());
            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new TenantAddressMap());
            modelBuilder.ApplyConfiguration(new TenantContactMap());

            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new LocationAddressMap());
            modelBuilder.ApplyConfiguration(new LocationContactMap());
            modelBuilder.ApplyConfiguration(new LocationImageMap());

            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new StaffAddressMap());
            modelBuilder.ApplyConfiguration(new StaffContactMap());
            modelBuilder.ApplyConfiguration(new StaffLoginLocationMap());
            modelBuilder.ApplyConfiguration(new StaffLoginCredentialMap());

            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());

            modelBuilder.ApplyConfiguration(new ResourceMap());
            modelBuilder.ApplyConfiguration(new ResourceStatusMap());
            modelBuilder.ApplyConfiguration(new ResourceTypeMap());
            modelBuilder.ApplyConfiguration(new ResourceLocationMap());

            modelBuilder.ApplyConfiguration(new ScheduleMap());
            modelBuilder.ApplyConfiguration(new ScheduleLayoutMap());
            modelBuilder.ApplyConfiguration(new ScheduleLayoutTimeSlotMap());


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestModel>().HasKey(o => o.Id);
            modelBuilder.Entity<TestModel>().ToTable("TestTable");

            modelBuilder.Entity<TestModel>()
                        .Property("Id")
                        .HasColumnType("binary(16)");
            modelBuilder.Entity<TestModel>()
                        .Property<string>("Name")
                        .IsRequired()
                        .HasColumnType(Constants.DbConstants.String255);
            modelBuilder.Entity<TestModel>()
                        .Property<string>("Description")
                        .HasColumnType(Constants.DbConstants.String2000);


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

            optionsBuilder.UseFarmDatabase(config);
        }

    }
}
