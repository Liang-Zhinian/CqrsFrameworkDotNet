using System;
namespace Catalog.Api.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Model;
    using Microsoft.EntityFrameworkCore.Design;
    using Catalog.Api.Infrastructure.Mappings;

    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ServiceItemMap());
            modelBuilder.ApplyConfiguration(new ServiceCategoryMap());
        }
    }


    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
                .UseMySql("Server=localhost;database=book2;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None");

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}
