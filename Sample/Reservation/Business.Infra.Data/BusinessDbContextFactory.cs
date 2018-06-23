using Business.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Business.Infra.Data.Repositories
{
    public class IdentityAccessContextFactory : IDesignTimeDbContextFactory<BusinessDbContext>
    {
        public BusinessDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BusinessDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=book2site;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None");

            return new BusinessDbContext(optionsBuilder.Options);
        }
    }
}
