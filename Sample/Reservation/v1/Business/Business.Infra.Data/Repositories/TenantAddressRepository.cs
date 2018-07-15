using System;
using System.Linq;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infrastructure.Context;

namespace Business.Infrastructure.Repositories
{
    public class TenantAddressRepository : DomainRepository<TenantAddress>, ITenantAddressRepository
    {
        public TenantAddressRepository(BusinessDbContext context):base(context){}

    }
}
