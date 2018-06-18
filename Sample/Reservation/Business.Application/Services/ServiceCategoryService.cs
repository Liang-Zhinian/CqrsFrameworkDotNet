using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.Interfaces;
using Business.Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Domain.Repositories.Interfaces;
using Business.Domain.Models.Security;
using CqrsFramework.Domain;
using SaaSEqt.IdentityAccess.Application;
using System.Linq;
using SaaSEqt.IdentityAccess.Application.Commands;
using Business.Domain.Models;
using CqrsFramework.Events;
using Business.Domain.Events.ServiceCategory;

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
                service.TenantId,
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
                TenantId = service.TenantId,
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
                       TenantId = service.TenantId,
                       Name = service.Name,
                       Description = service.Description,

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
                       TenantId = service.TenantId,
                       Name = service.Name,
                       Description = service.Description,
                       ServiceCategoryName = service.Category.Name
                   };
        }
    }
}
