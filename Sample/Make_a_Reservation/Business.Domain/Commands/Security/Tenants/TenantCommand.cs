using System;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Commands.Security.Tenants
{
    public abstract class TenantCommand : BaseCommand
    {
        public string Name { get; protected set; }
        public string DisplayName { get; protected set; }
        public Contact TenantContact { get; protected set; }
        public Address TenantAddress { get; protected set; }
    }
}
