﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ResourceMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ResourceTable);

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);
            builder.Property<bool>("IsLocatedAtAllLocations").IsRequired();
            builder.Property<int>("StatusId").IsRequired();
            builder.Property<string>("ScheduleId").HasColumnType(Constants.DbConstants.KeyType);


        }
    }
}
