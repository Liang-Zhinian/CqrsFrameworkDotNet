using CqrsFramework.Domain;
using MAR.Domain.Events.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAR.Domain.Models.Employees
{
    public class Employee : Person
    {
        public Job JobDescription { get; private set; }
        public Settings GeneralSettings { get; private set; }
        public SalesSettings SalesSettings { get; private set; }
        public List<Guid> LoginLocations { get; private set; }

        private Employee() { }

        public Employee(Guid id, Name name, Gender gender)
        {
            // 1. raise employee created event
            ApplyChange(new EmployeeCreatedEvent(id, name, gender));

            // 2. raise employee settings applied event

            // 3. raise employee sales settings applied event



            //Name = new Name(firstName, lastName);
            //_settings = new Settings(false, false, false, true);
            //_salesSettings = new SalesSettings(false, true, true);

        }

        public void Apply(EmployeeCreatedEvent @event){
            Name = @event.Name;
            Gender = @event.Gender;
        }
    }
}
