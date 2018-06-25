﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Domain.Entities;

namespace Business.Domain.Repositories
{
    public interface ILocationRepository: IDomainRepository<Location>
    {
        //GetBusinessLocationsWithinRadius
        //GetLocations
    }
}