using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Commands.Security.Staffs
{
    public class CreateStaffCommand : StaffCommand
    {
        public CreateStaffCommand(PersonalInfo staffProfile)
        {
            StaffProfile = staffProfile;
        }

        public override bool IsValid()
        {
            //ValidationResult = new CreateBusinessCommandValidation().Validate(this);
            //return ValidationResult.IsValid;

            return true;
        }
    }
}