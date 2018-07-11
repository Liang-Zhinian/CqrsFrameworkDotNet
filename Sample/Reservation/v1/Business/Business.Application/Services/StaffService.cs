using System;
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
    public class StaffService:IStaffService
    {

        private readonly IBusinessIntegrationEventService _businessIntegrationEventService;
        private readonly IStaffRepository _staffRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IUnavailabilityRepository _unavailabilityRepository;

        public StaffService(
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

        public async Task<Staff> AddAvailability(AddAvailabilityCommand addAvailabilityCommand)
        {
            Staff staff = FindExistingStaff(addAvailabilityCommand.SiteId, addAvailabilityCommand.StaffId);
            Availability availability = staff.AddAvailability(addAvailabilityCommand.ServiceItemId,
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

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new AvailabilityAddedByStaffEvent(
                availability.StaffId,
                availability.SiteId,
                availability.StaffId,
                availability.ServiceItemId,
                availability.LocationId,
                availability.StartDateTime,
                availability.EndDateTime,
              addAvailabilityCommand.Sunday,
              addAvailabilityCommand.Monday,
              addAvailabilityCommand.Tuesday,
              addAvailabilityCommand.Wednesday,
              addAvailabilityCommand.Thursday,
              addAvailabilityCommand.Friday,
              addAvailabilityCommand.Saturday,
                availability.BookableEndDateTime
            ));

            //_staffRepository.UnitOfWork.Commit();

            return staff;
        }

        public async Task<Staff> AddUnavailability(AddUnavailabilityCommand addUnavailabilityCommand)
        {
            Staff staff = FindExistingStaff(addUnavailabilityCommand.SiteId, addUnavailabilityCommand.StaffId);
            Unavailability unavailability = staff.AddUnavailability(
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

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new UnavailabilityAddedByStaffEvent(
                unavailability.StaffId,
                unavailability.SiteId,
                unavailability.StaffId,
                unavailability.ServiceItemId,
                unavailability.LocationId,
                unavailability.StartDateTime,
                unavailability.EndDateTime,
                addUnavailabilityCommand.Sunday,
                addUnavailabilityCommand.Monday,
                addUnavailabilityCommand.Tuesday,
                addUnavailabilityCommand.Wednesday,
                addUnavailabilityCommand.Thursday,
                addUnavailabilityCommand.Friday,
                addUnavailabilityCommand.Saturday,
                unavailability.Description
            ));

            //_staffRepository.UnitOfWork.Commit();

            return staff;
        }

        private Staff FindExistingStaff(Guid siteId, Guid staffId){
            Staff staff = _staffRepository.Find(y => y.SiteId.Equals(siteId) && y.Id.Equals(staffId)).First();

            if (staff == null) throw new EntityNotFoundException(staffId, typeof(Staff).Name);

            return staff;
        }
    }
}
