using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Contracts.Events.Schedules;
using Business.Domain.Entities.Schedules;
using Business.Domain.Repositories;

namespace Business.Domain.Services
{
    public class ScheduleService
    {
        private readonly IBusinessIntegrationEventService _businessIntegrationEventService;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IUnavailabilityRepository _unavailabilityRepository;

        public ScheduleService(IBusinessIntegrationEventService businessIntegrationEventService,
                               IAvailabilityRepository availabilityRepository, 
                               IUnavailabilityRepository unavailabilityRepository)
        {
            _businessIntegrationEventService = businessIntegrationEventService;
            _availabilityRepository = availabilityRepository;
            _unavailabilityRepository = unavailabilityRepository;
        }

        public IList<Availability> GetAvailabilitiesFor(Guid siteId, Guid serviceItemId){
            return _availabilityRepository.Find(y => y.SiteId.Equals(siteId) &&
                                                y.ServiceItemId.Equals(serviceItemId)).ToList();
        }

        public async Task<Availability> AddAvailability(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, DateTime bookableEndTime)
        {
            Availability availability = new Availability(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, bookableEndTime);

            //if (Availibilities == null) Availibilities = new ObservableCollection<Availability>();

            //Availibilities.Add(availability);

            _availabilityRepository.Add(availability);
            await _businessIntegrationEventService.PublishThroughEventBusAsync(new AvailabilityCreatedEvent(
                availability.Id,
                siteId,
                staffId,
                serviceItemId,
                locationId,
                startTime,
                endTime,
                Sunday,
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday,
                Saturday,
                bookableEndTime
            ));

            return availability;
        }

        public IList<Unavailability> GetUnavailabilitiesFor(Guid siteId, Guid serviceItemId)
        {
            return _unavailabilityRepository.Find(y => y.SiteId.Equals(siteId) &&
                                                y.ServiceItemId.Equals(serviceItemId)).ToList();
        }

        public async Task<Unavailability> AddUnavailability(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, string description)
        {
            Unavailability unavailability = new Unavailability(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, description);

            //if (Unavailabilities == null) Unavailabilities = new ObservableCollection<Unavailability>();

            //Unavailabilities.Add(unavailability);

            _unavailabilityRepository.Add(unavailability);

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new UnavailabilityCreatedEvent(
                unavailability.Id,
                siteId,
                staffId,
                serviceItemId,
                locationId,
                startTime,
                endTime,
                Sunday,
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday,
                Saturday,
                description
            ));

            return unavailability;
        }
    }
}
