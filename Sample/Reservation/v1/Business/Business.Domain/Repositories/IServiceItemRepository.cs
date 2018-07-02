using System;
using System.Collections.Generic;
using System.Linq;
using Business.Domain.Entities.ServiceCategories;

namespace Business.Domain.Repositories
{
    public interface IServiceItemRepository : IDomainRepository<ServiceItem>
    {
        //GetBusinessLocationsWithinRadius
        //GetLocations
    }
}