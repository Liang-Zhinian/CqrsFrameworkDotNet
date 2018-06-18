using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class TimeZoneMap : IEntityTypeConfiguration<Business.Domain.Models.TimeZone>
    {
        public void Configure(EntityTypeBuilder<Business.Domain.Models.TimeZone> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TimeZoneTable);

            builder.Property<string>("DisplayName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StandardName").IsRequired().HasColumnType(Constants.DbConstants.String255);

        }
    }
}
