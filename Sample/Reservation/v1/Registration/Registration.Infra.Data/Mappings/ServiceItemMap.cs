using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel;

namespace Registration.Infra.Data.Mappings
{
    public class ServiceItemMap : BaseMap<ServiceItem>,  IEntityTypeConfiguration<ServiceItem>
    {
        public void Configure(EntityTypeBuilder<ServiceItem> builder)
        {
            //builder.HasKey(o => o.Id);
            //builder.ToTable(Constants.DbConstants.ServiceTable);
            base.Configure(builder, Constants.DbConstants.ServiceItemTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<int>("DefaultTimeLength").IsRequired();
            builder.Property<bool>("AllowOnlineScheduling").IsRequired();
            builder.Property<Guid>("ServiceCategoryId").HasColumnType(Constants.DbConstants.KeyType);
            //builder.Property<Guid>("SiteId").HasColumnType(Constants.DbConstants.KeyType);

            builder.HasOne(_ => _.ServiceCategory)
                   .WithMany()
                   .HasForeignKey(_ => _.ServiceCategoryId);


            MapToSite(builder);
        }
    }
}
