using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.StaffTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<bool>("IsMale").IsRequired();
            builder.Property<string>("Bio").HasColumnType(Constants.DbConstants.String2000);
            builder.Property<string>("Image").HasColumnType(Constants.DbConstants.String4000);
            //builder.Property<Guid>("UserId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("SiteId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.OwnsOne(_ => _.TenantId, cb =>
            {
                cb.Property<string>(tenant => tenant.Id).IsRequired()
                  .HasColumnType(Constants.DbConstants.String36)
                .HasColumnName("TenantId_Id");
            });

            builder.HasOne(_ => _.Site)
                   .WithMany()
                   .HasForeignKey(_ => _.SiteId);
        }
    }
}
