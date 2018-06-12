using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class TimeZoneMap : IEntityTypeConfiguration<Business.Infra.Data.ReadModel.TimeZone>
    {
        public void Configure(EntityTypeBuilder<Business.Infra.Data.ReadModel.TimeZone> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TimeZoneTable);

            builder.Property<string>("DisplayName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StandardName").IsRequired().HasColumnType(Constants.DbConstants.String255);

        }
    }
}
