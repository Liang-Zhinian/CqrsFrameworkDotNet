using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class TenantContactMap : IEntityTypeConfiguration<TenantContact>
    {
        public void Configure(EntityTypeBuilder<TenantContact> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.TenantContactTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Email").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PrimaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);

            builder.Ignore("Version");
        }
    }
}
