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
            builder.ToTable(Constants.DbConstants.ScheduleLayoutTimeSlotTable);

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Label").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("EndLabel").HasColumnType(Constants.DbConstants.String255);
            builder.Property<int>("AvailabilityCode").IsRequired();
            builder.Property<string>("LayoutId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("StartTime").IsRequired().HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("EndTime").IsRequired().HasColumnType(Constants.DbConstants.String10);
            builder.Property<int>("DayOfWeek").IsRequired();
            builder.Property<bool>("IsEnabled").IsRequired();


            builder.HasOne(_ => _.Layout)
                   .WithMany(_ => _.TimeSlots)
                   .HasForeignKey(_ => _.LayoutId);


        }
    }
}
