using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.ReadModel;

namespace Registration.Infra.Data.Mappings
{
    public class HomePageImageMap : BaseMap<HomePageImage>, IEntityTypeConfiguration<HomePageImage>
    {
        public void Configure(EntityTypeBuilder<HomePageImage> builder)
        {
            //base.Configure(builder, Constants.DbConstants.LocationImageTable);
            builder.HasKey("Id");
            builder.ToTable("HomePageImageView");
            builder.Property<string>("Name").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<string>("Data").IsRequired().HasColumnType(Constants.DbConstants.MediumBlob);
            builder.Property<Guid>("CategoryId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("CategoryName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<Guid>("ParentCategoryId").IsRequired().HasColumnType(Constants.DbConstants.KeyType);
            builder.Property<string>("ParentCategoryName").IsRequired().HasColumnType(Constants.DbConstants.String255);
            builder.Property<int>("Version").IsRequired();


            builder
                .HasOne(b => b.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
            builder
                .HasOne(b => b.ParentCategory)
                .WithMany()
                .HasForeignKey(p => p.ParentCategoryId);
        }
    }
}
