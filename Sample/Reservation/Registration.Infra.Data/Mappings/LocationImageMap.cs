using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class LocationImageMap : BaseMap<LocationImage>, IEntityTypeConfiguration<LocationImage>
    {
        public void Configure(EntityTypeBuilder<LocationImage> builder)
        {
            base.Configure(builder, Constants.DbConstants.LocationImageTable);

            builder.Property<Guid>(_ => _.LocationId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.Image).IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<Guid>("SiteId").HasColumnType(Constants.DbConstants.KeyType);
            //builder.Property<Guid>("TenantId").HasColumnType(Constants.DbConstants.String36);

            MapToSite(builder);
            MapToTenant(builder);

            builder
                .HasOne(b => b.Location)
                .WithMany(p => p.AdditionalLocationImages)
                .HasForeignKey(p => p.LocationId);
        }
    }
}
