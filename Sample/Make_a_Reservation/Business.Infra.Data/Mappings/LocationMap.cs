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
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);


            builder
                .HasOne(b => b.Tenant)
                .WithMany(p => p.Locations)
                .HasForeignKey(p => p.TenantId);
            
        }
    }
}
