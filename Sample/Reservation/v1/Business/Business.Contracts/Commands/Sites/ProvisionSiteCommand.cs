using System;
using CqrsFramework.Commands;

namespace Business.Contracts.Commands.Sites
{
    public class ProvisionSiteCommand : ICommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public string ContactName { get; set; }

        public string EmailAddress { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public string TenantId { get; set; }

        public ProvisionSiteCommand()
        {
        }
    }
}
