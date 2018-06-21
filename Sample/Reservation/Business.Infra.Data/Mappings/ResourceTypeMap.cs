using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ResourceTypeMap : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ResourceTypeTable);

            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);
            builder.Property<string>("TenantId_Id").IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder.Ignore("Version");

            builder
                .HasMany(p => p.Resources)
                .WithOne(p => p.ResourceType)
                .HasForeignKey(p => p.ResourceTypeId);
        }
    }
}
