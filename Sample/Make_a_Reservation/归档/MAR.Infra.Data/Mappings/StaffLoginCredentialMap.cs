using System;
using System.ComponentModel.DataAnnotations.Schema;
using MAR.Infra.Data.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAR.Infra.Data.Mappings
{
    public class StaffLoginCredentialMap : IEntityTypeConfiguration<StaffLoginCredential>
    {
        public void Configure(EntityTypeBuilder<StaffLoginCredential> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("StaffLoginCredential");

            builder.Property<string>("UserName");
            builder.Property<string>("Password");

        }
    }
}
