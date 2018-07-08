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

namespace Business.Application.Services.Queries
{
    
    public class ServiceCategoryQueryService : IServiceCategoryQueryService
    {
        private readonly ISession _session;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceItemRepository _serviceItemRepository;
        private readonly IMapper _mapper;

        public ServiceCategoryQueryService(
                                        ISession session,
                                        IMapper mapper,
                                        IServiceCategoryRepository serviceCategoryRepository,
                                      IServiceItemRepository serviceItemRepository
                                     )
        {
            _session = session;
            _mapper = mapper;
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceItemRepository = serviceItemRepository;
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

        public Task<IEnumerable<ServiceItemViewModel>> FindServiceItems()
        {

            var serviceItems =
                _serviceItemRepository.Find(_ => true);

            var result = from service in serviceItems
                   select new ServiceItemViewModel
                   {
                       Id = service.Id,
                       Name = service.Name,
                       Description = service.Description,
                        ServiceCategoryId = service.ServiceCategoryId,
                        ServiceCategoryName = service.ServiceCategory.Name
                   };

            return Task.FromResult<IEnumerable<ServiceItemViewModel>>(result);
        }
    }
}
