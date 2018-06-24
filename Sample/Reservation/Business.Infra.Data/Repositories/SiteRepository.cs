using System;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class SiteRepository : DomainRepository<Site>, ISiteRepository
    {
        public SiteRepository(BusinessDbContext context) : base(context) { }

    }
}
