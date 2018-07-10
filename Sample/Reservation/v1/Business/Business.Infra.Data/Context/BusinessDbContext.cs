using Business.Domain.Entities;
using Business.Domain.Entities.Schedules;
using Business.Domain.Entities.ServiceCategories;
using Business.Domain.UoW;
using Business.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Business.Infra.Data.Context
{
    public class BusinessDbContext : DbContext, IUnitOfWork
    {

        //public DbSet<TenantAddress> TenantAddresses { get; set; }
        //public DbSet<TenantContact> TenantContacts { get; set; }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Domain.Entities.TimeZone> TimeZones { get; set; }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Branding> Brandings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }

        public DbSet<ScheduleType> ScheduleTypes { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Unavailability> Unavailabilities { get; set; }


        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<ScheduleLayout> ScheduleLayouts { get; set; }
        //public DbSet<ScheduleLayoutTimeSlot> ScheduleLayoutTimeSlots { get; set; }

        protected BusinessDbContext()
        {

        }

        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
        {
            //Database.SetInitializer<BusinessDbContext>(null);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DbConstants.Schema);

            //modelBuilder.EnableSensitiveDataLogging = true;
            modelBuilder.ApplyConfiguration(new BrandingMap());
            modelBuilder.ApplyConfiguration(new SiteMap());
            //modelBuilder.ApplyConfiguration(new TenantContactMap());

            modelBuilder.ApplyConfiguration(new LocationMap());
            //modelBuilder.ApplyConfiguration(new LocationAddressMap());
            modelBuilder.ApplyConfiguration(new LocationImageMap());

            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new StaffLoginLocationMap());

            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());

            modelBuilder.ApplyConfiguration(new ResourceMap());
            modelBuilder.ApplyConfiguration(new ResourceStatusMap());
            modelBuilder.ApplyConfiguration(new ResourceTypeMap());
            modelBuilder.ApplyConfiguration(new ResourceLocationMap());

            //modelBuilder.ApplyConfiguration(new ScheduleMap());
            //modelBuilder.ApplyConfiguration(new ScheduleLayoutMap());
            //modelBuilder.ApplyConfiguration(new ScheduleLayoutTimeSlotMap());

            modelBuilder.ApplyConfiguration(new ServiceItemMap());
            modelBuilder.ApplyConfiguration(new ServiceCategoryMap());

            modelBuilder.ApplyConfiguration(new ScheduleTypeMap());

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(entityType.Name).Property<DateTime>
            //      ("LastModified");
            //    //modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
            //}
        }

        public bool Commit()
        {
            var result = this.SaveChanges();

            return true;
        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries()
        //      .Where(e => e.State == EntityState.Added ||
        //       e.State == EntityState.Modified))
        //    {
        //        if (!(entry.Entity is ContactInformation) &&
        //            !(entry.Entity is PostalAddress) &&
        //            !(entry.Entity is DateTimeSlot) &&
        //            !(entry.Entity is Geolocation) &&
        //            !(entry.Entity is Gender))
        //            entry.Property("LastModified").CurrentValue = DateTime.Now;
        //    }
        //    return base.SaveChanges();
        //}
    }
}
