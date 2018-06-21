using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Registration.Application.Interfaces;
using Registration.Application.ViewModels;
using Registration.Domain.ReadModel;
using Registration.Domain.Repositories.Interfaces;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Microsoft.EntityFrameworkCore;

namespace Registration.Application.Services
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly ISession _session;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;

        public ServiceCategoryService(
            IServiceCategoryRepository serviceCategoryRepository,
                                        IServiceRepository serviceRepository
                                     )
        {
            //_eventPublisher = eventPublisher;
            //_session = session;
            //_mapper = mapper;
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceRepository = serviceRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region Services

        public ServiceViewModel FindService(Guid serviceId)
        {
            var service =
            _serviceRepository.Find(serviceId);
            var serviceCategory = this.FindServiceCategory(service.CategoryId);

            return new ServiceViewModel
            {
                Id = service.Id,
                TenantId = service.TenantId,
                Name = service.Name,
                Description = service.Description,
                ServiceCategoryId = serviceCategory.Id,
                ServiceCategoryName = serviceCategory.Name
            };
        }

        public IEnumerable<ServiceViewModel> FindServices()
        {

            var services =
                _serviceRepository.Find(_ => true)
                                  .Include(_=>_.Category);

            return from service in services
                   select new ServiceViewModel
                   {
                       Id = service.Id,
                       TenantId = service.TenantId,
                       Name = service.Name,
                        Description = service.Description,
                        ServiceCategoryId = service.Category.Id,
                        ServiceCategoryName = service.Category.Name,
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

        #endregion

        #region ServiceCategories

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

        #endregion

    }
}
