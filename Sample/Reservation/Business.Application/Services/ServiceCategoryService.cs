using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using Business.Contracts.Events.ServiceCategory;
using Business.Domain.Models;
using Business.Domain.Repositories.Interfaces;
using CqrsFramework.Domain;
using CqrsFramework.Events;

namespace Business.Application.Services
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly ISession _session;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;

        public ServiceCategoryService(IEventPublisher eventPublisher,
                                        ISession session,
                                        IMapper mapper,
                                        IServiceCategoryRepository serviceCategoryRepository,
                                        IServiceRepository serviceRepository
                                     )
        {
            _eventPublisher = eventPublisher;
            _session = session;
            _mapper = mapper;
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceRepository = serviceRepository;
        }

        public void AddService(ServiceViewModel service)
        {
            var domainservice = new Service(
                new TenantId(service.TenantId.ToString()),
                service.ServiceCategoryId,
                service.Name,
                service.Description
            );
            _serviceRepository.Add(domainservice);
            _serviceRepository.SaveChanges();

            _eventPublisher.Publish<ServiceCreatedEvent>(new ServiceCreatedEvent(Guid.NewGuid(),
                                                                                 service.Name,
                                                                                 service.Description,
                                                                                 service.ServiceCategoryId,
                                                                                 service.TenantId
                                                                                ));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ServiceViewModel FindService(Guid serviceId)
        {
            var service =
            _serviceRepository.Find(serviceId);

            return new ServiceViewModel
            {
                Id = service.Id,
                TenantId = Guid.Parse(service.TenantId.Id),
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
                       //TenantId = category.,
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
                //TenantId = category.,
                Name = categoriy.Name,
                Description = categoriy.Description,
                ScheduleType = categoriy.ScheduleTypeValue,
                CancelOffset = categoriy.CancelOffset
            };
        }

        public IEnumerable<ServiceViewModel> FindServices()
        {

            var services =
            _serviceRepository.Find(_ => true);

            return from service in services
                   select new ServiceViewModel
                   {
                       Id = service.Id,
                TenantId = Guid.Parse(service.TenantId.Id),
                       Name = service.Name,
                       Description = service.Description,
                ServiceCategoryId = service.CategoryId,
                ServiceCategoryName = service.Category.Name
                   };
        }

        public IEnumerable<ServiceViewModel> FindServicesByTenant(Guid tenantId)
        {
            var services =
                _serviceRepository.Find(_ => _.TenantId.Equals(tenantId));

            return from service in services
                   select new ServiceViewModel
                   {
                       Id = service.Id,
                TenantId = Guid.Parse(service.TenantId.Id),
                       Name = service.Name,
                       Description = service.Description,
                       ServiceCategoryName = service.Category.Name
                   };
        }

        public void AddServiceCategory(ServiceCategoryViewModel serviceCategory) {
            var domainServiceCategory = new ServiceCategory(
                serviceCategory.Name,
                serviceCategory.Description
            );
            _serviceCategoryRepository.Add(domainServiceCategory);
            _serviceCategoryRepository.SaveChanges();

            _eventPublisher.Publish<ServiceCategoryCreatedEvent>(new ServiceCategoryCreatedEvent(domainServiceCategory.Id,
                                                                                         serviceCategory.Name,
                                                                                         serviceCategory.Description,
                                                                                                 serviceCategory.CancelOffset,
                                                                                                 serviceCategory.ScheduleType
                                                                                ));
        }
    }
}
