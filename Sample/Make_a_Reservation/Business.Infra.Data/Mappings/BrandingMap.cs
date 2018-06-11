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
            builder.ToTable("Branding");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("LogoURL");
            builder.Property<string>("PageColor1");
            builder.Property<string>("PageColor1");
            builder.Property<string>("PageColor2");
            builder.Property<string>("PageColor3");
            builder.Property<string>("PageColor4");
        }
    }
}
