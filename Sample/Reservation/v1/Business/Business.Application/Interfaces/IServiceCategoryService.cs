using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Application.ViewModels;

namespace Business.Application.Interfaces
{
    public interface IServiceCategoryService : IDisposable
    {
        // service category service
        Task<ServiceItemViewModel> AddServiceItem(ServiceItemViewModel serviceItem);
        Task<ServiceCategoryViewModel> AddServiceCategory(ServiceCategoryViewModel serviceCategory);

    }
}
