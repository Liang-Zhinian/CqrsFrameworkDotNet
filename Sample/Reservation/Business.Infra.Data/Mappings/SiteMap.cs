using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class SiteMap : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.SiteTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);

            builder.OwnsOne(_ => _.ContactInformation, cb => {
                cb.Property("SiteId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property<string>(e => e.ContactName).HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.PrimaryTelephone).HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.SecondaryTelephone).HasColumnType(Constants.DbConstants.String255);
            });

            builder.OwnsOne(_ => _.TenantId, cb =>
            {
                cb.Property<string>(tenant => tenant.Id).IsRequired()
                  .HasColumnType(Constants.DbConstants.String36)
                .HasColumnName("TenantId_Id");
            });
        }
    }
}
