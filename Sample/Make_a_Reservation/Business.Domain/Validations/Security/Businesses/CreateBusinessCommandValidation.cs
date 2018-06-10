using System;
using Business.Domain.Commands.Security.Tenants;

namespace Business.Domain.Validations.Security.Tenants
{
    public class CreateTenantCommandValidation : TenantValidation<CreateTenantCommand>
    {
        public CreateTenantCommandValidation()
        {
            ValidateName();
            ValidateEmail();
        }
    }
}
