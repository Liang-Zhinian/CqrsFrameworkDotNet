using CqrsFramework.Events;
using MAR.Domain.Events.Employees;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAR.Domain.EventHandlers
{
    public class EmployeeEventHandler : IEventHandler<EmployeeCreatedEvent>
    {

        public void Handle(EmployeeCreatedEvent @event)
        {
            //if (InMemoryDatabase.Employees.All(x => x.Id != @event.Id))
                //InMemoryDatabase.Employees.Add(new Employee(@event.Id,
                                                            //@event.FirstName,
                                                            //@event.LastName,
                                                            //@event.DateOfBirth,
                                                            //@event.JobTitle));
            

            //using (ApplicationDbContext entities = new ApplicationDbContext())
            //{
            //    entities.Employees.Add(new Employee(@event.Id,
            //                                                @event.FirstName,
            //                                                @event.LastName,
            //                                                @event.DateOfBirth,
            //                                                @event.JobTitle));

            //    entities.SaveChanges();
            //}
        }
    }
}