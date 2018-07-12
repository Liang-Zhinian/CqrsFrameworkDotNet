using System;
using System.Threading.Tasks;
using Business.Contracts.Events.Schedules;
using Business.Contracts.Events.ServiceCategory;
using CqrsFramework.Events;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;

namespace Registration.Domain.EventHandlers
{
    public class ServiceCategoryEventHandler : IEventHandler<ServiceItemCreatedEvent>,
                                                IEventHandler<ServiceCategoryCreatedEvent>,
                                                IEventHandler<AvailabilityCreatedEvent>,
                                                IEventHandler<UnavailabilityCreatedEvent>
    {
        private readonly IServiceItemRepository _serviceRepository;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IUnavailabilityRepository _unavailabilityRepository;

        public ServiceCategoryEventHandler(IServiceCategoryRepository serviceCategoryRepository,
                                           IServiceItemRepository serviceRepository,
                                           IAvailabilityRepository availabilityRepository,
                                           IUnavailabilityRepository unavailabilityRepository
                                          )
        {
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceRepository = serviceRepository;
            _availabilityRepository = availabilityRepository;
            _unavailabilityRepository = unavailabilityRepository;
        }

        public Task Handle(ServiceItemCreatedEvent @event)
        {
            Console.WriteLine("Handling ServiceItemCreatedEvent.");
            // save to ReadDB
            ServiceItem serviceItem = new ServiceItem(
                @event.SiteId,
                @event.Name,
                @event.Description,
                @event.DefaultTimeLength,
                @event.Price,
                @event.AllowOnlineScheduling,
                @event.ServiceCategoryId,
                @event.IndustryStandardCategoryId
            ); //_mapper.Map<LocationRM>(message);
            try
            {
                _serviceRepository.Add(serviceItem);
                _serviceRepository.SaveChanges();
                Console.WriteLine("ServiceItemCreatedEvent handled.");
                return Task.CompletedTask;
            }catch(Exception e){
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                throw e;
            }

        }

        public Task Handle(ServiceCategoryCreatedEvent message)
        {
            
            Console.WriteLine("ServiceCategoryCreatedEvent handled.");
            // save to ReadDB
            ServiceCategory serviceCategory = new ServiceCategory(
                message.Id,
                message.Name,
                message.Description,
                message.AllowOnlineScheduling,
                message.ScheduleTypeValue,
                message.SiteId
            ); //_mapper.Map<LocationRM>(message);
            try
            {
                _serviceCategoryRepository.Add(serviceCategory);
                _serviceCategoryRepository.SaveChanges();
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                throw e;
            }

        }

        public Task Handle(UnavailabilityCreatedEvent message)
        {
            Unavailability unavailability = new Unavailability(
                message.Id,
                message.SiteId,
                message.StaffId,
                message.ServiceItemId,
                message.LocationId,
                message.StartDateTime,
                message.EndDateTime,
                message.Sunday,
                message.Monday,
                message.Tuesday,
                message.Wednesday,
                message.Thursday,
                message.Friday,
                message.Saturday,
                message.Description);

            _unavailabilityRepository.Add(unavailability);
            _unavailabilityRepository.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(AvailabilityCreatedEvent message)
        {
            Availability availability = new Availability(
                message.Id,
                message.SiteId,
                message.StaffId,
                message.ServiceItemId,
                message.LocationId,
                message.StartDateTime,
                message.EndDateTime,
                message.Sunday,
                message.Monday,
                message.Tuesday,
                message.Wednesday,
                message.Thursday,
                message.Friday,
                message.Saturday,
                message.BookableEndDateTime);

            _availabilityRepository.Add(availability);
            _availabilityRepository.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
