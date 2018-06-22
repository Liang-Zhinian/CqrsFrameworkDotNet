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
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.Ignore("Version");

            builder.HasOne(_ => _.TimeZone)
                   .WithMany(_=>_.ScheduleLayouts)
                   .HasForeignKey(_=>_.TimeZoneId);
            

            //builder.OwnsOne(_ => _.TenantId, cb =>
            //{
            //    cb.Property<string>(tenant => tenant.Id).IsRequired()
            //      .HasColumnType(Constants.DbConstants.String36)
            //    .HasColumnName("TenantId_Id");
            //});
        }
    }
}
