﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CqrsFramework.EventStore.IntegrationEventLogEF;

namespace Business.Infra.Data.Migrations
{
    [DbContext(typeof(IntegrationEventLogContext))]
    [Migration("20170322145434_IntegrationEventInitial")]
    partial class IntegrationEventInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("IntegrationEventLogDb")
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("CqrsFramework.EventStore.IntegrationEventLogEF.IntegrationEventLogEntry", b =>
                {
                    b.Property<Guid>("EventId")
                     .ValueGeneratedOnAdd();

                    b.Property<Guid>("SourceId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EventTypeName")
                        .IsRequired();

                    b.Property<int>("State");

                    b.Property<int>("TimesSent");

                    b.HasKey("EventId");

                    b.ToTable("IntegrationEventLog");
                });
        }
    }
}
