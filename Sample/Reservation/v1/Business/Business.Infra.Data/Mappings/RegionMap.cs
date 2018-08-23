using Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infrastructure.Mappings
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
