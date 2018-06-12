using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ResourceMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Resource");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("Description");
            builder.Property<bool>("IsLocatedAtAllLocations");
            builder.Property<int>("StatusId");
            builder.Property<string>("ScheduleId");


        }
    }
}
