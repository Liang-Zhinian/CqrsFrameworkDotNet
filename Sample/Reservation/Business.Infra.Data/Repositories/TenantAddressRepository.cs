using System;
using System.Linq;
using Business.Domain.Models.Security;
using Business.Domain.Repositories.Interfaces;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class TenantAddressRepository : DomainRepository<TenantAddress>, ITenantAddressRepository
    {
        public TenantAddressRepository(BusinessDbContext context):base(context){}

    }
}
