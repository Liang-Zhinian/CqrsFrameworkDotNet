using System;
using System.Linq;
using Business.Domain.Models.Security;
using Business.Domain.Repositories.Interfaces;
using Business.Infra.Data.Context;

namespace Business.Infra.Data.Repositories
{
    public class LocationRepository : DomainRepository<Location>, ILocationRepository
    {
        public LocationRepository(BusinessDbContext context):base(context){}

    }
}
