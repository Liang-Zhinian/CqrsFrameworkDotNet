using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaaSEqt.BizInfo.MigrationMappings;

namespace SaaSEqt.BizInfo
{
    public class BizInfoDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<SaaSEqt.BizInfo.TimeZone> TimeZones { get; set; }

        public DbSet<Branding> Brandings { get; set; }
        //public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Location> Locations { get; set; }

        public BizInfoDbContext(DbContextOptions<BizInfoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new BrandingMap());
            modelBuilder.ApplyConfiguration(new LocationImageMap());
            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());
        }

    }
}
