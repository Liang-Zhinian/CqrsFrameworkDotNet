using System;
using System.Linq;
using Business.Domain.Models;
using Business.Domain.Repositories.Interfaces;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class ServiceRepository : DomainRepository<Service>, IServiceRepository
    {
        public ServiceRepository(BusinessDbContext context):base(context){}

    }
}
