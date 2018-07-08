using System;
namespace Business.Contracts.Commands.Locations
{
    public class UpdateLocationImageCommand
    {
        public UpdateLocationImageCommand()
        {
        }

        public Guid LocationId { get; set; }

        public Guid SiteId { get; set; }

        public byte[] Image { get; set; }
    }
}
