using System;
using System.Collections.Generic;
using Business.Application.EventSourcedNormalizers;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface IServiceCategoryService : IDisposable
    {
        // service category service
        IEnumerable<ServiceCategoryViewModel> FindServiceCategories();
        ServiceCategoryViewModel FindServiceCategory(Guid serviceCategoryId);
        IEnumerable<ServiceViewModel> FindServices();
        ServiceViewModel FindService(Guid serviceId);
        void AddService(ServiceViewModel service);
        void AddServiceCategory(ServiceCategoryViewModel serviceCategory);

    }
}
