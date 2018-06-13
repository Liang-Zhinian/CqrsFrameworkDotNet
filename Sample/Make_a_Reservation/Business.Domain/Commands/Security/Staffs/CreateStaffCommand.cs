using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Commands.Security.Staffs
{
    public class CreateStaffCommand : StaffCommand
    {
        public CreateStaffCommand(string firstName, string lastName, bool isMale)
        {
            FirstName = firstName;
            LastName = lastName;
            IsMale = isMale;
        }

        public override bool IsValid()
        {
            //ValidationResult = new CreateBusinessCommandValidation().Validate(this);
            //return ValidationResult.IsValid;

            return true;
        }
    }
}