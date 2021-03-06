﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infrastructure.Mappings
{
    public class ResourceStatusMap : IEntityTypeConfiguration<ResourceStatus>
    {
        public void Configure(EntityTypeBuilder<ResourceStatus> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ResourceStatusTable);

            builder.Property<int>("Id").IsRequired();
            builder.Property<string>("Label").IsRequired().HasColumnType(Constants.DbConstants.String255);


            builder
                .HasMany(p => p.Resources)
                .WithOne(p => p.Status)
                .HasForeignKey(p=>p.StatusId);
        }
    }
}
