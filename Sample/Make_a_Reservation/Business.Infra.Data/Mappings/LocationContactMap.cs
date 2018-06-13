using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class LocationContactMap : IEntityTypeConfiguration<LocationContact>
    {
        public void Configure(EntityTypeBuilder<LocationContact> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.LocationContactTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Email").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Email2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone3").HasColumnType(Constants.DbConstants.String255);

            builder.HasOne(p => p.Location)
                   .WithOne(p => p.Contact)
                   .HasForeignKey<LocationContact>(f => f.LocationId);
        }
    }
}
