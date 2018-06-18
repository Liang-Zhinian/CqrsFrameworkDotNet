using System;
using System.Linq;
using Business.Domain.Models.Security;
using Business.Domain.Repositories.Interfaces;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class TenantContactRepository : DomainRepository<TenantContact>, ITenantContactRepository
    {
        public TenantContactRepository(BusinessDbContext context):base(context){}

    }
}
