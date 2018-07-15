using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel;

namespace Registration.Infrastructure.Mappings
{
    public class RegionMap : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.RegionTable);

            builder.Property(_ => _.RegionString).IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.Abbreviation).IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.EquivalentLocaleName).IsRequired().HasColumnType(Constants.DbConstants.String255);

        }
    }
}
