using System;
using System.Collections.Generic;
using MAR.Domain.Models.Security;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Commands.Security.Staffs
{
    public abstract class StaffCommand : BaseCommand
    {
        public LoginCredential LoginCredential { get; protected set; }
        public Profile StaffProfile { get; protected set; }
        public List<Location> LoginLocations { get; protected set; }
    }
}
