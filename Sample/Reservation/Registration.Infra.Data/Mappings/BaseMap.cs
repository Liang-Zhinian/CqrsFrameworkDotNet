using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using Registration.Domain.ReadModel.Security;

namespace Registration.Infra.Data.Mappings
{
    public class BaseMap<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder, string tableName)
        {
            this.BuildPrimary(builder, tableName);
            
            //.ForMySQLHasCollation("utf8_general_ci");
            builder.Property<Guid>("TenantId")
                    .IsRequired()
                   .HasColumnName("TenantId").HasColumnType(Constants.DbConstants.KeyType);
            //.ForMySQLHasCollation("utf8_general_ci");

            builder.Property<Guid>("SiteId")
                    .IsRequired()
                   .HasColumnName("SiteId").HasColumnType(Constants.DbConstants.KeyType);
        }

        public virtual void BuildPrimary(EntityTypeBuilder<TEntity> builder, string tableName){
            builder.ForMySQLHasCharset("utf8");
            builder.ForMySQLHasCollation("utf8_general_ci");
            builder.HasKey("Id");
            builder.ToTable(tableName);
            builder.Property<Guid>("Id").HasColumnType(Constants.DbConstants.KeyType);
        }

        public virtual void MapToTenant(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasOne(typeof(Tenant).FullName, "Tenant")
                        .WithMany()
                   .HasForeignKey("TenantId")
                .IsRequired()
                //.HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual void MapToSite(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasOne(typeof(Site).FullName, "Site")
                        .WithMany()
                .HasForeignKey("SiteId")
                .IsRequired()
                        //.HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
