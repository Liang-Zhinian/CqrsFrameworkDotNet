using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class LocationContactMap : IEntityTypeConfiguration<LocationContact>
    {
        public void Configure(EntityTypeBuilder<LocationContact> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("LocationContact");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Email");
            builder.Property<string>("Email2");
            builder.Property<string>("Phone");
            builder.Property<string>("Phone2");
            builder.Property<string>("Phone3");

        }
    }
}
