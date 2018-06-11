using System;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.ReadModel.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registration.Infra.Data.Mappings
{
    public class StaffLoginCredentialMap : IEntityTypeConfiguration<StaffLoginCredential>
    {
        public void Configure(EntityTypeBuilder<StaffLoginCredential> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.StaffLoginCredentialTable);

            builder.Property<string>("Id").HasColumnType("char(32)");
            builder.Property<string>("UserName");
            builder.Property<string>("Password");

        }
    }
}
