using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class StaffLoginLocationMap : IEntityTypeConfiguration<StaffLoginLocation>
    {
        public void Configure(EntityTypeBuilder<StaffLoginLocation> builder)
        {
            builder
                .HasKey(t => new { t.Id, t.StaffId, t.LocationId });
            builder.ToTable("StaffLoginLocation");

            builder.Property<string>("StaffId");
            builder.Property<string>("LocationId");

            
            builder
                .HasOne(sl => sl.Staff)
                .WithMany(p => p.StaffLoginLocations)
                .HasForeignKey(sl => sl.StaffId);
            
            builder
                .HasOne(sl => sl.Location)
                .WithMany(p => p.StaffLoginLocations)
                .HasForeignKey(sl => sl.LocationId);
        }
    }
}
