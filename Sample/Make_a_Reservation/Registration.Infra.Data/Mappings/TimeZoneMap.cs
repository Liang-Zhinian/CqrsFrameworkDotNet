using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class TimeZoneMap : IEntityTypeConfiguration<Domain.ReadModel.TimeZone>
    {
        public void Configure(EntityTypeBuilder<Domain.ReadModel.TimeZone> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TimeZoneTable);

            builder.Property<string>("DisplayName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StandardName").IsRequired().HasColumnType(Constants.DbConstants.String255);

        }
    }
}
