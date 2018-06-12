using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Infra.Data.ReadModel;

namespace Business.Infra.Data.Mappings
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Schedule");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Name");
            builder.Property<bool>("IsDefault");
            builder.Property<int>("WeekdayStart");
            builder.Property<int>("DaysVisible");
            builder.Property<DateTime>("StartDateTime");
            builder.Property<DateTime>("EndDateTime");
            builder.Property<string>("LayoutId");
            builder.Property<bool>("IsCalendarSubscriptionAllowed");

            builder.HasOne(_ => _.Layout)
                   .WithOne(_ => _.Schedule)
                   .HasForeignKey<Schedule>(_ => _.LayoutId);
        }
    }
}
