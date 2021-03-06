﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSEqt.IdentityAccess.Domain.Identity.Entities;
using SaaSEqt.IdentityAccess.Infra.Data.Mappings.Constants;

namespace SaaSEqt.IdentityAccess.Infra.Data.Mappings
{
    public class UserMap : EntityWithCompositeIdMap<User>, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder, DbConstants.UserTable);

            builder.Property<string>("Username").HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Password").HasColumnType(Constants.DbConstants.String255);
            builder.OwnsOne(_ => _.Enablement, et => {
                //et.Property("UserId").HasColumnType(Constants.DbConstants.KeyType);
                et.Property<bool>(_ => _.Enabled).IsRequired();
                et.Property<DateTime>("StartDate");
                et.Property<DateTime>("EndDate");
            });
            builder.Ignore(_ => _.UserDescriptor);
            builder.Ignore(_ => _.Person);

            MapToTenant(builder);
        }
    }
}
