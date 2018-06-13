﻿// <auto-generated />
using Business.Domain.Models;
using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Business.Infra.Data.Migrations
{
    [DbContext(typeof(BusinessDbContext))]
    partial class BusinessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Business.Domain.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EquivalentLocaleName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RegionString")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Business.Domain.Models.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("IsLocatedAtAllLocations");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ResourceTypeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("char(36)");

                    b.Property<int>("StatusId");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ResourceTypeId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TenantId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("Business.Domain.Models.ResourceLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id", "ResourceId", "LocationId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("TenantId");

                    b.ToTable("ResourceLocation");
                });

            modelBuilder.Entity("Business.Domain.Models.ResourceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ResourceStatus");
                });

            modelBuilder.Entity("Business.Domain.Models.ResourceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("ResourceType");
                });

            modelBuilder.Entity("Business.Domain.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("DaysVisible");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<bool>("IsCalendarSubscriptionAllowed");

                    b.Property<bool>("IsDefault");

                    b.Property<Guid>("LayoutId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<int>("WeekdayStart");

                    b.HasKey("Id");

                    b.HasIndex("LayoutId");

                    b.HasIndex("TenantId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("Business.Domain.Models.ScheduleLayout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<int>("TimeZoneId");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("TimeZoneId");

                    b.ToTable("ScheduleLayout");
                });

            modelBuilder.Entity("Business.Domain.Models.ScheduleLayoutTimeSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AvailabilityCode");

                    b.Property<int>("DayOfWeek");

                    b.Property<string>("EndLabel")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Label")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("LayoutId")
                        .HasColumnType("char(36)");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LayoutId");

                    b.HasIndex("TenantId");

                    b.ToTable("ScheduleLayoutTimeSlot");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.Branding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("LogoURL")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PageColor1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor2")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor3")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor4")
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("Branding");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.LocationAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ForeignZip")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Latitude");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Longitude");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Street2")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("LocationAddress");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.LocationContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email2")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone2")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone3")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("LocationContact");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.LocationImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TenantId");

                    b.ToTable("LocationImage");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bio");

                    b.Property<bool>("CanLoginAllLocations");

                    b.Property<string>("DisplayName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsMale");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ForeignZip")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("char(36)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Street2")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("StaffAddress");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email2")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone2")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone3")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("StaffContact");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffLoginCredential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("StaffLoginCredential");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffLoginLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id", "StaffId", "LocationId");

                    b.HasIndex("LocationId");

                    b.HasIndex("StaffId");

                    b.HasIndex("TenantId");

                    b.ToTable("StaffLoginLocation");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.TenantAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ForeignZip")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Street2")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("TenantAddress");
                });

            modelBuilder.Entity("Business.Domain.Models.Security.TenantContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email2")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone2")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone3")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("TenantContact");
                });

            modelBuilder.Entity("Business.Domain.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TenantId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Business.Domain.Models.ServiceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CancelOffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ScheduleType");

                    b.Property<int>("ScheduleTypeValue");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategory");
                });

            modelBuilder.Entity("Business.Domain.Models.TimeZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StandardName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TimeZone");
                });

            modelBuilder.Entity("Business.Domain.Models.Resource", b =>
                {
                    b.HasOne("Business.Domain.Models.ResourceType", "ResourceType")
                        .WithMany("Resources")
                        .HasForeignKey("ResourceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.ResourceStatus", "Status")
                        .WithMany("Resources")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.ResourceLocation", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Location", "Location")
                        .WithMany("ResourceLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Resource", "Resource")
                        .WithMany("ResourceLocations")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.ResourceType", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Schedule", b =>
                {
                    b.HasOne("Business.Domain.Models.ScheduleLayout", "Layout")
                        .WithMany("Schedules")
                        .HasForeignKey("LayoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.ScheduleLayout", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.TimeZone", "TimeZone")
                        .WithMany("ScheduleLayouts")
                        .HasForeignKey("TimeZoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.ScheduleLayoutTimeSlot", b =>
                {
                    b.HasOne("Business.Domain.Models.ScheduleLayout", "Layout")
                        .WithMany("TimeSlots")
                        .HasForeignKey("LayoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.Branding", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithOne("Branding")
                        .HasForeignKey("Business.Domain.Models.Security.Branding", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.Location", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany("Locations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.LocationAddress", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Location", "Location")
                        .WithOne("Address")
                        .HasForeignKey("Business.Domain.Models.Security.LocationAddress", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.LocationContact", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Location", "Location")
                        .WithOne("Contact")
                        .HasForeignKey("Business.Domain.Models.Security.LocationContact", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.LocationImage", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Location", "Location")
                        .WithMany("AdditionalLocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.Staff", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany("Staffs")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffAddress", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Staff", "Staff")
                        .WithOne("Address")
                        .HasForeignKey("Business.Domain.Models.Security.StaffAddress", "StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffContact", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Staff", "Staff")
                        .WithOne("Contact")
                        .HasForeignKey("Business.Domain.Models.Security.StaffContact", "StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffLoginCredential", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Staff", "Staff")
                        .WithOne("LoginCredential")
                        .HasForeignKey("Business.Domain.Models.Security.StaffLoginCredential", "StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.StaffLoginLocation", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Location", "Location")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Staff", "Staff")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.TenantAddress", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithOne("Address")
                        .HasForeignKey("Business.Domain.Models.Security.TenantAddress", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Security.TenantContact", b =>
                {
                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithOne("Contact")
                        .HasForeignKey("Business.Domain.Models.Security.TenantContact", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Business.Domain.Models.Service", b =>
                {
                    b.HasOne("Business.Domain.Models.ServiceCategory", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Domain.Models.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
