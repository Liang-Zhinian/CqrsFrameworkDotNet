using System;

namespace Business.Domain.Commands.Security.Locations
{
    public class CreateLocationCommand : LocationCommand
    {
        public CreateLocationCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            //ValidationResult = new CreateBusinessCommandValidation().Validate(this);
            //return ValidationResult.IsValid;

            return true;
        }
    }
}
