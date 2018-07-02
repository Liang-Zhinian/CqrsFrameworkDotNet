using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Events.ServiceCategory;
using Business.Domain.Entities;
using Business.Domain.Entities.ServiceCategories;
using Business.Domain.Repositories;
using Business.Domain.Services;
using CqrsFramework.Domain;
using CqrsFramework.Events;

namespace Business.Application.Services
{
    
    public class ServiceCategoryService : IServiceCategoryService
    {
        //private readonly ISession _session;
        private readonly IIntegrationEventService _integrationEventService;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceItemRepository _serviceItemRepository;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;

        public ServiceCategoryService(
                                        IIntegrationEventService integrationEventService,
                                        IEventPublisher eventPublisher,
                                        //ISession session,
                                        IMapper mapper,
                                        IServiceCategoryRepository serviceCategoryRepository,
                                      IServiceItemRepository serviceItemRepository
                                     )
        {
            _integrationEventService = integrationEventService;
            _eventPublisher = eventPublisher;
            //_session = session;
            _mapper = mapper;
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceItemRepository = serviceItemRepository;
        }

        public void AddServiceItem(ServiceItemViewModel serviceItem)
        {
            var domainservice = new ServiceItem(
                serviceItem.SiteId,
                serviceItem.Name,
                serviceItem.Description,
                serviceItem.DefaultTimeLength,
                serviceItem.ServiceCategoryId
            );
            _serviceItemRepository.Add(domainservice);
            //_serviceItemRepository.SaveChanges();

            //_eventPublisher.Publish<ServiceCreatedEvent>(new ServiceCreatedEvent(Guid.NewGuid(),
            // service.Name,
            // service.Description,
            // service.ServiceCategoryId
            //));

            var serviceItemCreatedEvent = new ServiceItemCreatedEvent(Guid.NewGuid(),
                                                                                 serviceItem.Name,
                                                                                 serviceItem.Description,
                                                                      serviceItem.DefaultTimeLength,
                                                                                 serviceItem.ServiceCategoryId,
                                                                      serviceItem.SiteId
                                                                 );

            _integrationEventService.PublishThroughEventBus(serviceItemCreatedEvent);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ServiceItemViewModel FindServiceItem(Guid serviceItemId)
        {
            var service =
                _serviceItemRepository.Find(serviceItemId);

            return new ServiceItemViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,

            };
        }

        public IEnumerable<ServiceCategoryViewModel> FindServiceCategories()
        {

            var categories =
                _serviceCategoryRepository.Find(_ => true);

            return from category in categories
                   select new ServiceCategoryViewModel
                   {
                       Id = category.Id,
                       Name = category.Name,
                       Description = category.Description,

                   };
        }

        public ServiceCategoryViewModel FindServiceCategory(Guid serviceCategoryId)
        {

            var categoriy =
                _serviceCategoryRepository.Find(serviceCategoryId);

            return new ServiceCategoryViewModel
            {
                Id = categoriy.Id,
                Name = categoriy.Name,
                Description = categoriy.Description,
                ScheduleTypeId = categoriy.ScheduleTypeId,
                CancelOffset = categoriy.CancelOffset
            };
        }

        public IEnumerable<ServiceItemViewModel> FindServiceItems()
        {

            var serviceItems =
                _serviceItemRepository.Find(_ => true);

            return from service in serviceItems
                   select new ServiceItemViewModel
                   {
                       Id = service.Id,
                       Name = service.Name,
                       Description = service.Description,
                ServiceCategoryId = service.ServiceCategoryId,
                ServiceCategoryName = service.ServiceCategory.Name
                   };
        }

        public void AddServiceCategory(ServiceCategoryViewModel serviceCategory) {
            var domainServiceCategory = new ServiceCategory(
                serviceCategory.SiteId,
                serviceCategory.Name,
                serviceCategory.Description,
                serviceCategory.CancelOffset,
                serviceCategory.ScheduleTypeId
            );
            _serviceCategoryRepository.Add(domainServiceCategory);
            //_serviceCategoryRepository.SaveChanges();

            //_eventPublisher.Publish<ServiceCategoryCreatedEvent>(
            //new ServiceCategoryCreatedEvent(domainServiceCategory.Id,
            //serviceCategory.Name,
            //serviceCategory.Description,
            //serviceCategory.CancelOffset,
            //serviceCategory.ScheduleTypeId
            //));
            var serviceCategoryCreatedEvent = new ServiceCategoryCreatedEvent(domainServiceCategory.Id,
                           serviceCategory.Name,
                                                serviceCategory.Description,
                                                serviceCategory.CancelOffset,
                                                serviceCategory.ScheduleTypeId,
                                                                              serviceCategory.SiteId
                                                                             );

            _integrationEventService.PublishThroughEventBus(serviceCategoryCreatedEvent);
        }
    }
}
