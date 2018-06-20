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
    [Migration("20180620084343_updateServices")]
    partial class updateServices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Registration.Domain.ReadModel.HomePageImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("mediumtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ParentCategoryId");

                    b.Property<string>("ParentCategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("HomePageImageView");
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

                    b.Property<string>("RegionString")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("RegionView");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PrimaryTelephone")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SecondaryTelephone")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("LocationView");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.LocationImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TenantId");

                    b.ToTable("LocationImageView");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.Property<string>("Bio")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsEnabled");

                    b.Property<bool>("IsMale");

                    b.Property<string>("Password");

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("StaffView");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.StaffLoginLocation", b =>
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

                    b.HasAlternateKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StaffId");

                    b.HasIndex("TenantId");

                    b.ToTable("StaffLoginLocationView");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<string>("DisplayName")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LogoURL")
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

                    b.Property<string>("PrimaryTelephone")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<string>("SecondaryTelephone")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(100);

                    b.Property<Guid>("TenantId")
                        .HasColumnName("TenantId")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasKey("Id");

                    b.ToTable("TenantView");

                    b.HasAnnotation("MySQL:Charset", "utf8");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Service", b =>
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

                    b.ToTable("ServiceView");
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.ServiceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.Property<int>("CancelOffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("IsInternal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ParentCategoryId");

                    b.Property<int>("ScheduleTypeValue");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ServiceCategoryView");

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

                    b.Property<string>("StandardName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TimeZoneView");
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
                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany("Locations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Registration.Domain.ReadModel.PostalAddress", "PostalAddress", b1 =>
                        {
                            b1.Property<Guid>("LocationId");

                            b1.Property<string>("City")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StateProvince")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("LocationView");

                            b1.HasOne("Registration.Domain.ReadModel.Security.Location")
                                .WithOne("PostalAddress")
                                .HasForeignKey("Registration.Domain.ReadModel.PostalAddress", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.LocationImage", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Location", "Location")
                        .WithMany("AdditionalLocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .HasPrincipalKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Staff", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Tenant", "Tenant")
                        .WithMany("Staffs")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Registration.Domain.ReadModel.Enablement", "Enablement", b1 =>
                        {
                            b1.Property<Guid>("StaffId");

                            b1.Property<bool>("Enabled");

                            b1.Property<DateTime>("EndDate");

                            b1.Property<DateTime>("StartDate");

                            b1.ToTable("StaffView");

                            b1.HasOne("Registration.Domain.ReadModel.Security.Staff")
                                .WithOne("Enablement")
                                .HasForeignKey("Registration.Domain.ReadModel.Enablement", "StaffId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Registration.Domain.ReadModel.PersonalInfo", "PersonalInfo", b1 =>
                        {
                            b1.Property<Guid>("StaffId");

                            b1.Property<string>("Email")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("FirstName")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("LastName")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PrimaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("SecondaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("StaffView");

                            b1.HasOne("Registration.Domain.ReadModel.Security.Staff")
                                .WithOne("PersonalInfo")
                                .HasForeignKey("Registration.Domain.ReadModel.PersonalInfo", "StaffId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Registration.Domain.ReadModel.PostalAddress", "PostalAddress", b1 =>
                        {
                            b1.Property<Guid>("StaffId");

                            b1.Property<string>("City")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StateProvince")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("StaffView");

                            b1.HasOne("Registration.Domain.ReadModel.Security.Staff")
                                .WithOne("PostalAddress")
                                .HasForeignKey("Registration.Domain.ReadModel.PostalAddress", "StaffId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.StaffLoginLocation", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.Security.Location", "Location")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("LocationId")
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

            modelBuilder.Entity("Registration.Domain.ReadModel.Security.Tenant", b =>
                {
                    b.OwnsOne("Registration.Domain.ReadModel.PostalAddress", "PostalAddress", b1 =>
                        {
                            b1.Property<Guid>("TenantId");

                            b1.Property<string>("City")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StateProvince")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("TenantView");

                            b1.HasOne("Registration.Domain.ReadModel.Security.Tenant")
                                .WithOne("PostalAddress")
                                .HasForeignKey("Registration.Domain.ReadModel.PostalAddress", "TenantId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Registration.Domain.ReadModel.Service", b =>
                {
                    b.HasOne("Registration.Domain.ReadModel.ServiceCategory", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
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
