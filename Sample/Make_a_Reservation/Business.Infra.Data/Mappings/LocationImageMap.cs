using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class LocationImageMap : IEntityTypeConfiguration<LocationImage>
    {
        public void Configure(EntityTypeBuilder<LocationImage> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.LocationImageTable);

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("ImageURL").IsRequired().HasColumnType(Constants.DbConstants.String255);

            builder.HasOne(p => p.Location)
                   .WithMany(p => p.AdditionalLocationImages)
                   .HasForeignKey(f => f.LocationId);
        }
    }
}
