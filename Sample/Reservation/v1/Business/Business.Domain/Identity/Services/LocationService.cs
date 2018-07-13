using System;
using Business.Domain.Entities;
using Business.Domain.Repositories;
using CqrsFramework.Domain;

namespace Business.Domain.Services
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
