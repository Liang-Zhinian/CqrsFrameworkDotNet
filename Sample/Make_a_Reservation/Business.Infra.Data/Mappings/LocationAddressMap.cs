using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class LocationAddressMap : IEntityTypeConfiguration<LocationAddress>
    {
        public void Configure(EntityTypeBuilder<LocationAddress> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("LocationAddress");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Street");
            builder.Property<string>("Street2");
            builder.Property<string>("City");
            builder.Property<string>("State");
            builder.Property<string>("Country");
            builder.Property<string>("ForeignZip");
            builder.Property<double>("Latitude");
            builder.Property<double>("Longitude");

        }
    }
}
