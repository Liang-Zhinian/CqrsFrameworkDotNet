﻿using System;
namespace Business.Contracts.Commands.Locations
{
    public class UpdateLocationCommand
    {
        public UpdateLocationCommand()
        {
        }

        public Guid LocationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactName { get; set; }

        public string EmailAddress { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public Guid SiteId { get; set; }
    }
}
