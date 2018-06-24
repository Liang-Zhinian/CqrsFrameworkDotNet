using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Entities;
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

            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.LocationId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.OwnsOne(_ => _.PostalAddress, cb =>
            {
                cb.Property("LocationAddressId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property(e => e.StreetAddress).HasColumnName("StreetAddress").HasColumnType(Constants.DbConstants.String255);
                cb.Property(e => e.StreetAddress2).HasColumnName("StreetAddress2").HasColumnType(Constants.DbConstants.String255);
                cb.Property(e => e.City).HasColumnName("City").HasColumnType(Constants.DbConstants.String255);
                cb.Property(e => e.StateProvince).HasColumnName("StateProvince").HasColumnType(Constants.DbConstants.String255);
                cb.Property(e => e.CountryCode).HasColumnName("CountryCode").HasColumnType(Constants.DbConstants.String255);
                cb.Property(e => e.PostalCode).HasColumnName("PostalCode").HasColumnType(Constants.DbConstants.String255);
            });

            builder.OwnsOne(_ => _.Geolocation, cb =>
            {
                cb.Property("LocationAddressId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property(e => e.Latitude);
                cb.Property(e => e.Longitude);
            });

            builder.OwnsOne(_ => _.TenantId, cb =>
            {
                cb.Property<string>(tenant => tenant.Id).IsRequired()
                  .HasColumnType(Constants.DbConstants.String36)
                .HasColumnName("TenantId_Id");
            });

            builder.HasOne(_ => _.Site)
                   .WithMany()
                   .HasForeignKey(_ => _.SiteId);
            
            //builder.HasOne(_ => _.Location)
                   //.WithOne(_=>_.Address)
                   //.HasForeignKey<LocationAddress>(_ => _.LocationId);
        }
    }
}
