using System;
using System.Linq;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class ServiceCategoryRepository : DomainRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(BusinessDbContext context):base(context){}

    }
}
