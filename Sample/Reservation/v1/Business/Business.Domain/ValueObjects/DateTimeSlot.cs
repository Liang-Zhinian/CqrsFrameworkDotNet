using CqrsFramework.Domain;
using System;

namespace Business.Domain.ValueObjects
{
    public class DateTimeSlot : ValueObject<DateTimeSlot>
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public DateTimeSlot(DateTime startDateTime, DateTime endDateTime)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}
