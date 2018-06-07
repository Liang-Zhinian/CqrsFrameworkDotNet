using System;
namespace MAR.Domain
{
    public class DateOfBirth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int TimeZone { get; set; }

        public DateOfBirth()
        {
        }
    }
}
