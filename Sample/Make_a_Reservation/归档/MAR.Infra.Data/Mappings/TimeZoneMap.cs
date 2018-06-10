using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class TimeZoneMap : IEntityTypeConfiguration<Models.TimeZone>
    {
        public void Configure(EntityTypeBuilder<Models.TimeZone> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("TimeZone");

            builder.Property<string>("DisplayName").IsRequired();
            builder.Property<string>("StandardName");

        }
    }
}
