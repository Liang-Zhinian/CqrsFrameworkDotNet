using System;
using System.Linq;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infrastructure.Context;

namespace Business.Infrastructure.Repositories
{
    public class TenantContactRepository : DomainRepository<TenantContact>, ITenantContactRepository
    {
        public TenantContactRepository(BusinessDbContext context):base(context){}

    }
}
