using System;
namespace Business.Domain.Entities.Services
{
    public class Class : ScheduleItem
    {
        public Class()
        {
        }

        /// Class schedule ID
        public Guid ClassScheduleID { get; private set; }

        /// Maximum capacity for this class
        public int MaxCapacity { get; private set; }

        /// Online maximum capacity for this class
        public int WebCapacity { get; private set; }

        /// Total signed up
        public int TotalBooked { get; private set; }

        /// Total waitlist signed up
        public int TotalBookedWaitlist { get; private set; }

        /// Total web signed up
        public int WebBooked { get; private set; }

        /// Semester ID
        public string SemesterID { get; private set; }

        /// Cancel status
        public bool IsCanceled { get; private set; }

        /// Substitute status
        public bool Substitute { get; private set; }

        /// Active status
        public bool Active { get; private set; }

        /// Waitlist availability status
        public bool IsWaitlistAvailable { get; private set; }

        /// Enrollment status
        public bool IsEnrolled { get; private set; }

        /// Visibility status after canceled
        public bool HideCancel { get; private set; }

        /// Availability status
        public bool IsAvailable { get; private set; }

        /// Description
        public ClassDescription ClassDescription { get; private set; }

        /// Client
        public Client Client { get; private set; }

    }
}
