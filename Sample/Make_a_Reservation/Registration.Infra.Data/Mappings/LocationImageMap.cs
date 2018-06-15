using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class LocationImageMap : IEntityTypeConfiguration<LocationImage>
    {
        public void Configure(EntityTypeBuilder<LocationImage> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.LocationImageTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("ImageUrl").IsRequired().HasColumnType(Constants.DbConstants.String255);
        }
    }
}
