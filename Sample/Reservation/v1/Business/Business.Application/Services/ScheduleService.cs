using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Application.Interfaces;
using Business.Contracts.Commands.ServiceCategories;
using Business.Contracts.Events.Staffs;
using Business.Domain.Entities;
using Business.Domain.Entities.Schedules;
using Business.Domain.Repositories;
using Business.Domain.Services;
using Infrastructure;

namespace Business.Application.Services
{
    public class ScheduleService:IScheduleService
    {

        private readonly IBusinessIntegrationEventService _businessIntegrationEventService;
        private readonly IStaffRepository _staffRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IUnavailabilityRepository _unavailabilityRepository;

        public ScheduleService(
            IBusinessIntegrationEventService businessIntegrationEventService,
            IStaffRepository staffRepository,
            IAvailabilityRepository availabilityRepository,
            IUnavailabilityRepository unavailabilityRepository)
        {
            _businessIntegrationEventService = businessIntegrationEventService;
            _staffRepository = staffRepository;
            _availabilityRepository = availabilityRepository;
            _unavailabilityRepository = unavailabilityRepository;
        }



        public IList<Availability> GetAvailabilitiesFor(Guid siteId, Guid serviceItemId)
        {
            return _availabilityRepository.Find(y => y.SiteId.Equals(siteId) &&
                                                y.ServiceItemId.Equals(serviceItemId)).ToList();
        }

        public async Task<Availability> AddAvailability(AddAvailabilityCommand addAvailabilityCommand)
        {
            Availability availability = new Availability(
                addAvailabilityCommand.SiteId,
                addAvailabilityCommand.StaffId,
                addAvailabilityCommand.ServiceItemId,
                addAvailabilityCommand.LocationId,
                addAvailabilityCommand.StartDateTime,
                addAvailabilityCommand.EndDateTime,
                addAvailabilityCommand.Sunday,
                addAvailabilityCommand.Monday,
                addAvailabilityCommand.Tuesday,
                addAvailabilityCommand.Wednesday,
                addAvailabilityCommand.Thursday,
                addAvailabilityCommand.Friday,
                addAvailabilityCommand.Saturday,
                addAvailabilityCommand.BookableEndDateTime);

            _availabilityRepository.Add(availability);

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new AvailabilityAddedByStaffEvent(
                availability.StaffId,
                availability.SiteId,
                availability.StaffId,
                availability.ServiceItemId,
                availability.LocationId,
                availability.StartDateTime,
                availability.EndDateTime,
                availability.Sunday,
                availability.Monday,
                availability.Tuesday,
                availability.Wednesday,
                availability.Thursday,
                availability.Friday,
                availability.Saturday,
                availability.BookableEndDateTime
            ));

            //_availabilityRepository.UnitOfWork.Commit();

            return availability;
        }

        public async Task<Unavailability> AddUnavailability(AddUnavailabilityCommand addUnavailabilityCommand)
        {
            Unavailability unavailability = new Unavailability(
                addUnavailabilityCommand.SiteId,
                addUnavailabilityCommand.StaffId,
                addUnavailabilityCommand.ServiceItemId,
                addUnavailabilityCommand.LocationId,
                addUnavailabilityCommand.StartDateTime,
                addUnavailabilityCommand.EndDateTime,
                addUnavailabilityCommand.Sunday,
                addUnavailabilityCommand.Monday,
                addUnavailabilityCommand.Tuesday,
                addUnavailabilityCommand.Wednesday,
                addUnavailabilityCommand.Thursday,
                addUnavailabilityCommand.Friday,
                addUnavailabilityCommand.Saturday,
                addUnavailabilityCommand.Description);

            _unavailabilityRepository.Add(unavailability);

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new UnavailabilityAddedByStaffEvent(
                unavailability.StaffId,
                unavailability.SiteId,
                unavailability.StaffId,
                unavailability.ServiceItemId,
                unavailability.LocationId,
                unavailability.StartDateTime,
                unavailability.EndDateTime,
                unavailability.Sunday,
                unavailability.Monday,
                unavailability.Tuesday,
                unavailability.Wednesday,
                unavailability.Thursday,
                unavailability.Friday,
                unavailability.Saturday,
                unavailability.Description
            ));

            //_unavailabilityRepository.UnitOfWork.Commit();

            return unavailability;
        }

        private Staff FindExistingStaff(Guid siteId, Guid staffId){
            Staff staff = _staffRepository.Find(y => y.SiteId.Equals(siteId) && y.Id.Equals(staffId)).First();

            if (staff == null) throw new EntityNotFoundException(staffId, typeof(Staff).Name);

            return staff;
        }
    }
}
