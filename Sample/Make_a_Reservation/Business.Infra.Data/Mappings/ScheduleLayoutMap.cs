using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Infra.Data.ReadModel;

namespace Business.Infra.Data.Mappings
{
    public class ScheduleLayoutMap : IEntityTypeConfiguration<ScheduleLayout>
    {
        public void Configure(EntityTypeBuilder<ScheduleLayout> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("ScheduleLayout");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<int>("TimeZoneId");
        }
    }
}
