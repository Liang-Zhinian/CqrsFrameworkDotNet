using Business.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Business.Infrastructure
{
    public class IdentityAccessContextFactory : IDesignTimeDbContextFactory<BusinessDbContext>
    {
        public BusinessDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BusinessDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=book2business;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None");

            return new BusinessDbContext(optionsBuilder.Options);
        }
    }
}
