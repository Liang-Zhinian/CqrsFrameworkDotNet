using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Commands.Security.Locations
{
    public abstract class LocationCommand : BaseCommand
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Contact ContactInfomation { get; protected set; }
        public Address AddressInfomation { get; protected set; }
        public Geolocation Geolocation { get; protected set; }
    }
}
