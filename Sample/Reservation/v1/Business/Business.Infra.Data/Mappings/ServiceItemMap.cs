﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Domain.Entities.ServiceCategories;

namespace Business.Infra.Data.Mappings
{
    public class ServiceItemMap : IEntityTypeConfiguration<ServiceItem>
    {
        public void Configure(EntityTypeBuilder<ServiceItem> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ServiceItemTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<int>("DefaultTimeLength").IsRequired();
            builder.Property<Guid>("CategoryId").HasColumnType(Constants.DbConstants.KeyType);

            //builder.Ignore("Version");

            //builder.HasOne(_ => _.Category)
                   //.WithMany(_ => _.Services)
                   //.HasForeignKey(_ => _.CategoryId);


        }
    }
}