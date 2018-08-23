using System;
using Business.Domain.Identity.Entities;
using Business.Domain.Identity.Repositories;
using Business.Domain.SeedWork;
using CqrsFramework.Domain;

namespace Business.Domain.Identity.Services
{
    public class LocationService
    {
        private readonly IBusinessIntegrationEventService _businessIntegrationEventService;
        private readonly ILocationRepository _locationRepository;

        public LocationService(IBusinessIntegrationEventService businessIntegrationEventService,
                               ILocationRepository locationRepository)
        {
            _businessIntegrationEventService = businessIntegrationEventService;
            _locationRepository = locationRepository;
        }
    }
}
