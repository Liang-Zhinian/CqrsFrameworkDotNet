using System;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Infra.Data.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Business.Infra.Data.Mappings
{
    public class ResourceStatusMap : IEntityTypeConfiguration<ResourceStatus>
    {
        public void Configure(EntityTypeBuilder<ResourceStatus> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable(Constants.DbConstants.ResourceStatusTable);

            builder.Property<int>("Id").IsRequired();
            builder.Property<string>("Label").IsRequired().HasColumnType(Constants.DbConstants.String255);

            builder
                .HasOne(p => p.Resource)
                .WithOne(p => p.Status)
                .HasForeignKey<Resource>(p=>p.StatusId);
        }
    }
}
