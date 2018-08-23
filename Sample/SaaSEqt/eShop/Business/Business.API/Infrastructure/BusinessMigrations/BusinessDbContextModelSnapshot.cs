﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SaaSEqt.eShop.Business.Infrastructure.Data;
using System;

namespace SaaSEqt.eShop.Business.API.Infrastructure.BusinessMigrations
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

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.Availability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BookableEndDateTime");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<bool>("Friday");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Monday");

                    b.Property<bool>("Saturday");

                    b.Property<Guid>("ServiceItemId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SiteId");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<bool>("Sunday");

                    b.Property<bool>("Thursday");

                    b.Property<bool>("Tuesday");

                    b.Property<bool>("Wednesday");

                    b.HasKey("Id");

                    b.HasIndex("ServiceItemId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.ScheduleType", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ScheduleType");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.ServiceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("AllowOnlineScheduling");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ScheduleTypeId");

                    b.Property<Guid>("SiteId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleTypeId");

                    b.ToTable("ServiceCategory");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.ServiceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("AllowOnlineScheduling");

                    b.Property<int>("DefaultTimeLength");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("IndustryStandardCategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IndustryStandardSubcategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Price");

                    b.Property<Guid>("ServiceCategoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.Property<double>("TaxRate");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("ServiceItem");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.Unavailability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<bool>("Friday");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Monday");

                    b.Property<bool>("Saturday");

                    b.Property<Guid>("ServiceItemId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SiteId");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<bool>("Sunday");

                    b.Property<bool>("Thursday");

                    b.Property<bool>("Tuesday");

                    b.Property<bool>("Wednesday");

                    b.HasKey("Id");

                    b.HasIndex("ServiceItemId");

                    b.ToTable("Unavailability");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Categories.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Subcategory");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Branding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Logo")
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("PageColor1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor2")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor3")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor4")
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SiteId")
                        .IsUnique();

                    b.ToTable("Branding");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.LocationImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SiteId");

                    b.ToTable("LocationImage");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bio")
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("CanLoginAllLocations");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(4000)");

                    b.Property<bool>("IsMale");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.StaffLoginLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StaffId");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id", "StaffId", "LocationId");

                    b.HasIndex("LocationId");

                    b.HasIndex("SiteId");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffLoginLocation");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.Availability", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Catalog.ServiceItem", "ServiceItem")
                        .WithMany("Availibilities")
                        .HasForeignKey("ServiceItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.ServiceCategory", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Catalog.ScheduleType", "ScheduleType")
                        .WithMany()
                        .HasForeignKey("ScheduleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.ServiceItem", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Catalog.ServiceCategory", "ServiceCategory")
                        .WithMany()
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Catalog.Unavailability", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Catalog.ServiceItem", "ServiceItem")
                        .WithMany("Unavailabilities")
                        .HasForeignKey("ServiceItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Branding", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Site", "Site")
                        .WithOne("Branding")
                        .HasForeignKey("SaaSEqt.eShop.Business.Domain.Model.Security.Branding", "SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Location", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Site", "Site")
                        .WithMany("Locations")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SaaSEqt.eShop.Business.Domain.Model.Security.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("LocationId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Country")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StateProvince")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Street")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Location");

                            b1.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Location")
                                .WithOne("Address")
                                .HasForeignKey("SaaSEqt.eShop.Business.Domain.Model.Security.Address", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SaaSEqt.eShop.Business.Domain.Model.Security.ContactInformation", "ContactInformation", b1 =>
                        {
                            b1.Property<Guid?>("LocationId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("ContactName")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("EmailAddress")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PrimaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("SecondaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Location");

                            b1.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Location")
                                .WithOne("ContactInformation")
                                .HasForeignKey("SaaSEqt.eShop.Business.Domain.Model.Security.ContactInformation", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SaaSEqt.eShop.Business.Domain.Model.Security.Geolocation", "Geolocation", b1 =>
                        {
                            b1.Property<Guid>("LocationId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.ToTable("Location");

                            b1.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Location")
                                .WithOne("Geolocation")
                                .HasForeignKey("SaaSEqt.eShop.Business.Domain.Model.Security.Geolocation", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.LocationImage", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Location", "Location")
                        .WithMany("AdditionalLocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Site", b =>
                {
                    b.OwnsOne("SaaSEqt.eShop.Business.Domain.Model.Security.ContactInformation", "ContactInformation", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("ContactName")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("EmailAddress")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PrimaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("SecondaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Site");

                            b1.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Site")
                                .WithOne("ContactInformation")
                                .HasForeignKey("SaaSEqt.eShop.Business.Domain.Model.Security.ContactInformation", "SiteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.Staff", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Site", "Site")
                        .WithMany("Staffs")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Business.Domain.Model.Security.StaffLoginLocation", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSEqt.eShop.Business.Domain.Model.Security.Staff", "Staff")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
