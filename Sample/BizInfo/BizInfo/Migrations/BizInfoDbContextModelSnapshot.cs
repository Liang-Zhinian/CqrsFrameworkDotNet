﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using SaaSEqt.BizInfo;
using System;

namespace SaaSEqt.BizInfo.Migrations
{
    [DbContext(typeof(BizInfoDbContext))]
    partial class BizInfoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("SaaSEqt.BizInfo.Branding", b =>
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

                    b.ToTable("Branding");
                });

            modelBuilder.Entity("SaaSEqt.BizInfo.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BusinessDescription")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<Guid>("BusinessID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PrimaryTelephone")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SecondaryTelephone")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("SaaSEqt.BizInfo.LocationImage", b =>
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

                    b.ToTable("LocationImage");
                });

            modelBuilder.Entity("SaaSEqt.BizInfo.Region", b =>
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

            modelBuilder.Entity("SaaSEqt.BizInfo.TimeZone", b =>
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

            modelBuilder.Entity("SaaSEqt.BizInfo.Location", b =>
                {
                    b.OwnsOne("SaaSEqt.BizInfo.PostalAddress", "PostalAddress", b1 =>
                        {
                            b1.Property<Guid>("LocationId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .HasColumnName("City")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("CountryCode")
                                .HasColumnName("CountryCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PostalCode")
                                .HasColumnName("PostalCode")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StateProvince")
                                .HasColumnName("StateProvince")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress")
                                .HasColumnName("StreetAddress")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("StreetAddress2")
                                .HasColumnName("StreetAddress2")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Location");

                            b1.HasOne("SaaSEqt.BizInfo.Location")
                                .WithOne("PostalAddress")
                                .HasForeignKey("SaaSEqt.BizInfo.PostalAddress", "LocationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SaaSEqt.BizInfo.LocationImage", b =>
                {
                    b.HasOne("SaaSEqt.BizInfo.Location", "Location")
                        .WithMany("AdditionalLocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
