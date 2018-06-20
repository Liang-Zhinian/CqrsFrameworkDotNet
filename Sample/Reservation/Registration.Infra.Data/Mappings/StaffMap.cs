using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class StaffMap : BaseMap<Staff>, IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            base.Configure(builder, Constants.DbConstants.StaffTable);

            //builder.Property<string>("FirstName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("LastName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("DisplayName").HasColumnType(Constants.DbConstants.String255);
            builder.Property<bool>("IsMale").IsRequired();
            builder.Property<string>("Bio").HasColumnType(Constants.DbConstants.String2000);
            builder.Property<string>("ImageUrl").HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Street").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Street2").HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("City").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("State").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Country").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Email").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("PrimaryTelephone").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);

            builder.OwnsOne(_ => _.Enablement, et => {
                et.Property("StaffId").HasColumnType(Constants.DbConstants.KeyType);
                et.Property<bool>(_ => _.Enabled).IsRequired();
                et.Property<DateTime>("StartDate");
                et.Property<DateTime>("EndDate");
            });
            builder.OwnsOne(_ => _.PersonalInfo, pi=>{
                pi.Property("StaffId").HasColumnType(Constants.DbConstants.KeyType);
                pi.Property<string>("Email").HasColumnType(Constants.DbConstants.String255);
                pi.Property<string>("FirstName").HasColumnType(Constants.DbConstants.String255);
                pi.Property<string>("LastName").HasColumnType(Constants.DbConstants.String255);
                pi.Property<string>("PrimaryTelephone").HasColumnType(Constants.DbConstants.String255);
                pi.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);
            });
            builder.OwnsOne(_ => _.PostalAddress, address => {
                address.Property("StaffId").HasColumnType(Constants.DbConstants.KeyType);
                address.Property("City").HasColumnType(Constants.DbConstants.String255);
                address.Property("CountryCode").HasColumnType(Constants.DbConstants.String255);
                address.Property("PostalCode").HasColumnType(Constants.DbConstants.String255);
                address.Property("StateProvince").HasColumnType(Constants.DbConstants.String255);
                address.Property("StreetAddress").HasColumnType(Constants.DbConstants.String255);
                address.Property("StreetAddress2").HasColumnType(Constants.DbConstants.String255);
            });

            builder
                .HasOne(b => b.Tenant)
                .WithMany(p => p.Staffs)
                .HasForeignKey(p => p.TenantId);
            
        }
    }
}
