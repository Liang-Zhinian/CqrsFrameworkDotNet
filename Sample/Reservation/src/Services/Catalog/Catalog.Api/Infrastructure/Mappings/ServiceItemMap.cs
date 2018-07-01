using System;
using System.ComponentModel.DataAnnotations.Schema;
using Catalog.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Api.Infrastructure.Mappings
{
    public class ServiceItemMap : IEntityTypeConfiguration<ServiceItem>
    {
        public void Configure(EntityTypeBuilder<ServiceItem> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ServiceItemTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<Guid>("ServiceCategoryId").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<int>("DefaultTimeLength");
            //builder.Property<Guid>("LocationId").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("SiteId").HasColumnType(Constants.DbConstants.KeyType);


            builder.HasOne(_ => _.ServiceCategory)
                   .WithMany(_ => _.ServiceItems)
                   .HasForeignKey(_ => _.ServiceCategoryId);


        }
    }
}
