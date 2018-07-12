using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel;

namespace Registration.Infra.Data.Mappings
{
    public class ServiceCategoryMap : BaseMap<ServiceCategory>, IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            base.Configure(builder, Constants.DbConstants.ServiceCategoryTable);
            //builder.HasKey(o => o.Id);
            //builder.ToTable(Constants.DbConstants.ServiceCategoryTable);

            //builder.Property<Guid>("Id");
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Description").IsRequired().HasColumnType(Constants.DbConstants.String2000);
            builder.Property<bool>("AllowOnlineScheduling").IsRequired();
            builder.Property<int>("ScheduleTypeId").IsRequired();

            MapToSite(builder);
        }
    }
}
