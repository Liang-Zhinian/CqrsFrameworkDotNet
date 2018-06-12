using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class StaffContactMap : IEntityTypeConfiguration<StaffContact>
    {
        public void Configure(EntityTypeBuilder<StaffContact> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.StaffContactTable);

            builder.Property<string>("Id").HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("StaffId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Email").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Email2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone2").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Phone3").HasColumnType(Constants.DbConstants.String255);

            builder.HasOne(p => p.Staff)
                   .WithOne(p => p.Contact)
                   .HasForeignKey<StaffContact>(f => f.StaffId);
        }
    }
}
