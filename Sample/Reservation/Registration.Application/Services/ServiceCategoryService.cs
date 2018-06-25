using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Registration.Application.Interfaces;
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

        public Service FindService(Guid serviceId)
        {
            var service =
            _serviceRepository.Find(serviceId);
            var serviceCategory = this.FindServiceCategory(service.CategoryId);

            return new Service(
                serviceCategory.Id,
                service.Name,
                service.Description
            );
        }

        public IEnumerable<Service> FindServices()
        {

            var services =
                _serviceRepository.Find(_ => true)
                                  .Include(_=>_.Category);

            return services;
        }

        #endregion

        #region ServiceCategories

        public IEnumerable<ServiceCategory> FindServiceCategories()
        {

            var categories =
                _serviceCategoryRepository.Find(_ => true);

            return categories;
        }

        public ServiceCategory FindServiceCategory(Guid serviceCategoryId)
        {
            
            var categoriy =
                _serviceCategoryRepository.Find(serviceCategoryId);

            return categoriy;
        }

        #endregion

    }
}
