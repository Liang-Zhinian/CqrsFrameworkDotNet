using System;
using MAR.Domain.Models.Employees;
using MAR.Domain.Models.Businesses;

namespace MAR.Domain.Events.Locations
{
    public class EmployeeRemovedFromSiteEvent : BaseEvent
    {
        public readonly Site OldSite;
        public readonly Employee Employee;

        public EmployeeRemovedFromSiteEvent(Guid id, Site oldSite, Employee employee)
        {
            Id = id;
            OldSite = oldSite;
            Employee = employee;
        }
    }
}
