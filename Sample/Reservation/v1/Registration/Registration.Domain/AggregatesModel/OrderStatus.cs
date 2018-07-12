using System;
using System.Collections.Generic;
using System.Linq;
using Registration.Domain.SeedWork;

namespace Registration.Domain.AggregatesModel
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus Booked = new OrderStatus(1, nameof(Booked).ToLowerInvariant());
        public static OrderStatus Completed = new OrderStatus(2, nameof(Completed).ToLowerInvariant());
        public static OrderStatus Confirmed = new OrderStatus(3, nameof(Confirmed).ToLowerInvariant());
        public static OrderStatus Arrived = new OrderStatus(4, nameof(Arrived).ToLowerInvariant());
        public static OrderStatus NoShow = new OrderStatus(5, nameof(NoShow).ToLowerInvariant());
        public static OrderStatus Cancelled = new OrderStatus(6, nameof(Cancelled).ToLowerInvariant());

        protected OrderStatus()
        {
        }

        public OrderStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<OrderStatus> List() =>
        new[] { Booked, Completed, Confirmed, Arrived, NoShow, Cancelled };

        public static OrderStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for ScheduleType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static OrderStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }

}
