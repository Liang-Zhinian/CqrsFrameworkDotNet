using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Registration.Infrastructure.Context;

namespace Registration.Infrastructure
{
    public class ReservationContextFactory : IDesignTimeDbContextFactory<ReservationDbContext>
    {
        public ReservationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=book2public;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None;old guids=true");

            return new ReservationDbContext(optionsBuilder.Options);
        }
    }
}
