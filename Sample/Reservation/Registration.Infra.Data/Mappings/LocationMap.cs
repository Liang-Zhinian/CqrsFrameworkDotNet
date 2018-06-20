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

            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);
            //builder.Property<string>("Street").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Street2").HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("City").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("State").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Country").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Email").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PrimaryTelephone").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);


            builder.OwnsOne(_ => _.PostalAddress, address => {
                address.Property("LocationId").HasColumnType(Constants.DbConstants.KeyType);
                address.Property("City").HasColumnType(Constants.DbConstants.String255);
                address.Property("CountryCode").HasColumnType(Constants.DbConstants.String255);
                address.Property("PostalCode").HasColumnType(Constants.DbConstants.String255);
                address.Property("StateProvince").HasColumnType(Constants.DbConstants.String255);
                address.Property("StreetAddress").HasColumnType(Constants.DbConstants.String255);
                address.Property("StreetAddress2").HasColumnType(Constants.DbConstants.String255);
            });

            builder
                .HasOne(b => b.Tenant)
                .WithMany(p => p.Locations)
                .HasForeignKey(p => p.TenantId);
        }
    }
}
