using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Application.ViewModels;

namespace SaaSEqt.eShop.Site.Api.Application.Interfaces
{
    public interface IServiceCategoryQueryService : IDisposable
    {
        // service category service
        IEnumerable<ServiceCategoryViewModel> FindServiceCategories();
        ServiceCategoryViewModel FindServiceCategory(Guid serviceCategoryId);
        Task<IEnumerable<ServiceItemViewModel>> FindServiceItems();
        ServiceItemViewModel FindServiceItem(Guid serviceItemId);

    }
}
