using System;
using System.ComponentModel.DataAnnotations.Schema;
using SaaSEqt.eShop.Site.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaaSEqt.eShop.Site.Api.Infrastructure.Mappings
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.StaffTable);

            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.SiteId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property(_ => _.IsMale).IsRequired();
            builder.Property(_ => _.Bio).HasColumnType(Constants.DbConstants.String2000);
            builder.Property(_ => _.Image).HasColumnType(Constants.DbConstants.String4000);

            //builder.HasOne(_ => _.Site)
                   //.WithMany()
                   //.HasForeignKey(_ => _.SiteId);
        }
    }
}
