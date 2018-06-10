using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Business.Domain.Models.Security;
using MediatR;
using Business.Domain.Commands.Security.Locations;

namespace Business.Domain.CommandHandlers.Security
{
    public class LocationCommandHandler : CommandHandler, 
                                        ICommandHandler<CreateLocationCommand>
    {
        
        public LocationCommandHandler(ISession session):base(session)
        {
        }

        public void Handle(CreateLocationCommand message)
        {
            Location location = new Location(message.Id, message.Name, message.Description, message.ContactInfomation, message.AddressInfomation, message.Geolocation);

            AddToSession(location);
            CommitSession();
        }
    }
}