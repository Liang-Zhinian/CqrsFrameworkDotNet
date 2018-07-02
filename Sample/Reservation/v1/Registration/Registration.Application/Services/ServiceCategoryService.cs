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
        //private readonly ISession _session;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceItemRepository _serviceRepository;
        //private readonly IMapper _mapper;
        //private readonly IEventPublisher _eventPublisher;

        public ServiceCategoryService(
            IServiceCategoryRepository serviceCategoryRepository,
                                        IServiceItemRepository serviceRepository
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

        public ServiceItem FindServiceItem(Guid serviceId)
        {
            var serviceItem =
            _serviceRepository.Find(serviceId);
            var serviceCategory = this.FindServiceCategory(serviceItem.ServiceCategoryId);

            return new ServiceItem(
                serviceCategory.SiteId,
                serviceCategory.Id,
                serviceItem.Name,
                serviceItem.Description,
                serviceItem.DefaultTimeLength
            );
        }

        public IEnumerable<ServiceItem> FindServiceItems()
        {

            var serviceItems =
                _serviceRepository.Find(_ => true)
                                  .Include(_=>_.ServiceCategory);

            return serviceItems;
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
            
            var category =
                _serviceCategoryRepository.Find(serviceCategoryId);

            return category;
        }

        #endregion

    }
}
