using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Infra.Data.ReadModel.Security;

namespace Business.Infra.Data.Mappings
{
    public class BrandingMap : IEntityTypeConfiguration<Branding>
    {
        public void Configure(EntityTypeBuilder<Branding> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.BrandingTable);

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("TenantId").IsRequired();
            builder.Property<string>("LogoURL").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor2").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor3").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor4").HasColumnType(Constants.DbConstants.String10);
        }
    }
}
