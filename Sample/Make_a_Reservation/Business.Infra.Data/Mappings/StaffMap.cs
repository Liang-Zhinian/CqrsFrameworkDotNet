using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("Staff");

            builder.Property<string>("FirstName").IsRequired();
            builder.Property<string>("LastName").IsRequired();
            builder.Property<string>("DisplayName");
            builder.Property<bool>("IsMale");
            builder.Property<string>("Bio");
            builder.Property<string>("ImageUrl");

            builder.HasOne(p => p.Address)
                   .WithOne(p => p.Staff)
                   .HasForeignKey<StaffAddress>(f=>f.StaffId);

            builder.HasOne(p => p.Contact)
                   .WithOne(p => p.Staff)
                   .HasForeignKey<StaffContact>(f => f.StaffId);
            
            builder.HasOne(p => p.LoginCredential)
                   .WithOne(p => p.Staff)
                   .HasForeignKey<StaffLoginCredential>(f => f.StaffId);
            
        }
    }
}
