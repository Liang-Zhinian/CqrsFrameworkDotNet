using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Entities;
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

            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.Name).IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property(_ => _.Description).HasColumnType(Constants.DbConstants.String2000);
            builder.Property(_ => _.Active).IsRequired();

            builder.OwnsOne(_ => _.ContactInformation, cb => {
                cb.Property("SiteId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property<string>(e => e.ContactName).HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.PrimaryTelephone).HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.SecondaryTelephone).HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.EmailAddress).HasColumnType(Constants.DbConstants.String255);
            });

            builder.OwnsOne(_ => _.TenantId, cb =>
            {
                cb.Property(_ => _.Id)
                  .IsRequired()
                  .HasColumnType(Constants.DbConstants.String36);
            });
        }
    }
}
