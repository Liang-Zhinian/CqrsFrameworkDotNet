using System;
using System.Collections.Generic;
using System.Linq;
using Business.Domain.Catalog.SchedulableCatalog.Entities;
using Business.Domain.SeedWork;

namespace Business.Domain.Catalog.SchedulableCatalog.Repositories
{
    public interface IServiceItemRepository : IDomainRepository<SchedulableCatalogItem>
    {
        //GetBusinessLocationsWithinRadius
        //GetLocations
    }
}