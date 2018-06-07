using System;
namespace MAR.Domain.Events.Employees
{
    public class EmployeeSettingsAppliedEvent: BaseEvent
    {

        /// Appointment staff status (Readonly)
        public bool AppointmentTrn;
        /// Independent contractor status (Readonly)
        public bool IndependentContractor;
        /// Overlap booking status (Readonly)
        public bool AlwaysAllowDoubleBooking;
        /// Class teacher status (Readonly)
        public bool ReservationTrn;

        public EmployeeSettingsAppliedEvent(Guid id, bool appointmentTrn, bool independentContractor, bool alwaysAllowDoubleBooking, bool reservationTrn)
        {
            Id = id;
            AppointmentTrn = appointmentTrn;
            IndependentContractor = independentContractor;
            AlwaysAllowDoubleBooking = alwaysAllowDoubleBooking;
            ReservationTrn = reservationTrn;
        }
    }
}
