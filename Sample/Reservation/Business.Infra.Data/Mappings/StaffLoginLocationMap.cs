using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
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
            builder.Property<Guid>("SiteId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.OwnsOne(_ => _.TenantId, cb =>
            {
                cb.Property<string>(tenant => tenant.Id).IsRequired()
                  .HasColumnType(Constants.DbConstants.String36)
                .HasColumnName("TenantId_Id");
            });

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
