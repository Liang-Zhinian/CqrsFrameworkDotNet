using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Application.ViewModels;
using Business.Contracts.Commands.ServiceCategories;
using Business.Domain.Entities.Schedules;

namespace Business.Application.Interfaces
{
    public interface IServiceCategoryService : IDisposable
    {
        // service category service
        Task<ServiceItemViewModel> AddServiceItem(ServiceItemViewModel serviceItem);
        Task<ServiceCategoryViewModel> AddServiceCategory(ServiceCategoryViewModel serviceCategory);
        Task<Availability> AddAvailability(AddAvailabilityCommand addAvailabilityCommand);
        Task<Unavailability> AddUnavailability(AddUnavailabilityCommand addUnavailabilityCommand);

    }
}
