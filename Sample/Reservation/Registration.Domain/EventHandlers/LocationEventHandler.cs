using System;
using Business.Contracts.Events.Locations;
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
            Console.WriteLine("Handling LocationCreatedEvent.");
            // save to ReadDB
            Location location = new Location
                (
                    @event.Id,
                    @event.Name,
                    @event.Description,
                    @event.SiteId,
                    @event.TenantId
                );

            try
            {
                _locationRepository.Add(location);
                _locationRepository.SaveChanges();
                Console.WriteLine("LocationCreatedEvent handled.");
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                throw e;
            }
        }
    }
}
