using System;
using Business.Domain.Models.ValueObjects;
using Business.Domain.Validations.Security.Tenants;

namespace Business.Domain.Commands.Security.Tenants
{
    public class CreateTenantCommand : TenantCommand
    {
        public CreateTenantCommand(Guid id, string name, string displayName, Contact contact, Address address)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
            TenantContact = contact;
            TenantAddress = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateTenantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
