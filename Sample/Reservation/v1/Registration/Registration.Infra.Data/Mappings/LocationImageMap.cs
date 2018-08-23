using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infrastructure.Mappings
{
    public class LocationImageMap : BaseMap<LocationImage>, IEntityTypeConfiguration<LocationImage>
    {
        public void Configure(EntityTypeBuilder<LocationImage> builder)
        {
            base.Configure(builder, Constants.DbConstants.LocationImageTable);

            builder.Property<Guid>(_ => _.LocationId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.Image);
            //builder.Property<Guid>("SiteId").HasColumnType(Constants.DbConstants.KeyType);
            //builder.Property<Guid>("TenantId").HasColumnType(Constants.DbConstants.String36);

            MapToSite(builder);

            builder
                .HasOne(b => b.Location)
                .WithMany(p => p.AdditionalLocationImages)
                .HasForeignKey(p => p.LocationId);
        }
    }
}
