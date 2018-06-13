using System;

namespace Business.Domain.Commands.Security.Locations
{
    public abstract class LocationCommand : BaseCommand
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}
