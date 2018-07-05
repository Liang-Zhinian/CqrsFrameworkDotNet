using System;
using CqrsFramework.EventStore.IntegrationEventLogEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Business.Infra.Data
{
    public class IntegrationEventLogContextDesignFactory : IDesignTimeDbContextFactory<IntegrationEventLogContext>
    {
        public IntegrationEventLogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IntegrationEventLogContext>();
            optionsBuilder.UseMySql("Server=localhost;database=book2;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None", b => b.MigrationsAssembly("Business.Infra.Data"));

            return new IntegrationEventLogContext(optionsBuilder.Options);
        }
    }
}
