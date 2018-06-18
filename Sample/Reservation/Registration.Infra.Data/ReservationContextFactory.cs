﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Registration.Infra.Data.Context;

namespace Registration.Infra.Data
{
    public class ReservationContextFactory : IDesignTimeDbContextFactory<ReservationDbContext>
    {
        public ReservationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
            optionsBuilder.UseMySql("Server=localhost;database=IdentityAccess;uid=root;pwd=P@ssword;charset=utf8;port=3306;SslMode=None");

            return new ReservationDbContext(optionsBuilder.Options);
        }
    }
}
