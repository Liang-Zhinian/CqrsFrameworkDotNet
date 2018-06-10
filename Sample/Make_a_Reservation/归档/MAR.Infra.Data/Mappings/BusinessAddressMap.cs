using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class BusinessAddressMap : IEntityTypeConfiguration<BusinessAddress>
    {
        public void Configure(EntityTypeBuilder<BusinessAddress> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("BusinessAddress");

            builder.Property<string>("Street");
            builder.Property<string>("Street2");
            builder.Property<string>("City");
            builder.Property<string>("State");
            builder.Property<string>("Country");
            builder.Property<string>("ForeignZip");

        }
    }
}
