using System;
using System.Collections.Generic;
using Business.Domain.Models.Security;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Commands.Security.Staffs
{
    public abstract class StaffCommand : BaseCommand
    {
        public LoginCredential LoginCredential { get; protected set; }
        public PersonalInfo StaffProfile { get; protected set; }
        public List<Location> LoginLocations { get; protected set; }
    }
}
