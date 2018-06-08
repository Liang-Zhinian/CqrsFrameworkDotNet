using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAR.Domain.Models;

namespace MAR.Domain.Events.Employees
{
    public class EmployeeCreatedEvent : BaseEvent
    {
        public readonly Name Name;
        public readonly Gender Gender;

        public EmployeeCreatedEvent(Guid id, Name name, Gender gender)
        {
            Id = id;
            Name = name;
            Gender = gender;
        }
    }
}