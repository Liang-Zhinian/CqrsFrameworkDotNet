using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ResourceLocationMap : IEntityTypeConfiguration<ResourceLocation>
    {
        public void Configure(EntityTypeBuilder<ResourceLocation> builder)
        {
            builder
                .HasKey(t => new { t.Id, t.ResourceId, t.LocationId });
            builder.ToTable(Constants.DbConstants.ResourceLocationTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("ResourceId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.Ignore("Version");
            
            builder
                .HasOne(sl => sl.Resource)
                .WithMany(p => p.ResourceLocations)
                .HasForeignKey(sl => sl.ResourceId);
            
            builder
                .HasOne(sl => sl.Location)
                .WithMany()
                .HasForeignKey(sl => sl.LocationId);
        }
    }
}
