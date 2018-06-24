using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class LocationMap : BaseMap<Location>, IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder, Constants.DbConstants.LocationTable);

            builder.Property(_ => _.Name).IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.Description).IsRequired(false).HasColumnType(Constants.DbConstants.String2000);
            builder.Property(_ => _.Image).IsRequired(false);
            builder.Property<string>(_ => _.Email).IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>(_ => _.PrimaryTelephone).HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>(_ => _.SecondaryTelephone).HasColumnType(Constants.DbConstants.String255); builder.Property<string>("City").IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>(_ => _.CountryCode).IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>(_ => _.PostalCode).IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>(_ => _.StateProvince).IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>(_ => _.StreetAddress).IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>(_ => _.StreetAddress2).IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.Latitude).IsRequired(false);
            builder.Property(_ => _.Longitude).IsRequired(false);

            MapToSite(builder);
            //MapToTenant(builder);
        }
    }
}
