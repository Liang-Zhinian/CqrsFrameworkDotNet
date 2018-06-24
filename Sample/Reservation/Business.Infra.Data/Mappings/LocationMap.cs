using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.LocationTable);

            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.Name).IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.Description).IsRequired(false).HasColumnType(Constants.DbConstants.String2000);
            builder.Property(_ => _.Image).IsRequired(false);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            //builder.Property(_ => _.LocationAddressId).IsRequired(false).HasColumnType(Constants.DbConstants.KeyType);

            builder.OwnsOne(_ => _.ContactInformation, cb =>
            {
                cb.Property("LocationId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property<string>(e => e.ContactName).HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.PrimaryTelephone).HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.SecondaryTelephone).HasColumnType(Constants.DbConstants.String255);
            });

            builder.OwnsOne(_ => _.TenantId, cb =>
            {
                cb.Property<string>(tenant => tenant.Id).IsRequired()
                  .HasColumnType(Constants.DbConstants.String36)
                .HasColumnName("TenantId_Id");
            });

            builder.OwnsOne(ci => ci.PostalAddress, address => {
                address.Property("LocationId").HasColumnType(Constants.DbConstants.KeyType);
                address.Property("City").IsRequired(false).HasColumnType(Constants.DbConstants.String255);
                address.Property("CountryCode").IsRequired(false).HasColumnType(Constants.DbConstants.String255);
                address.Property("PostalCode").IsRequired(false).HasColumnType(Constants.DbConstants.String255);
                address.Property("StateProvince").IsRequired(false).HasColumnType(Constants.DbConstants.String255);
                address.Property("StreetAddress").IsRequired(false).HasColumnType(Constants.DbConstants.String255);
            });

            builder.OwnsOne(_ => _.Geolocation, cb =>
            {
                cb.Property("LocationId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property(e => e.Latitude).IsRequired(false);
                cb.Property(e => e.Longitude).IsRequired(false);
            });

            builder.HasOne(_ => _.Site)
                   .WithMany(_=>_.Locations)
                   .HasForeignKey(_=>_.SiteId)
                   .IsRequired();

        }
    }
}
