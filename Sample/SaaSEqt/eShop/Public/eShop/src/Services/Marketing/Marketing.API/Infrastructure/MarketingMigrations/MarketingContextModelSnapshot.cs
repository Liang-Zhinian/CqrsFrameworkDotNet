﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SaaSEqt.eShop.Services.Marketing.API.Infrastructure;
using System;

namespace SaaSEqt.eShop.Services.Marketing.API.Infrastructure.MarketingMigrations
{
    [DbContext(typeof(MarketingContext))]
    partial class MarketingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("SaaSEqt.eShop.Services.Marketing.API.Model.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<string>("DetailsUri");

                    b.Property<DateTime>("From")
                        .HasColumnName("From");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("PictureName");

                    b.Property<string>("PictureUri")
                        .IsRequired()
                        .HasColumnName("PictureUri");

                    b.Property<DateTime>("To")
                        .HasColumnName("To");

                    b.HasKey("Id");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Services.Marketing.API.Model.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<int>("RuleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Rule");

                    b.HasDiscriminator<int>("RuleTypeId");
                });

            modelBuilder.Entity("SaaSEqt.eShop.Services.Marketing.API.Model.PurchaseHistoryRule", b =>
                {
                    b.HasBaseType("SaaSEqt.eShop.Services.Marketing.API.Model.Rule");


                    b.ToTable("PurchaseHistoryRule");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Services.Marketing.API.Model.UserLocationRule", b =>
                {
                    b.HasBaseType("SaaSEqt.eShop.Services.Marketing.API.Model.Rule");

                    b.Property<int>("LocationId")
                        .HasColumnName("LocationId");

                    b.ToTable("UserLocationRule");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Services.Marketing.API.Model.UserProfileRule", b =>
                {
                    b.HasBaseType("SaaSEqt.eShop.Services.Marketing.API.Model.Rule");


                    b.ToTable("UserProfileRule");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("SaaSEqt.eShop.Services.Marketing.API.Model.Rule", b =>
                {
                    b.HasOne("SaaSEqt.eShop.Services.Marketing.API.Model.Campaign", "Campaign")
                        .WithMany("Rules")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
