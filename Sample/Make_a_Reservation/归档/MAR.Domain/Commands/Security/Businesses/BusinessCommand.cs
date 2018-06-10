using System;
using MAR.Domain.Models.ValueObjects;

namespace MAR.Domain.Commands.Security.Businesses
{
    public abstract class BusinessCommand : BaseCommand
    {
        public string Name { get; protected set; }
        public string DisplayName { get; protected set; }
        public Contact BusinessContact { get; protected set; }
        public Address BusinessAddress { get; protected set; }
    }
}
