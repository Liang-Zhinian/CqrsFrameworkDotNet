using System;
using System.Collections.Generic;
using Registration.Application.EventSourcedNormalizers;
using Registration.Application.ViewModels;

namespace Registration.Application.Interfaces
{
    public interface IServiceCategoryService : IDisposable
    {
        // service category service
        IEnumerable<ServiceCategoryViewModel> FindServiceCategories();
        ServiceCategoryViewModel FindServiceCategory(Guid serviceCategoryId);
        IEnumerable<ServiceViewModel> FindServices();
        IEnumerable<ServiceViewModel> FindServicesByTenant(Guid tenantId);
        ServiceViewModel FindService(Guid serviceId);
        //void AddService(ServiceViewModel service);

    }
}
