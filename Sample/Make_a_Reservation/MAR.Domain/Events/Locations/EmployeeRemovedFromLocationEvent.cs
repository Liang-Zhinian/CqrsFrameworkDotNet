using System;
using MAR.Domain.Models.Employees;
using MAR.Domain.Models.Locations;

namespace MAR.Domain.Events.Locations
{
    public class EmployeeRemovedFromLocationEvent : BaseEvent
    {
        public readonly Location OldLocation;
        public readonly Employee Employee;

        public EmployeeRemovedFromLocationEvent(Guid id, Location oldLocation, Employee employee)
        {
            Id = id;
            OldLocation = oldLocation;
            Employee = employee;
        }
    }
}
