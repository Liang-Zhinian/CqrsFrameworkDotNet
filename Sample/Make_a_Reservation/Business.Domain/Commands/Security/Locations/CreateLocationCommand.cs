using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Commands.Security.Locations
{
    public class CreateLocationCommand : LocationCommand
    {
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
