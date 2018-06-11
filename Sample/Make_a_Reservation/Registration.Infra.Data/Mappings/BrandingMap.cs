﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel.Security;

namespace Registration.Infra.Data.Mappings
{
    public class BrandingMap : IEntityTypeConfiguration<Branding>
    {
        public void Configure(EntityTypeBuilder<Branding> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.BrandingTable);

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("LogoURL");
            builder.Property<string>("PageColor1");
            builder.Property<string>("PageColor1");
            builder.Property<string>("PageColor2");
            builder.Property<string>("PageColor3");
            builder.Property<string>("PageColor4");
        }
    }
}
