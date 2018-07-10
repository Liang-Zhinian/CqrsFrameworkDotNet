using System;
using System.Threading.Tasks;
using Business.Contracts.Events.Staffs;
using Business.Domain.Entities;
using Business.Domain.Entities.Schedules;

namespace Business.Application.Interfaces
{
    public interface IScheduleService
    {
        Task<Availability> AddAvailability(AddAvailabilityCommand addAvailabilityCommand);
        Task<Unavailability> AddUnavailability(AddUnavailabilityCommand addUnavailabilityCommand);
    }
}
