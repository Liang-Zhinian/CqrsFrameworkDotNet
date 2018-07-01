using System;
using Business.Domain.Entities.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ScheduleTypeMap : IEntityTypeConfiguration<ScheduleType>
    {
        public void Configure(EntityTypeBuilder<ScheduleType> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ScheduleTypeTable);

            builder.Property<int>("Id")
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();
            
            builder.Property<string>("Name").IsRequired()
                   .HasColumnType(Constants.DbConstants.String255);
        }
    }
}
