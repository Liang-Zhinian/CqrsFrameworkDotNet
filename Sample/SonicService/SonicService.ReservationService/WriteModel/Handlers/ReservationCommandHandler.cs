using CqrsFramework.Commands;
using CqrsFramework.Domain;
using SonicService.ReservationService.WriteModel.Commands;
using SonicService.ReservationService.WriteModel.Domain;

namespace SonicService.ReservationService.WriteModel.Handlers
{
    public class ReservationCommandHandler : ICommandHandler<CreatReservationCommand>
    {
        private readonly ISession _session;

        public ReservationCommandHandler(ISession session)
        {
            _session = session;
        }

        public void Handle(CreatReservationCommand message)
        {
            var reservation = new Reservation(message.Id, message.Resources, message.CustomerId, message.TimeRange, message.ReservationTypeId);

            _session.Add(reservation);
            _session.Commit();
        }
    }
}
