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
        private readonly ISession _session;
        private readonly IMapper _mapper;

        public ServiceCategoryService(
                                        ISession session,
                                        IMapper mapper
                                     )
        {
            _session = session;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<ServiceItemViewModel> AddServiceItem(ServiceItemViewModel serviceItem)
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

            _session.Add<ServiceItem>(domainservice);
            _session.Commit();

            serviceItem.Id = domainservice.Id;

            return Task.FromResult<ServiceItemViewModel>(serviceItem);
        }

        public Task<ServiceCategoryViewModel> AddServiceCategory(ServiceCategoryViewModel serviceCategory) {
            var domainServiceCategory = new ServiceCategory(
                serviceCategory.SiteId,
                serviceCategory.Name,
                serviceCategory.Description,
                serviceCategory.CancelOffset,
                serviceCategory.ScheduleTypeId
            );

            _session.Add<ServiceCategory>(domainServiceCategory);
            _session.Commit();

            serviceCategory.Id = domainServiceCategory.Id;

            return Task.FromResult<ServiceCategoryViewModel>(serviceCategory);
        }
    }
}
