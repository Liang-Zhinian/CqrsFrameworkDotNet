using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Location");

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
