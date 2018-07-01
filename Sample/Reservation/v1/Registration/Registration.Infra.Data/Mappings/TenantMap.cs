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
            base.BuildPrimary(builder, Constants.DbConstants.TenantTable);

            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);

            builder.Property<string>("Email").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PrimaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<byte[]>("Logo").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor2").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor3").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor4").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("City").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("CountryCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PostalCode").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StateProvince").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StreetAddress").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("StreetAddress2").HasColumnType(Constants.DbConstants.String255);

        }
    }
}
