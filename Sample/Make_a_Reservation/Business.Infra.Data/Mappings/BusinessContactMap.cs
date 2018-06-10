using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class BusinessContactMap : IEntityTypeConfiguration<BusinessContact>
    {
        public void Configure(EntityTypeBuilder<BusinessContact> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("BusinessContact");

            builder.Property<string>("Email");
            builder.Property<string>("Email2");
            builder.Property<string>("Phone");
            builder.Property<string>("Phone2");
            builder.Property<string>("Phone3");

        }
    }
}
