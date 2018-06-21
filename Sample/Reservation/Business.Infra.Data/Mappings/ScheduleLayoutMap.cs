using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Business.Domain.Models;

namespace Business.Infra.Data.Mappings
{
    public class ScheduleLayoutMap : IEntityTypeConfiguration<ScheduleLayout>
    {
        public void Configure(EntityTypeBuilder<ScheduleLayout> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ScheduleLayoutTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<int>("TimeZoneId").IsRequired();
            builder.Property<string>("TenantId_Id").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.Ignore("Version");

            builder.HasOne(_ => _.TimeZone)
                   .WithMany(_=>_.ScheduleLayouts)
                   .HasForeignKey(_=>_.TimeZoneId);
            

        }
    }
}
