using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Infra.Data.ReadModel;

namespace Business.Infra.Data.Mappings
{
    public class RegionMap : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Region");

            //builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("RegionString").IsRequired();
            builder.Property<string>("Abbreviation");
            builder.Property<string>("EquivalentLocaleName");

        }
    }
}
