using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Domain.Models.Security;

namespace Business.Infra.Data.Mappings
{
    public class BrandingMap : IEntityTypeConfiguration<Branding>
    {
        public void Configure(EntityTypeBuilder<Branding> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.BrandingTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("TenantId_Id").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("LogoURL").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor2").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor3").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor4").HasColumnType(Constants.DbConstants.String10);

            //builder.Ignore("Version");
        }
    }
}
