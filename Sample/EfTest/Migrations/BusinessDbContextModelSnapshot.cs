﻿// <auto-generated />
using System;
using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfTest.Migrations
{
    [DbContext(typeof(BusinessDbContext))]
    partial class BusinessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Business.Infra.Data.Context.Branding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("SiteId");

                    b.HasKey("Id");

                    b.HasIndex("SiteId")
                        .IsUnique();

                    b.ToTable("Brandings");
                });

            modelBuilder.Entity("Business.Infra.Data.Context.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Business.Infra.Data.Context.Branding", b =>
                {
                    b.HasOne("Business.Infra.Data.Context.Site")
                        .WithOne("Branding")
                        .HasForeignKey("Business.Infra.Data.Context.Branding", "SiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Business.Infra.Data.Context.TenantId", "TenantId", b1 =>
                        {
                            b1.Property<Guid>("BrandingId");

                            b1.Property<string>("Id")
                                .HasColumnType("varchar(36)");

                            b1.ToTable("Brandings");

                            b1.HasOne("Business.Infra.Data.Context.Branding")
                                .WithOne("TenantId")
                                .HasForeignKey("Business.Infra.Data.Context.TenantId", "BrandingId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Business.Infra.Data.Context.Site", b =>
                {
                    b.OwnsOne("Business.Infra.Data.Context.TenantId", "TenantId", b1 =>
                        {
                            b1.Property<Guid>("SiteId");

                            b1.Property<string>("Id")
                                .HasColumnType("varchar(36)");

                            b1.ToTable("Sites");

                            b1.HasOne("Business.Infra.Data.Context.Site")
                                .WithOne("TenantId")
                                .HasForeignKey("Business.Infra.Data.Context.TenantId", "SiteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}