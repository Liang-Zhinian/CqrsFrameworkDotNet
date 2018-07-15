using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infrastructure.Mappings
{
    public class TimeZoneMap : IEntityTypeConfiguration<Business.Domain.Entities.TimeZone>
    {
        public void Configure(EntityTypeBuilder<Business.Domain.Entities.TimeZone> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TimeZoneTable);

            builder.Property(_ => _.DisplayName).IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.StandardName).IsRequired().HasColumnType(Constants.DbConstants.String255);

        }
    }
}
