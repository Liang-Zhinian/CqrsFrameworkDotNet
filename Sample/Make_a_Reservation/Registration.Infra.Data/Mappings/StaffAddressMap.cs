﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class StaffAddressMap : IEntityTypeConfiguration<StaffAddress>
    {
        public void Configure(EntityTypeBuilder<StaffAddress> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("StaffAddress");

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("Street");
            builder.Property<string>("Street2");
            builder.Property<string>("City");
            builder.Property<string>("State");
            builder.Property<string>("Country");
            builder.Property<string>("ForeignZip");

        }
    }
}
