using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class BusinessMap : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Business");

            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("DisplayName");

            builder.HasOne(p => p.Address)
                   .WithOne(p => p.Business)
                   .HasForeignKey<BusinessAddress>(f=>f.BusinessId);

            builder.HasOne(p => p.Contact)
                   .WithOne(p => p.Business)
                   .HasForeignKey<BusinessContact>(f => f.BusinessId);

            builder
                .HasMany(p => p.Locations)
                .WithOne(b => b.Business)
                .HasForeignKey(p => p.BusinessId);
            
            builder
                .HasMany(p => p.Staffs)
                .WithOne(b => b.Business)
                .HasForeignKey(p => p.BusinessId);
            

        }
    }
}
