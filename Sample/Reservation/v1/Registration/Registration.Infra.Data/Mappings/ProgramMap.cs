using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel;

namespace Registration.Infrastructure.Mappings
{
    public class ProgramMap : BaseMap<Program>, IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            base.Configure(builder, Constants.DbConstants.ProgramTable);

            builder.Property<string>(_ => _.Name).IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<int>(_ => _.ScheduleTypeId).IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<int>(_ => _.CancelOffset);

            MapToSite(builder);
        }
    }
}
