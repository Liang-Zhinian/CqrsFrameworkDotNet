using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class SiteMap : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {

            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.SiteTable);
            builder.Property(_ => _.Id).HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").HasColumnType(Constants.DbConstants.String2000);
            builder.Property<bool>("Active");
            builder.Property<string>("Email").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("ContactName").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("PrimaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("SecondaryTelephone").HasColumnType(Constants.DbConstants.String255);
            builder.Property<byte[]>("Logo");
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor1").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor2").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor3").HasColumnType(Constants.DbConstants.String10);
            builder.Property<string>("PageColor4").HasColumnType(Constants.DbConstants.String10);
            builder.Property(_=>_.TenantId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);

            builder
                .HasOne(typeof(Tenant).FullName, "Tenant")
                        .WithMany()
                   .HasForeignKey("TenantId")
                        //.HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
