using System;
using MAR.Domain.Models.ValueObjects;
using MAR.Domain.Validations.Security.Businesses;

namespace MAR.Domain.Commands.Security.Businesses
{
    public class CreateBusinessCommand : BusinessCommand
    {
        public CreateBusinessCommand(string name, string displayName, Contact contact, Address address)
        {
            Name = name;
            DisplayName = displayName;
            BusinessContact = contact;
            BusinessAddress = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateBusinessCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
