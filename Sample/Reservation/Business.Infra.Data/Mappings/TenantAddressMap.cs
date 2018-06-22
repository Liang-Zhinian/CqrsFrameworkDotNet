using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class TenantAddressMap : IEntityTypeConfiguration<TenantAddress>
    {
        public void Configure(EntityTypeBuilder<TenantAddress> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TenantAddressTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.OwnsOne(_ => _.PostalAddress, cb => {
                cb.Property("TenantAddressId").HasColumnType(Constants.DbConstants.KeyType);
                cb.Property<string>(e => e.StreetAddress).HasColumnName("StreetAddress").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.StreetAddress2).HasColumnName("StreetAddress2").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.City).HasColumnName("City").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.StateProvince).HasColumnName("StateProvince").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.CountryCode).HasColumnName("CountryCode").HasColumnType(Constants.DbConstants.String255);
                cb.Property<string>(e => e.PostalCode).HasColumnName("PostalCode").HasColumnType(Constants.DbConstants.String255);
            });
            //builder.Ignore("Version");

            //builder.OwnsOne(_ => _.TenantId, cb =>
            //{
            //    cb.Property<string>(tenant => tenant.Id).IsRequired()
            //      .HasColumnType(Constants.DbConstants.String36)
            //    .HasColumnName("TenantId_Id");
            //});
        }
    }
}
