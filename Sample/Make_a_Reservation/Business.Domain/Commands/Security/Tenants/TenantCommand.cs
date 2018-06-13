using System;

namespace Business.Domain.Commands.Security.Tenants
{
    public abstract class TenantCommand : BaseCommand
    {
        public string Name { get; protected set; }
        public string DisplayName { get; protected set; }
    }
}
