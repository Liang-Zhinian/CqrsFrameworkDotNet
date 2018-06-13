using System;
using Business.Domain.Validations.Security.Tenants;

namespace Business.Domain.Commands.Security.Tenants
{
    public class CreateTenantCommand : TenantCommand
    {
        public CreateTenantCommand(Guid id, string name, string displayName)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateTenantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
