using System;
using MAR.Domain.Commands.Security.Businesses;

namespace MAR.Domain.Validations.Security.Businesses
{
    public class CreateBusinessCommandValidation : BusinessValidation<CreateBusinessCommand>
    {
        public CreateBusinessCommandValidation()
        {
            ValidateName();
            ValidateEmail();
        }
    }
}
