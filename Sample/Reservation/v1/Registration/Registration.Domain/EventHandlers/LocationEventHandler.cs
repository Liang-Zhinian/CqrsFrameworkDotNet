using System;
using System.Threading.Tasks;
using Business.Contracts.Events.Locations;
using CqrsFramework.Events;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class LocationEventHandler : IEventHandler<LocationCreatedEvent>,
                                        IEventHandler<LocationImageChangedEvent>,
                                        IEventHandler<LocationAddressChangedEvent>,
                                        IEventHandler<LocationGeolocationChangedEvent>
    {
        private readonly ILocationRepository _locationRepository;

        public LocationEventHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Task Handle(LocationCreatedEvent @event)
        {
            Console.WriteLine("Handling LocationCreatedEvent.");
            // save to ReadDB
            Location location = new Location
                (
                    @event.Id,
                    @event.Name,
                    @event.Description,
                    @event.SiteId
                );
            
            try
            {
                _locationRepository.Add(location);
                _locationRepository.SaveChanges();
                Console.WriteLine("LocationCreatedEvent handled.");
                return Task.CompletedTask;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                throw e;
            }
        }

        public Task Handle(LocationImageChangedEvent message)
        {
            var location = _locationRepository.Find(message.Id);
            location.Image = message.Image;
            _locationRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(LocationGeolocationChangedEvent message)
        {
            var location = _locationRepository.Find(message.Id);
            location.Latitude = message.Latitude;
            location.Longitude = message.Longitude;
            _locationRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(LocationAddressChangedEvent message)
        {
            var location = _locationRepository.Find(message.Id);

            location.StreetAddress = message.StreetAddress;
            location.StreetAddress2 = message.StreetAddress2;
            location.City = message.City;
            location.StateProvince = message.StateProvince;
            location.PostalCode = message.PostalCode;
            location.CountryCode = message.CountryCode;

            _locationRepository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
