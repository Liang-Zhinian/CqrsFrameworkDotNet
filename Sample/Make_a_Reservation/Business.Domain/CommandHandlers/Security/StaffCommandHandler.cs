using CqrsFramework.Commands;
using CqrsFramework.Domain;
using CqrsFramework.Events;
using Business.Domain.Commands.Security.Staffs;
using Business.Domain.Models.Security;
using MediatR;

namespace Business.Domain.CommandHandlers.Security
{
    public class StaffCommandHandler : CommandHandler, 
                                        ICommandHandler<CreateStaffCommand>
    {
        
        public StaffCommandHandler(ISession session):base(session)
        {
        }

        public void Handle(CreateStaffCommand message)
        {
            Staff staff = new Staff(message.Id, message.FirstName, message.LastName, message.IsMale);

            AddToSession(staff);
            CommitSession();
        }
    }
}