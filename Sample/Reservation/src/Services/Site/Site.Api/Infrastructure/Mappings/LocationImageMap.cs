﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using SaaSEqt.eShop.Site.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaaSEqt.eShop.Site.Api.Infrastructure.Mappings
{
    public class LocationImageMap : IEntityTypeConfiguration<LocationImage>
    {
        public void Configure(EntityTypeBuilder<LocationImage> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.LocationImageTable);

            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.LocationId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.Image);

            builder.HasOne(_ => _.Site)
                   .WithMany()
                   .HasForeignKey(_ => _.SiteId);

            builder.HasOne(p => p.Location)
                   .WithMany(p => p.AdditionalLocationImages)
                   .HasForeignKey(f => f.LocationId);
            
        }
    }
}
