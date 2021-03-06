﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infrastructure.Mappings
{
    public class StaffMap : BaseMap<Staff>, IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            base.Configure(builder, Constants.DbConstants.StaffTable);

            builder.Property<bool>(_ => _.IsEnabled).IsRequired();
            builder.Property<DateTime>("StartDate");
            builder.Property<DateTime>("EndDate");
            builder.Property<string>("Email").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("FirstName").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("LastName").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PrimaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("City").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("CountryCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StateProvince").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StreetAddress").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StreetAddress2").HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.IsMale).IsRequired();
            builder.Property(_ => _.Bio).HasColumnType(Constants.DbConstants.String2000);
            builder.Property(_ => _.Image).HasColumnType(Constants.DbConstants.String4000);

            MapToSite(builder);
        }
    }
}
