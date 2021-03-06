﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Domain.Entities.ServiceCategories;

namespace Business.Infrastructure.Mappings
{
    public class ServiceItemMap : IEntityTypeConfiguration<SchedulableCatalogItem>
    {
        public void Configure(EntityTypeBuilder<SchedulableCatalogItem> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ServiceItemTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<int>("DefaultTimeLength").IsRequired();
            builder.Property<bool>("AllowOnlineScheduling").IsRequired();
            builder.Property<Guid>("ServiceCategoryId").HasColumnType(Constants.DbConstants.KeyType);

            //builder.Ignore("Version");

            //builder.HasOne(_ => _.Category)
                   //.WithMany(_ => _.Services)
                   //.HasForeignKey(_ => _.CategoryId);


        }
    }
}
