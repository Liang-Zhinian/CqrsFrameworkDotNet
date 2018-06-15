﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TenantTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("DisplayName").HasColumnType(Constants.DbConstants.String2000);
            builder.Property<string>("Street").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Street2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("City").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("State").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Country").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("ForeignZip").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Email").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Email2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone3").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("LogoURL").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor2").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor3").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor4").HasColumnType(Constants.DbConstants.String10);

            builder.Ignore("Version");

        }
    }
}
