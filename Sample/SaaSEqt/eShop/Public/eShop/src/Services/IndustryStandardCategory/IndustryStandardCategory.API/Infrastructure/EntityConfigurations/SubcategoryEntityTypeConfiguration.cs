﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using SaaSEqt.eShop.Services.IndustryStandardCategory.API.Model;

namespace SaaSEqt.eShop.Services.IndustryStandardCategory.API.Infrastructure.EntityConfigurations
{
    class SubcategoryEntityTypeConfiguration
        : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.ToTable("Subcategory");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                   .UseMySQLAutoIncrementColumn("subcategory_id")
               .IsRequired();

            builder.Property(cb => cb.Name)
                .IsRequired()
                   .HasMaxLength(255);

            builder.Property(cb => cb.CategoryName)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
