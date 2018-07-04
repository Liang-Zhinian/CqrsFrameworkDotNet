using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Application.EventSourcedNormalizers;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface IServiceCategoryService : IDisposable
    {
        // service category service
        IEnumerable<ServiceCategoryViewModel> FindServiceCategories();
        ServiceCategoryViewModel FindServiceCategory(Guid serviceCategoryId);
        Task<IEnumerable<ServiceItemViewModel>> FindServiceItems();
        ServiceItemViewModel FindServiceItem(Guid serviceItemId);
        Task<ServiceItemViewModel> AddServiceItem(ServiceItemViewModel serviceItem);
        Task<ServiceCategoryViewModel> AddServiceCategory(ServiceCategoryViewModel serviceCategory);

    }
}
