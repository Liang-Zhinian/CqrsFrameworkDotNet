using Business.Domain.Events.Security.Staffs;
using CqrsFramework.Events;
using Registration.Domain.ReadModel.Security;
using Registration.Domain.Repositories.Interfaces;
using System;

namespace Registration.Domain.EventHandlers.Security
{
    public class StaffEventHandler : EventHandler,
                                    IEventHandler<StaffCreatedEvent>
    {
        private readonly IStaffRepository _staffRepo;

        public StaffEventHandler(IStaffRepository staffRepo) : base(){
            _staffRepo = staffRepo;
        }

        public void Handle(StaffCreatedEvent message)
        {
            Staff staff = new Staff();
            staff.Id = message.Id.ToString();
            staff.FirstName = message.FirstName;
            staff.LastName = message.LastName;
            staff.IsMale = message.IsMale;

            _staffRepo.Add(staff);
        }
    }
}