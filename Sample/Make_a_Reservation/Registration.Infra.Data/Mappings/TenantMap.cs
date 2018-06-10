using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Tenant");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Name").IsRequired();
            builder.Property<string>("DisplayName");

            builder.HasOne(p => p.Address)
                   .WithOne(p => p.Tenant)
                   .HasForeignKey<TenantAddress>(f=>f.TenantId);

            builder.HasOne(p => p.Contact)
                   .WithOne(p => p.Tenant)
                   .HasForeignKey<TenantContact>(f => f.TenantId);

            builder
                .HasMany(p => p.Locations)
                .WithOne(b => b.Tenant)
                .HasForeignKey(p => p.TenantId);
            
            builder
                .HasMany(p => p.Staffs)
                .WithOne(b => b.Tenant)
                .HasForeignKey(p => p.TenantId);
            

        }
    }
}
