using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class TenantMap : BaseMap<Tenant>, IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            base.Configure(builder, Constants.DbConstants.TenantTable);

            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("DisplayName").HasColumnType(Constants.DbConstants.String2000);
            //builder.Property<string>("Street").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Street2").HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("City").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("State").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("Country").IsRequired().HasColumnType(Constants.DbConstants.String255);
            //builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Email").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PrimaryTelephone").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("LogoURL").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor2").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor3").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor4").HasColumnType(Constants.DbConstants.String10);


            builder.OwnsOne(_ => _.PostalAddress, address => {
                address.Property("City").HasColumnType(Constants.DbConstants.String255);
                address.Property("CountryCode").HasColumnType(Constants.DbConstants.String255);
                address.Property("PostalCode").HasColumnType(Constants.DbConstants.String255);
                address.Property("StateProvince").HasColumnType(Constants.DbConstants.String255);
                address.Property("StreetAddress").HasColumnType(Constants.DbConstants.String255);
                address.Property("StreetAddress2").HasColumnType(Constants.DbConstants.String255);
            });

            builder.Ignore("Version");

        }
    }
}
