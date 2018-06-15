using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class StaffLoginLocationMap : IEntityTypeConfiguration<StaffLoginLocation>
    {
        public void Configure(EntityTypeBuilder<StaffLoginLocation> builder)
        {
            builder
                .HasKey(t => new { t.Id, t.StaffId, t.LocationId });
            builder.ToTable(Constants.DbConstants.StaffLoginLocationTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("StaffId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            
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
