using System;
using System.Threading;
using System.Threading.Tasks;
using CqrsFramework.Commands;
using CqrsFramework.Domain;
using MediatR;
using Registration.Contracts.Commands.Appointments;
using Registration.Domain.AggregatesModel.AppointmentAggregate;

namespace Registration.Domain.CommandHandlers.Appointments
{
    public class AppointmentCommandHandler: CommandHandler, 
                                            ICommandHandler<MakeAnAppointmentCommand>,
                                            IRequestHandler<MakeAnAppointmentCommand, bool>
    {
        //private readonly ISession _session;
        public AppointmentCommandHandler(ISession session):base(session)
        {
            //_session = session;
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

        public async Task<bool> Handle(MakeAnAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment(
                Guid.NewGuid(),
                request.SiteId,
                request.StaffId,
                request.LocationId,
                request.StartDateTime,
                request.EndDateTime,
                request.ClientId,
                request.GenderPreference,
                request.Duration,
                request.StaffRequested,
                request.Notes,
                request.AppointmentServiceItems,
                request.AppointmentResources
            );

            await this.AddToSession(appointment);
            await this.CommitSession();

            return true;
        }
    }
}
