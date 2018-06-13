using System;
using System.Collections.Generic;
using Business.Domain.Models.Security;

namespace Business.Domain.Commands.Security.Staffs
{
    public abstract class StaffCommand : BaseCommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public bool IsMale { get; set; }

        public string Bio { get; set; }

        public string ImageUrl { get; set; }

        public StaffLoginCredential LoginCredential { get; set; }

        public StaffAddress Address { get; set; }

        public StaffContact Contact { get; set; }

        public bool CanLoginAllLocations { get; set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }
    }
}
