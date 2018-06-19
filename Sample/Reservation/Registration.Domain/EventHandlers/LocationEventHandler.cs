using System;
using Business.Contracts.Events.Security.Locations;
using CqrsFramework.Events;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class LocationEventHandler : IEventHandler<LocationCreatedEvent>
    {
        private readonly ILocationRepository _locationRepository;

        public LocationEventHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public void Handle(LocationCreatedEvent @event)
        {
            // save to ReadDB
            Location location = new Location
                (
                    @event.Id,
                    @event.Name,
                    @event.Description,
                    @event.TenantId
                );

            _locationRepository.Add(location);
            _locationRepository.SaveChanges();

        }
    }
}
