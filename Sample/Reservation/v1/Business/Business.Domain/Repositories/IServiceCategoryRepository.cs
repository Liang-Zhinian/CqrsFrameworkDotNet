using System;
using System.Collections.Generic;
using System.Linq;
using Business.Domain.Entities;
using Business.Domain.Entities.ServiceCategories;

namespace Business.Domain.Repositories
{
    public interface IServiceCategoryRepository : IDomainRepository<ServiceCategory>
    {
        //GetBusinessLocationsWithinRadius
        //GetLocations
    }
}
