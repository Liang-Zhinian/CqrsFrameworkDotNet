using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class LocationImageMap : IEntityTypeConfiguration<LocationImage>
    {
        public void Configure(EntityTypeBuilder<LocationImage> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("LocationImage");

            builder.Property<string>("ImageURL");
        }
    }
}
