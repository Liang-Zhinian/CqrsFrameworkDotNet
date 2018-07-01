﻿// <auto-generated />
using Catalog.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Catalog.Api.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Catalog.Api.Model.ServiceCategory", b =>
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

                    b.Property<int>("ScheduleTypeId");

                    b.Property<Guid>("SiteId");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategory");
                });

            modelBuilder.Entity("Catalog.Api.Model.ServiceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("DefaultTimeLength");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Descrtiption");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ServiceCategoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("ServiceItem");
                });

            modelBuilder.Entity("Catalog.Api.Model.ServiceItem", b =>
                {
                    b.HasOne("Catalog.Api.Model.ServiceCategory", "ServiceCategory")
                        .WithMany("ServiceItems")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
