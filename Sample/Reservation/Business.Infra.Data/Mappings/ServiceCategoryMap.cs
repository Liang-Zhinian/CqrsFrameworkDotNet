﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Domain.Entities;

namespace Business.Infra.Data.Mappings
{
    public class ServiceCategoryMap : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ServiceCategoryTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<int>("CancelOffset").IsRequired();
            builder.Property<int>("ScheduleTypeValue").IsRequired();
            //builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.Ignore("Version");

        }
    }
}
