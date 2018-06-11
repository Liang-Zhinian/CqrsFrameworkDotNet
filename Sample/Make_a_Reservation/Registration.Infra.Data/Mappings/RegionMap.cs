using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel;

namespace Registration.Infra.Data.Mappings
{
    public class RegionMap : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.RegionTable);

            //builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("RegionString").IsRequired();
            builder.Property<string>("Abbreviation");
            builder.Property<string>("EquivalentLocaleName");

        }
    }
}
