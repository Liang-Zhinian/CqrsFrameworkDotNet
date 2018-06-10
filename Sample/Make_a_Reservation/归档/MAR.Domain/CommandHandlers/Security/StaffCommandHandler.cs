using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using MAR.Domain.Commands.Security.Staffs;
using MAR.Domain.Models.Security;
using MAR.Domain.Repositories;
using MediatR;

namespace MAR.Domain.CommandHandlers.Security
{
    public class StaffCommandHandler : CommandHandler, 
                                        ICommandHandler<CreateStaffCommand>
    {
        
        public StaffCommandHandler(ISession session):base(session)
        {
        }

        public void Handle(CreateStaffCommand message)
        {
            Staff staff = new Staff(message.Id, message.StaffProfile);

            AddToSession(staff);
            CommitSession();
        }
    }
}