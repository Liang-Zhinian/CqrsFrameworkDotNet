using System;
using System.Threading.Tasks;
using Business.Contracts.Events.Staffs;
using Business.Domain.Entities;

namespace Business.Application.Interfaces
{
    public interface IStaffService
    {
        Task<Staff> AddAvailability(AddAvailabilityCommand addAvailabilityCommand);
        Task<Staff> AddUnavailability(AddUnavailabilityCommand addUnavailabilityCommand);
    }
}
