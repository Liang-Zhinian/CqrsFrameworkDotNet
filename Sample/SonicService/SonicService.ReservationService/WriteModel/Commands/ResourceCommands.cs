using System;
using System.Collections.Generic;
using System.Text;

namespace SonicService.ReservationService.WriteModel.Commands
{
    public class CreateResourceCommand : BaseCommand
    {
        public readonly string Name;
        public readonly Guid? ResourceTypeId;

        public CreateResourceCommand(Guid id, string name, Guid? resourceTypeId)
        {
            Id = id;
            Name = name;
            ResourceTypeId = resourceTypeId;
        }
    }

    public class RenameResourceCommand : BaseCommand {

        public readonly string NewName;

        public RenameResourceCommand(Guid id, string newName, int originalVersion)
        {
            Id = id;
            NewName = newName;
            ExpectedVersion = originalVersion;
        }
    }
}
