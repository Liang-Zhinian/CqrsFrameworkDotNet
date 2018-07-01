using System;
using System.ComponentModel.DataAnnotations.Schema;
using SaaSEqt.eShop.Site.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaaSEqt.eShop.Site.Api.Infrastructure.Mappings
{
    public class StaffLoginLocationMap : IEntityTypeConfiguration<StaffLoginLocation>
    {
        public void Configure(EntityTypeBuilder<StaffLoginLocation> builder)
        {
            builder
                .HasKey(t => new { t.Id, t.StaffId, t.LocationId });
            builder.ToTable(Constants.DbConstants.StaffLoginLocationTable);

            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.LocationId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);


            builder.HasOne(_ => _.Site)
                   .WithMany()
                   .HasForeignKey(_ => _.SiteId);
            
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
