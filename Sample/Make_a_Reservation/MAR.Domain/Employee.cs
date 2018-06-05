using CqrsFramework.Domain;
using MAR.Contracts.Events.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAR.Domain
{
    public class Employee : AggregateRoot
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _jobTitle;

        private Employee() { }

        public Employee(Guid id, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Id = id;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _jobTitle = jobTitle;

            ApplyChange(new EmployeeCreatedEvent(id, firstName, lastName, dateOfBirth, jobTitle));
        }

        public void Apply(EmployeeCreatedEvent @event){
            _firstName = @event.FirstName;
            _lastName = @event.LastName;
            _dateOfBirth = @event.DateOfBirth;
            _jobTitle = @event.JobTitle;
        }
    }
}
