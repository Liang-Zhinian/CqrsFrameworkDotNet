using CqrsFramework.Events;
using MAR.Domain.Events.Security.Staffs;
using System;

namespace MAR.Domain.EventHandlers.Security
{
    public class StaffEventHandler : EventHandler,
                                    IEventHandler<StaffCreatedEvent>
    {
        public StaffEventHandler() : base(){}

        public void Handle(StaffCreatedEvent message)
        {
            //if (InMemoryDatabase.Employees.All(x => x.Id != message.Id))
                //InMemoryDatabase.Employees.Add(new Employee(message.Id,
                                                            //message.FirstName,
                                                            //message.LastName,
                                                            //message.DateOfBirth,
                                                            //message.JobTitle));
            

            using (MARContext entities = new MARContext())
            {
                entities.Employees.Add(new Employee(message.Id,
                                                            message.FirstName,
                                                            message.LastName,
                                                            message.DateOfBirth,
                                                            message.JobTitle));

                entities.SaveChanges();
            }
        }
    }
}