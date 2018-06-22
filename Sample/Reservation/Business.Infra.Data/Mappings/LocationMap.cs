using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.Security;
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

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("BusinessID").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("BusinessDescription").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);
            builder.Property<string>("Image").IsRequired().HasColumnType(Constants.DbConstants.String4000);
            builder.Property<double>("Latitude");
            builder.Property<double>("Longitude");
            builder.Property<string>("PrimaryTelephone").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            //builder.Ignore("Version");

            builder.OwnsOne(_ => _.PostalAddress, cb => {
                cb.Property("LocationId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property<string>(e => e.StreetAddress).HasColumnName("StreetAddress").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.StreetAddress2).HasColumnName("StreetAddress2").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.City).HasColumnName("City").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.StateProvince).HasColumnName("StateProvince").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.CountryCode).HasColumnName("CountryCode").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.PostalCode).HasColumnName("PostalCode").HasColumnType(Constants.DbConstants.String255);
            });

            //builder.OwnsOne(_=>_.TenantId, cb =>
            //{
            //    cb.Property<string>(tenant=>tenant.Id).IsRequired()
            //      .HasColumnType(Constants.DbConstants.String36)
            //    .HasColumnName("TenantId_Id");
            //});
            
        }
    }
}
