using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Infra.Data.ReadModel;

namespace Business.Infra.Data.Mappings
{
    public class ScheduleLayoutTimeSlotMap : IEntityTypeConfiguration<ScheduleLayoutTimeSlot>
    {
        public void Configure(EntityTypeBuilder<ScheduleLayoutTimeSlot> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("ScheduleLayoutTimeSlot");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Label");
            builder.Property<string>("EndLabel");
            builder.Property<int>("AvailabilityCode");
            builder.Property<string>("LayoutId");
            builder.Property<string>("StartTime");
            builder.Property<string>("EndTime");
            builder.Property<int>("DayOfWeek");
            builder.Property<bool>("IsEnabled");

        public virtual ScheduleLayout Layout { get; set; }


        }
    }
}
