using CqrsFramework.Domain;
using System;

namespace MAR.Domain
{
    public class TimeRange : ValueObject<TimeRange>
    {
        public readonly DateTime Date;
        public readonly string StartTime;
        public readonly string EndTime;

        public TimeRange(DateTime date, string startTime, string endTime)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
