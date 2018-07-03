﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using SaaSEqt.IdentityAccess.Domain.Entities;

namespace SaaSEqt.IdentityAccess.Infra.Data.Mappings
{
    public class BaseMap<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder, string tableName)
        {
            builder.ForMySQLHasCharset("utf8");
            builder.ForMySQLHasCollation("utf8_general_ci");
            builder.HasKey("Id");
            builder.ToTable(tableName);
            builder.Property("Id")
                   //.HasColumnType(Constants.DbConstants.KeyType)
                   .ForMySQLHasCollation("utf8_general_ci");
            builder.Property<string>("TenantId_Id")
            .IsRequired()
                   .HasColumnType(Constants.DbConstants.String36)
            .HasColumnName("TenantId_Id")
            .ForMySQLHasCollation("utf8_general_ci");
            //builder.OwnsOne(typeof(TenantId), "TenantId", 
            //builder.OwnsOne(typeof(TenantId), "TenantId", cb =>
            //{
            //    //cb.Property<string>("TenantId_Id");
            //    cb.Property("Id")
            //    .IsRequired()
            //    .HasColumnType(Constants.DbConstants.KeyType)
            //    .HasColumnName("TenantId_Id")
            //      .ForMySQLHasCollation("utf8_general_ci");

            //}).HasAlternateKey("TenantId_Id");

            builder.Ignore(typeof(TenantId).FullName);
        }

        public virtual void MapToTenant(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasOne(typeof(Tenant).FullName, "Tenant")
                        .WithMany()
                   .HasForeignKey("TenantId_Id")
                .HasPrincipalKey("TenantId_Id")
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}