using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel;
using Business.Infra.Data.ReadModel.Security;
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

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("ResourceId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("LocationId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            
            builder
                .HasOne(sl => sl.Resource)
                .WithMany(p => p.ResourceLocations)
                .HasForeignKey(sl => sl.ResourceId);
            
            builder
                .HasOne(sl => sl.Location)
                .WithMany(p => p.ResourceLocations)
                .HasForeignKey(sl => sl.LocationId);
        }
    }
}
