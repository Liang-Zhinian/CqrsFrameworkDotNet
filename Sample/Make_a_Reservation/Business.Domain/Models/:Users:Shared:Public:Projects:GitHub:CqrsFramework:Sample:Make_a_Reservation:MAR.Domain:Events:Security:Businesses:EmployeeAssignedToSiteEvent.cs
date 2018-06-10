using System;
using MAR.Domain.Models.Security;

namespace MAR.Domain.Events.Security.Businesses
{
    public class EmployeeAssignedToSiteEvent : BaseEvent
    {
        public readonly Business NewSite;
        public readonly Employee Employee;

        public EmployeeAssignedToSiteEvent(Guid id, Site newSite, Employee employee)
        {
            Id = id;
            NewSite = newSite;
            Employee = employee;
        }
    }
}
