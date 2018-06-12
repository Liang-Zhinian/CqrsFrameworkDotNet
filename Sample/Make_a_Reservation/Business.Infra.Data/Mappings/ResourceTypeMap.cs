using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ResourceTypeMap : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("ResourceType");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("Description");


        }
    }
}
