using System;
using System.Threading.Tasks;
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


        public Availability AddAvailability(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, DateTime bookableEndTime)
        {
            Availability availability = new Availability(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, bookableEndTime);

            //if (Availibilities == null) Availibilities = new ObservableCollection<Availability>();

            //Availibilities.Add(availability);

            return availability;
        }

        public Unavailability AddUnavailability(Guid siteId, Guid staffId, Guid serviceItemId, Guid locationId, DateTime startTime, DateTime endTime, bool Sunday, bool Monday, bool Tuesday, bool Wednesday, bool Thursday, bool Friday, bool Saturday, string description)
        {
            Unavailability unavailability = new Unavailability(siteId, staffId, serviceItemId, locationId, startTime, endTime, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, description);

            //if (Unavailabilities == null) Unavailabilities = new ObservableCollection<Unavailability>();

            //Unavailabilities.Add(unavailability);

            return unavailability;
        }
    }
}
