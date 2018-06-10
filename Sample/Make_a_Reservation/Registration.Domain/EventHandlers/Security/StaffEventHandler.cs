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
            var profile = message.StaffProfile;
            staff.FirstName = profile.Name.FirstName;
            staff.LastName = profile.Name.LastName;

            staff.Contact = new StaffContact()
            {
                Id = new Guid().ToString(),
                Email = profile.Contact.Email,
                Email2 = profile.Contact.Email2,
                Phone = profile.Contact.Phone,
                Phone2 = profile.Contact.Phone2,
                Phone3 = profile.Contact.Phone3,
                StaffId = staff.Id
            };
            staff.Address = new StaffAddress()
            {
                Id = new Guid().ToString(),
                Street = profile.Address.Street,
                Street2 = profile.Address.Street2,
                State = profile.Address.State,
                City = profile.Address.City,
                Country = profile.Address.Country,
                StaffId = staff.Id
            };
            staff.IsMale = profile.IsMale;
            staff.Bio = profile.Bio;
            staff.ImageUrl = profile.Photo.ImageUrl;

            _staffRepo.Add(staff);
        }
    }
}