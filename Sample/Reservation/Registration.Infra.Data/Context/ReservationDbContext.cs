using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Registration.Domain.ReadModel;
using Registration.Domain.ReadModel.Security;
using Registration.Infra.Data.Mappings;

namespace Registration.Infra.Data.Context
{
    
    public class ReservationDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Domain.ReadModel.TimeZone> TimeZones { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());
            modelBuilder.ApplyConfiguration(new LocationImageMap());
            modelBuilder.ApplyConfiguration(new StaffLoginLocationMap());
            //modelBuilder.ApplyConfiguration(new StaffLoginCredentialMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());
            modelBuilder.ApplyConfiguration(new RegionMap());
        }
    }
}
