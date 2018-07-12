using System;
namespace Registration.Contracts
{
    public class AppointmentServiceItem: OrderLine
    {
        public AppointmentServiceItem()
        {
        }

        public Guid Id { get; private set; }

        public Guid ServiceItemId { get; private set; }

        public string Name { get; private set; }

        public int DefaultTimeLength { get; private set; }

        public double Price { get; private set; }

        public Guid SiteId { get; private set; }
    }
}
