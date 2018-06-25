using System;
using System.Collections.Generic;
using Registration.Application.EventSourcedNormalizers;
using Registration.Domain.ReadModel;

namespace Registration.Application.Interfaces
{
    public interface IServiceCategoryService : IDisposable
    {
        // service category service
        IEnumerable<ServiceCategory> FindServiceCategories();
        ServiceCategory FindServiceCategory(Guid serviceCategoryId);
        IEnumerable<Service> FindServices();
        Service FindService(Guid serviceId);
        //void AddService(ServiceViewModel service);

    }
}
