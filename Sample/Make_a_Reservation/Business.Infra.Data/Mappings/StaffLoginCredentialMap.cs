using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class StaffLoginCredentialMap : IEntityTypeConfiguration<StaffLoginCredential>
    {
        public void Configure(EntityTypeBuilder<StaffLoginCredential> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.StaffLoginCredentialTable);

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("StaffId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("UserName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Password").IsRequired().HasColumnType(Constants.DbConstants.String255);

            builder.HasOne(p => p.Staff)
                   .WithOne(p => p.LoginCredential)
                   .HasForeignKey<StaffLoginCredential>(f => f.StaffId);
            
        }
    }
}
