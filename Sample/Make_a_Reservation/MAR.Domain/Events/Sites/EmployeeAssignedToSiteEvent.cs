using System;
using MAR.Domain.Models.Businesses;
using MAR.Domain.Models.Employees;

namespace MAR.Domain.Events.Locations
{
    public class EmployeeAssignedToSiteEvent : BaseEvent
    {
        public readonly Site NewSite;
        public readonly Employee Employee;

        public EmployeeAssignedToSiteEvent(Guid id, Site newSite, Employee employee)
        {
            Id = id;
            NewSite = newSite;
            Employee = employee;
        }
    }
}
