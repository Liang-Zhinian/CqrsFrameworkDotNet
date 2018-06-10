using System;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Commands.Security.Staffs
{
    public class CreateStaffCommand : StaffCommand
    {
        public CreateStaffCommand(Profile staffProfile)
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