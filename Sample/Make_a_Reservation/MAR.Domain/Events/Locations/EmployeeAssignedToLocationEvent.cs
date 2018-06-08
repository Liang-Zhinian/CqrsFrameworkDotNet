using System;
using MAR.Domain.Models.Employees;
using MAR.Domain.Models.Locations;

namespace MAR.Domain.Events.Locations
{
    public class EmployeeAssignedToLocationEvent : BaseEvent
    {
        public readonly Location NewLocation;
        public readonly Employee Employee;

        public EmployeeAssignedToLocationEvent(Guid id, Location newLocation, Employee employee)
        {
            Id = id;
            NewLocation = newLocation;
            Employee = employee;
        }
    }
}
