using System;
using System.Linq;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class TenantContactRepository : DomainRepository<TenantContact>, ITenantContactRepository
    {
        public TenantContactRepository(BusinessDbContext context):base(context){}

    }
}
