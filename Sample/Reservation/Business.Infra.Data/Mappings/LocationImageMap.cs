using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models;
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

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("SiteId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Image").IsRequired().HasColumnType(Constants.DbConstants.String255);

            builder.OwnsOne(_ => _.TenantId, cb =>
            {
                cb.Property<string>(tenant => tenant.Id).IsRequired()
                  .HasColumnType(Constants.DbConstants.String36)
                .HasColumnName("TenantId_Id");
            });

            builder.HasOne(_ => _.Site)
                   .WithMany()
                   .HasForeignKey(_ => _.SiteId);

            builder.HasOne(p => p.Location)
                   .WithMany(p => p.AdditionalLocationImages)
                   .HasForeignKey(f => f.LocationId);
            
        }
    }
}
