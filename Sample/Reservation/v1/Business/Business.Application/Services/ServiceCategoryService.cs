using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Commands.ServiceCategories;
using Business.Contracts.Events.Schedules;
using Business.Contracts.Events.ServiceCategory;
using Business.Domain.Entities.Schedules;
using Business.Domain.Entities.ServiceCategories;
using Business.Domain.Repositories;
using Business.Domain.Services;
using Infrastructure;

namespace Business.Application.Services
{

    public class ServiceCategoryService : IServiceCategoryService
    {
        //private readonly ISession _session;
        private readonly IBusinessIntegrationEventService _businessIntegrationEventService;
        private readonly IMapper _mapper;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceItemRepository _serviceItemRepository;

        public ServiceCategoryService(
            //ISession session,
                                          IBusinessIntegrationEventService businessIntegrationEventService,
                                        IMapper mapper,
            IServiceCategoryRepository serviceCategoryRepository,
            IServiceItemRepository serviceItemRepository
                                     )
        {
            //_session = session;
            _businessIntegrationEventService = businessIntegrationEventService;
            _mapper = mapper;
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceItemRepository = serviceItemRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<ServiceItemViewModel> AddServiceItem(ServiceItemViewModel serviceItem)
        {
            var domainservice = new ServiceItem(
                serviceItem.SiteId,
                serviceItem.Name,
                serviceItem.Description,
                serviceItem.DefaultTimeLength,
                serviceItem.Price,
                serviceItem.ServiceCategoryId,
                serviceItem.IndustryStandardCategoryId
            );
            _serviceItemRepository.Add(domainservice);

            var serviceItemCreatedEvent = new ServiceItemCreatedEvent(
                domainservice.SiteId,
                domainservice.Id,
                domainservice.Name,
                domainservice.Description,
                domainservice.DefaultTimeLength,
                domainservice.Price,
                domainservice.AllowOnlineScheduling,
                domainservice.ServiceCategoryId,
                domainservice.IndustryStandardCategoryId
            );
            
            await _businessIntegrationEventService.PublishThroughEventBusAsync(serviceItemCreatedEvent);

            //_session.Add<ServiceItem>(domainservice);
            //_session.Commit();

            serviceItem.Id = domainservice.Id;

            return serviceItem;
        }

        public async Task<ServiceCategoryViewModel> AddServiceCategory(ServiceCategoryViewModel serviceCategory) {
            var domainServiceCategory = new ServiceCategory(
                serviceCategory.SiteId,
                serviceCategory.Name,
                serviceCategory.Description,
                serviceCategory.AllowOnlineScheduling,
                serviceCategory.ScheduleTypeId
            );

            _serviceCategoryRepository.Add(domainServiceCategory);

            //_session.Add<ServiceCategory>(domainServiceCategory);
            //_session.Commit();

            var serviceCategoryCreatedEvent = new ServiceCategoryCreatedEvent(
                                                                              domainServiceCategory.SiteId,
                                                                                domainServiceCategory.Id,
                                                                              domainServiceCategory.Name,
                                                                              domainServiceCategory.Description,
                                                                                domainServiceCategory.AllowOnlineScheduling,
                                                                              domainServiceCategory.ScheduleTypeId
                                                                             );

            await _businessIntegrationEventService.PublishThroughEventBusAsync(serviceCategoryCreatedEvent);

            serviceCategory.Id = domainServiceCategory.Id;

            return serviceCategory;
        }

        public async Task<Availability> AddAvailability(AddAvailabilityCommand addAvailabilityCommand)
        {
            ServiceItem serviceItem = GetExistingServiceItem(addAvailabilityCommand.SiteId, addAvailabilityCommand.ServiceItemId);

            Availability availability = serviceItem.AddAvailability(
                addAvailabilityCommand.StaffId,
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

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new AvailabilityCreatedEvent(
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

            return availability;
        }

        public async Task<Unavailability> AddUnavailability(AddUnavailabilityCommand addUnavailabilityCommand)
        {
            ServiceItem serviceItem = GetExistingServiceItem(addUnavailabilityCommand.SiteId, addUnavailabilityCommand.ServiceItemId);

            Unavailability unavailability = serviceItem.AddUnavailability(
                addUnavailabilityCommand.StaffId,
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

            await _businessIntegrationEventService.PublishThroughEventBusAsync(new UnavailabilityCreatedEvent(
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

            return unavailability;
        }

        private ServiceItem GetExistingServiceItem(Guid siteId, Guid serviceItemId){
            var serviceItem = _serviceItemRepository.Find(y => y.SiteId.Equals(siteId) &&
                                                          y.Id.Equals(serviceItemId)).First();

            if (serviceItem == null) throw new EntityNotFoundException(serviceItemId, typeof(ServiceItem).FullName);

            return serviceItem;
        }
    }
}
