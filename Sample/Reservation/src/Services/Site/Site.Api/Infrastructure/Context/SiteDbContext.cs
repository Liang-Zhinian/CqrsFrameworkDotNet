using System;
using System.IO;
using System.Linq;
using SaaSEqt.eShop.Site.Api.Model;
using SaaSEqt.eShop.Site.Api.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SaaSEqt.eShop.Site.Api.Infrastructure.Context
{
    public class SiteDbContext : DbContext
    {
        public DbSet<Model.Site> Sites { get; set; }
        public DbSet<Branding> Brandings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected SiteDbContext()
        {

        }

        public SiteDbContext(DbContextOptions<SiteDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DbConstants.Schema);

            modelBuilder.ApplyConfiguration(new BrandingMap());
            modelBuilder.ApplyConfiguration(new SiteMap());

            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new LocationImageMap());

            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new StaffLoginLocationMap());


            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(entityType.Name).Property<DateTime>
            //      ("LastModified");
            //    //modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
            //}
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
