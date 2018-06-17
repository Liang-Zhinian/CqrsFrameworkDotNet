using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaaSEqt.BizInfo.MigrationMappings
{
    public class TimeZoneMap : IEntityTypeConfiguration<SaaSEqt.BizInfo.TimeZone>
    {
        public void Configure(EntityTypeBuilder<SaaSEqt.BizInfo.TimeZone> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TimeZoneTable);

            builder.Property<string>("DisplayName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StandardName").IsRequired().HasColumnType(Constants.DbConstants.String255);

        }
    }
}
