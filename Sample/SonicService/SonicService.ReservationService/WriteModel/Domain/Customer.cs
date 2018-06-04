using CqrsFramework.Domain;

namespace SonicService.ReservationService.WriteModel.Domain
{
    public class Customer : AggregateRoot
    {
        private readonly string _firstName;
        private readonly string _lastName;
    }
}
