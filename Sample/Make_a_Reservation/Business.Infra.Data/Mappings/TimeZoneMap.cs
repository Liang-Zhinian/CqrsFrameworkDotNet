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
            builder.ToTable("TimeZone");

            //builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("DisplayName").IsRequired();
            builder.Property<string>("StandardName");

        }
    }
}
