using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.StaffTable);

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("FirstName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("LastName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("DisplayName").HasColumnType(Constants.DbConstants.String255);
            builder.Property<bool>("IsMale").IsRequired();
            builder.Property<string>("Bio");
            builder.Property<string>("ImageUrl").HasColumnType(Constants.DbConstants.String255);


            builder
                .HasOne(b => b.Tenant)
                .WithMany(p => p.Staffs)
                .HasForeignKey(p => p.TenantId);
        }
    }
}
