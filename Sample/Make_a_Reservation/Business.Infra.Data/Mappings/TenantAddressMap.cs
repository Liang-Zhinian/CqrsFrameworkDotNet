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
            //builder.Property<Guid>("AddressId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Street").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Street2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("City").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("State").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Country").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("ForeignZip").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);

            builder.Ignore("Version");

            builder.HasOne(p => p.Tenant)
                   .WithOne(p => p.Address)
                   .HasForeignKey<TenantAddress>(f => f.TenantId);
        }
    }
}
