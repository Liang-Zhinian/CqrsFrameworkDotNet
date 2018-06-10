using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Location");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("Description");

            builder.HasOne(p => p.Address)
                   .WithOne(p => p.Location)
                   .HasForeignKey<LocationAddress>(f=>f.LocationId);

            builder.HasOne(p => p.Contact)
                   .WithOne(p => p.Location)
                   .HasForeignKey<LocationContact>(f => f.LocationId);
        }
    }
}
