using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAR.Domain.Events.Employees
{
    public class EmployeeCreatedEvent : BaseEvent
    {
        public readonly string FirstName;
        public readonly string LastName;

        public EmployeeCreatedEvent(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}