using System;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Commands.Security.Locations
{
    public abstract class LocationCommand : BaseCommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Contact ContactInfomation { get; private set; }
        public Address AddressInfomation { get; private set; }
        public Geolocation Geolocation { get; private set; }
    }
}
