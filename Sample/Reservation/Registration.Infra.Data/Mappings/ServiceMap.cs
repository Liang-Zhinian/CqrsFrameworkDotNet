using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel;

namespace Registration.Infra.Data.Mappings
{
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ServiceTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<Guid>("CategoryId").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<Guid>("TenantId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.HasOne(_ => _.Category)
                   .WithMany(_ => _.Services)
                   .HasForeignKey(_ => _.CategoryId);


        }
    }
}
