using System;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infrastructure.Context;

namespace Business.Infrastructure.Repositories
{
    public class SiteRepository : DomainRepository<Site>, ISiteRepository
    {
        public SiteRepository(BusinessDbContext context) : base(context) { }

    }
}
