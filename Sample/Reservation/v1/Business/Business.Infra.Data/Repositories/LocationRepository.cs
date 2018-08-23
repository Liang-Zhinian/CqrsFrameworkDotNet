using System;
using System.Linq;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using Business.Infrastructure.Context;

namespace Business.Infrastructure.Repositories
{
    public class LocationRepository : DomainRepository<Location>, ILocationRepository
    {
        public LocationRepository(BusinessDbContext context):base(context){}

    }
}
