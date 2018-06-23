﻿using System;
using System.IO;
using System.Linq;
using Business.Domain.Models;
using Business.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.Infra.Data.Context
{
    public class BusinessDbContext : DbContext
    {

        //public DbSet<TenantAddress> TenantAddresses { get; set; }
        //public DbSet<TenantContact> TenantContacts { get; set; }

        //public DbSet<ServiceCategory> ServiceCategories { get; set; }
        //public DbSet<Service> Services { get; set; }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Domain.Models.TimeZone> TimeZones { get; set; }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Branding> Brandings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        //public DbSet<Resource> Resources { get; set; }
        //public DbSet<ResourceType> ResourceTypes { get; set; }

        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<ScheduleLayout> ScheduleLayouts { get; set; }
        //public DbSet<ScheduleLayoutTimeSlot> ScheduleLayoutTimeSlots { get; set; }


        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
        {
            //Database.SetInitializer<BusinessDbContext>(null);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandingMap());
            modelBuilder.ApplyConfiguration(new SiteMap());
            //modelBuilder.ApplyConfiguration(new TenantContactMap());

            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new LocationAddressMap());
            modelBuilder.ApplyConfiguration(new LocationImageMap());

            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new StaffLoginLocationMap());

            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new TimeZoneMap());

            //modelBuilder.ApplyConfiguration(new ResourceMap());
            //modelBuilder.ApplyConfiguration(new ResourceStatusMap());
            //modelBuilder.ApplyConfiguration(new ResourceTypeMap());
            //modelBuilder.ApplyConfiguration(new ResourceLocationMap());

            //modelBuilder.ApplyConfiguration(new ScheduleMap());
            //modelBuilder.ApplyConfiguration(new ScheduleLayoutMap());
            //modelBuilder.ApplyConfiguration(new ScheduleLayoutTimeSlotMap());

            //modelBuilder.ApplyConfiguration(new ServiceMap());
            //modelBuilder.ApplyConfiguration(new ServiceCategoryMap());

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(entityType.Name).Property<DateTime>
            //      ("LastModified");
            //    modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
            //}
        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries()
        //      .Where(e => e.State == EntityState.Added ||
        //       e.State == EntityState.Modified))
        //    {
        //        if (!(entry.Entity is PersonFullName))
        //            entry.Property("LastModified").CurrentValue = DateTime.Now;
        //    }
        //    return base.SaveChanges();
        //}
    }
}
