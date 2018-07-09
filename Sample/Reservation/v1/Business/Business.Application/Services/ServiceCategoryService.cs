using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                serviceCategory.CancelOffset,
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
                                                                              domainServiceCategory.CancelOffset,
                                                                              domainServiceCategory.ScheduleTypeId
                                                                             );

            await _businessIntegrationEventService.PublishThroughEventBusAsync(serviceCategoryCreatedEvent);

            serviceCategory.Id = domainServiceCategory.Id;

            return serviceCategory;
        }
    }
}
