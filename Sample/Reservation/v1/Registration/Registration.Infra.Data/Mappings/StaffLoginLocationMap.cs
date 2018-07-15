using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infrastructure.Mappings
{
    public class StaffLoginLocationMap : BaseMap<StaffLoginLocation>, IEntityTypeConfiguration<StaffLoginLocation>
    {
        public void Configure(EntityTypeBuilder<StaffLoginLocation> builder)
        {
            //base.Configure(builder, Constants.DbConstants.StaffLoginLocationTable);

            builder
                .HasKey(t => new { t.Id, t.StaffId, t.LocationId, t.SiteId });
            builder.ToTable(Constants.DbConstants.StaffLoginLocationTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("StaffId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("SiteId")
                    .IsRequired()
                   .HasColumnName("SiteId").HasColumnType(Constants.DbConstants.KeyType);

            builder
                .HasOne(sl => sl.Staff)
                .WithMany(p => p.StaffLoginLocations)
                .HasForeignKey(sl => sl.StaffId);
            
            builder
                .HasOne(sl => sl.Location)
                .WithMany(p => p.StaffLoginLocations)
                .HasForeignKey(sl => sl.LocationId);

            MapToSite(builder);
        }
    }
}
