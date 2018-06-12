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
            builder.ToTable(Constants.DbConstants.RegionTable);

            builder.Property<string>("RegionString").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Abbreviation").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("EquivalentLocaleName").IsRequired().HasColumnType(Constants.DbConstants.String255);

        }
    }
}
