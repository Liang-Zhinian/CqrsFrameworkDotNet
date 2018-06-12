using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ResourceStatusMap : IEntityTypeConfiguration<ResourceStatus>
    {
        public void Configure(EntityTypeBuilder<ResourceStatus> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("ResourceStatus");

            builder.Property<int>("Id");
            builder.Property<string>("Label");


        }
    }
}
