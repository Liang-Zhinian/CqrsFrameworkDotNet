using System;
namespace Registration.Contracts
{
    public class AppointmentResource
    {
        public AppointmentResource()
        {
        }

        public Guid Id { get; private set; }

        public Guid ResourceId { get; private set; }

        public Guid ResourceName { get; private set; }
    }
}
