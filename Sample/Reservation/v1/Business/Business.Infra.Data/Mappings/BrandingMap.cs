using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Domain.Entities;

namespace Business.Infra.Data.Mappings
{
    public class BrandingMap : IEntityTypeConfiguration<Branding>
    {
        public void Configure(EntityTypeBuilder<Branding> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.BrandingTable);

            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.Logo).HasColumnType(Constants.DbConstants.String4000);
            builder.Property(_ => _.PageColor1).HasColumnType(Constants.DbConstants.String10);
            builder.Property(_ => _.PageColor1).HasColumnType(Constants.DbConstants.String10);
            builder.Property(_ => _.PageColor2).HasColumnType(Constants.DbConstants.String10);
            builder.Property(_ => _.PageColor3).HasColumnType(Constants.DbConstants.String10);
            builder.Property(_ => _.PageColor4).HasColumnType(Constants.DbConstants.String10);

            builder.HasOne(_ => _.Site)
                   .WithOne(_ => _.Branding)
                   .HasForeignKey<Branding>(_ => _.SiteId);
        }
    }
}
