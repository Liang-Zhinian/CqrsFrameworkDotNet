﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Registration.Infra.Data.Context;
using System;

namespace Registration.Infra.Data.Migrations
{
    [DbContext(typeof(ReservationDbContext))]
    partial class ReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("book2")
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Registration.Domain.ReadModel.HomePageImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("binary(16)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("mediumtext");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ParentCategoryId")
                        .HasColumnType("binary(16)");

                    b.Property<string>("ParentCategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("V_HomePageImage");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EquivalentLocaleName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("RegionString")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("V_Region");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("Image");

                    b.Property<DateTime>("LastModified");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PrimaryTelephone")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SecondaryTelephone")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("SiteId")
                        .HasColumnType("binary(16)");

                    b.Property<string>("StateProvince")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StreetAddress2")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("binary(16)");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("TenantId");

                    b.ToTable("V_Location");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.LocationImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastModified");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("SiteId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("binary(16)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SiteId");

                    b.HasIndex("TenantId");

                    b.ToTable("V_LocationImage");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<bool>("Active");

                    b.Property<string>("ContactName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastModified");

                    b.Property<byte[]>("Logo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<string>("PageColor1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor2")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor3")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor4")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PrimaryTelephone")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<string>("SecondaryTelephone")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<Guid>("TenantId")
                        .HasColumnType("binary(16)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("V_Site");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("Bio")
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("CanLoginAllLocations");

                    b.Property<string>("City")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varchar(4000)");

                    b.Property<bool>("IsEnabled");

                    b.Property<bool>("IsMale");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PrimaryTelephone")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SecondaryTelephone")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("SiteId")
                        .HasColumnType("binary(16)");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StateProvince")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StreetAddress2")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("binary(16)");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("TenantId");

                    b.ToTable("V_Staff");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.StaffLoginLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("binary(16)");

                    b.Property<DateTime>("LastModified");

                    b.Property<Guid>("SiteId");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id", "StaffId", "LocationId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SiteId");

                    b.HasIndex("StaffId");

                    b.HasIndex("TenantId");

                    b.ToTable("V_StaffLoginLocation");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastModified");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<string>("PageColor1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor2")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor3")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PageColor4")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PrimaryTelephone")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<string>("SecondaryTelephone")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<string>("StateProvince")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StreetAddress2")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("V_Tenant");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("binary(16)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("SiteId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("binary(16)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SiteId");

                    b.HasIndex("TenantId");

                    b.ToTable("V_Service");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.ServiceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("binary(16)");

                    b.Property<int>("CancelOffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("IsInternal");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ParentCategoryId")
                        .HasColumnType("binary(16)");

                    b.Property<int>("ScheduleTypeValue");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("SiteId")
                        .HasColumnType("binary(16)");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasColumnType("binary(16)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("V_ServiceCategory");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.TimeZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("StandardName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("V_TimeZone");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.HomePageImage", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.ServiceCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.ServiceCategory", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Location", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany("Locations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.LocationImage", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Location", "Location")
                        .WithMany("AdditionalLocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Site", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Staff", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany("Staffs")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.StaffLoginLocation", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Location", "Location")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Staff", "Staff")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Service", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.ServiceCategory", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.ServiceCategory", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.ServiceCategory", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}