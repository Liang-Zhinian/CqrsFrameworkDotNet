using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class LocationAddressMap : IEntityTypeConfiguration<LocationAddress>
    {
        public void Configure(EntityTypeBuilder<LocationAddress> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.LocationAddressTable);

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Street").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Street2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("City").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("State").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Country").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("ForeignZip").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<double>("Latitude");
            builder.Property<double>("Longitude");


            builder.HasOne(p => p.Location)
                   .WithOne(p => p.Address)
                   .HasForeignKey<LocationAddress>(f => f.LocationId);
        }
    }
}
