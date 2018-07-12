using System;
using System.Threading.Tasks;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using Registration.Contracts.Commands.Appointments;
using Registration.Domain.AggregatesModel.AppointmentAggregate;

namespace Registration.Domain.CommandHandlers.Appointments
{
    public class AppointmentCommandHandler: CommandHandler, ICommandHandler<MakeAnAppointmentCommand>
    {

        public AppointmentCommandHandler(ISession session):base(session)
        {
        }

        public async Task Handle(MakeAnAppointmentCommand message)
        {
            var appointment = new Appointment(
                Guid.NewGuid(),
                message.SiteId,
                message.StaffId,
                message.LocationId,
                message.StartDateTime,
                message.EndDateTime,
                message.ClientId,
                message.GenderPreference,
                message.Duration,
                message.StaffRequested,
                message.Notes,
                message.AppointmentServiceItems,
                message.AppointmentResources
            );

            await this.AddToSession(appointment);
            await this.CommitSession();
        }
    }
}
