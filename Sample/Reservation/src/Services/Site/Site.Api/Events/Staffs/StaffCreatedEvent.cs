using System;

namespace SaaSEqt.eShop.Site.Api.Events.Staffs
{
    public class StaffCreatedEvent:StaffEvent
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public bool IsMale { get; set; }

        public StaffCreatedEvent(Guid id, string firstName, string lastName, bool isMale)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsMale = isMale;
        }
    }
}