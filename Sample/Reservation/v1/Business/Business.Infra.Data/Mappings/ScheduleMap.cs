using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Domain.Entities;

namespace Business.Infrastructure.Mappings
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ScheduleTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<bool>("IsDefault").IsRequired();
            builder.Property<int>("WeekdayStart").IsRequired();
            builder.Property<int>("DaysVisible").IsRequired();
            builder.Property<DateTime>("StartDateTime").IsRequired();
            builder.Property<DateTime>("EndDateTime").IsRequired();
            builder.Property<Guid>("LayoutId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<bool>("IsCalendarSubscriptionAllowed").IsRequired();

            builder.Ignore("Version");

            builder.HasOne(_ => _.Layout)
                   .WithMany(_=>_.Schedules)
                   .HasForeignKey(_=>_.LayoutId);
        }
    }
}
