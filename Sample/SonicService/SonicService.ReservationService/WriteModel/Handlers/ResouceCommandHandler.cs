using CqrsFramework.Messages;
using SonicService.ReservationService.WriteModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using CqrsFramework.Domain;
using SonicService.ReservationService.WriteModel.Domain;
using CqrsFramework.Commands;

namespace SonicService.ReservationService.WriteModel.Handlers
{
    public class ResouceCommandHandler : CommandHandlerWithSession, ICommandHandler<CreateResourceCommand>,
                                            ICommandHandler<RenameResourceCommand>
    {
        public ResouceCommandHandler(ISession session) : base(session)
        {
        }

        public void Handle(CreateResourceCommand message)
        {
            var resouce = new Resource(message.Id, message.Name, message.ResourceTypeId);
            AddToSession(resouce);
            CommitSession();
        }

        public void Handle(RenameResourceCommand message)
        {
            Resource resource = _session.Get<Resource>(message.Id, message.ExpectedVersion);
            resource.ChangeName(message.NewName);
            CommitSession();
        }
    }
}
