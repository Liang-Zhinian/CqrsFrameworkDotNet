﻿using SaaSEqt.eShop.Services.Business.Infrastructure.EntityConfigurations.Constants;
using SaaSEqt.eShop.Services.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaaSEqt.eShop.Services.Business.Infrastructure.EntityConfigurations
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(DbConstants.StaffTable);

            builder.Property(_ => _.Id).HasColumnType(DbConstants.KeyType);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(DbConstants.KeyType);
            builder.Property(_ => _.IsMale).IsRequired();
            builder.Property(_ => _.Bio).HasColumnType(DbConstants.String2000);
            builder.Property(_ => _.Image).HasColumnType(DbConstants.String4000);

            //builder.HasOne(_ => _.Site)
                   //.WithMany()
                   //.HasForeignKey(_ => _.SiteId);
        }
    }
}
