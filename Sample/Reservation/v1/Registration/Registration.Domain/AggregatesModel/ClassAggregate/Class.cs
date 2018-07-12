using System;
using CqrsFramework.Domain;

namespace Registration.Domain.AggregatesModel.ClassAggregate
{
    public class Class : AggregateRoot, IOrder
    {
        #region ctor

        public Class()
        {
        }

        #endregion

        #region properties

        /// Start time
        public DateTime StartDateTime { get; private set; }

        /// End time.
        public DateTime EndDateTime { get; private set; }

        ///// Staff, teacher, or trainer
        public Guid StaffId { get; private set; }

        /// The location of the schedule
        public Guid LocationId { get; private set; }

        public Guid SiteId { get; private set; }

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
        public Guid ClientId { get; private set; }


        #endregion

        #region ordering cycle commands

        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        public void SetAwaitingValidationStatus()
        {
            throw new NotImplementedException();
        }

        public void SetCancelledStatus()
        {
            throw new NotImplementedException();
        }

        public void SetPaidStatus()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
