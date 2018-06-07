using CqrsFramework.Domain;
using CqrsFramework.Extensions.Domain;
using MAR.Contracts.Events.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAR.Domain.Employees
{
    public class Employee : Person
    {
        private Job _job;
        private Settings _settings;
        private SalesSettings _salesSettings;

        private Employee() { }

        public Employee(Guid id, Name name)
        {
            Id = id;

            // 1. raise employee created event

            // 2. raise employee settings applied event

            // 3. raise employee sales settings applied event



            //Name = new Name(firstName, lastName);
            //_settings = new Settings(false, false, false, true);
            //_salesSettings = new SalesSettings(false, true, true);

            //ApplyChange(new EmployeeCreatedEvent(id, firstName, lastName));
        }

        public void Apply(EmployeeCreatedEvent @event){
            //_firstName = @event.FirstName;
            //_lastName = @event.LastName;
            //_dateOfBirth = @event.DateOfBirth;
            //_jobTitle = @event.JobTitle;
        }
    }
}
