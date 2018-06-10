using System;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Commands.Security.Locations
{
    public class CreateLocationCommand : LocationCommand
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Contact ContactInfomation { get; protected set; }
        public Address AddressInfomation { get; protected set; }
        public Geolocation Geolocation { get; protected set; }

        public CreateLocationCommand(string name, string description, Contact contact, Address address, Geolocation geolocation)
        {
            Name = name;
            Description = description;
            ContactInfomation = contact;
            AddressInfomation = address;
            Geolocation = geolocation;
        }

        public override bool IsValid()
        {
            //ValidationResult = new CreateBusinessCommandValidation().Validate(this);
            //return ValidationResult.IsValid;

            return true;
        }
    }
}
