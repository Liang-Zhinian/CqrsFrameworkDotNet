﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SaaSEqt.eShop.Site.Api.Infrastructure.Context;
using System;

namespace Site.Api.Migrations
{
    [DbContext(typeof(SiteDbContext))]
    partial class SiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("book2")
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Branding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Logo")
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

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.LocationImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Image");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SiteId");

                    b.ToTable("LocationImage");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Site", b =>
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

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Staff", b =>
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

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.StaffLoginLocation", b =>
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

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Branding", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Site", "Site")
                        .WithOne("Branding")
                        .HasForeignKey("SaaSEqt.eShop.Site.Api.Model.Branding", "SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Location", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Site", "Site")
                        .WithMany("Locations")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SaaSEqt.eShop.Site.Api.Model.ContactInformation", "ContactInformation", b1 =>
                        {
                            b1.Property<Guid?>("LocationId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("ContactName")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PrimaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("SecondaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Location","book2");

                            b1.HasOne("SaaSEqt.eShop.Site.Api.Model.Location")
                                .WithOne("ContactInformation")
                                .HasForeignKey("SaaSEqt.eShop.Site.Api.Model.ContactInformation", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SaaSEqt.eShop.Site.Api.Model.Geolocation", "Geolocation", b1 =>
                        {
                            b1.Property<Guid>("LocationId")
                                .HasColumnType("char(36)");

                            b1.Property<double?>("Latitude");

                            b1.Property<double?>("Longitude");

                            b1.ToTable("Location","book2");

                            b1.HasOne("SaaSEqt.eShop.Site.Api.Model.Location")
                                .WithOne("Geolocation")
                                .HasForeignKey("SaaSEqt.eShop.Site.Api.Model.Geolocation", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SaaSEqt.eShop.Site.Api.Model.PostalAddress", "PostalAddress", b1 =>
                        {
                            b1.Property<Guid>("LocationId")
                                .HasColumnType("char(36)");

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

                            b1.Property<string>("StreetAddress2");

                            b1.ToTable("Location","book2");

                            b1.HasOne("SaaSEqt.eShop.Site.Api.Model.Location")
                                .WithOne("PostalAddress")
                                .HasForeignKey("SaaSEqt.eShop.Site.Api.Model.PostalAddress", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.LocationImage", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Location", "Location")
                        .WithMany("AdditionalLocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Site", b =>
                {
                    b.OwnsOne("SaaSEqt.eShop.Site.Api.Model.ContactInformation", "ContactInformation", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("ContactName")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PrimaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("SecondaryTelephone")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Site","book2");

                            b1.HasOne("SaaSEqt.eShop.Site.Api.Model.Site")
                                .WithOne("ContactInformation")
                                .HasForeignKey("SaaSEqt.eShop.Site.Api.Model.ContactInformation", "SiteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.Staff", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Site", "Site")
                        .WithMany("Staffs")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Site.Api.Model.StaffLoginLocation", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Location", "Location")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSEqt.eShop.Site.Api.Model.Staff", "Staff")
                        .WithMany("StaffLoginLocations")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
