using System;
using System.Linq;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class TenantAddressRepository : DomainRepository<TenantAddress>, ITenantAddressRepository
    {
        public TenantAddressRepository(BusinessDbContext context):base(context){}

    }
}
