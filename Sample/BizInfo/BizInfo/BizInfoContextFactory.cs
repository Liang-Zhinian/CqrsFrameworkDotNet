using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SaaSEqt.BizInfo
{
    public class IdentityAccessContextFactory : IDesignTimeDbContextFactory<BizInfoDbContext>
    {
        public BizInfoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BizInfoDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=IdentityAccess;uid=root;pwd=P@ssword;oldguids=true;SslMode=None");

            return new BizInfoDbContext(optionsBuilder.Options);
        }
    }
}
