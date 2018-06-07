using System;
namespace MAR.Domain.Models.Employees
{
    public class Settings
    {

        /// Appointment staff status (Readonly)
        public bool AppointmentTrn;
        /// Independent contractor status (Readonly)
        public bool IndependentContractor;
        /// Overlap booking status (Readonly)
        public bool AlwaysAllowDoubleBooking;
        /// Class teacher status (Readonly)
        public bool ReservationTrn;

        public Settings(bool appointmentTrn, bool independentContractor, bool alwaysAllowDoubleBooking, bool reservationTrn)
        {

            AppointmentTrn = appointmentTrn;
            IndependentContractor = independentContractor;
            AlwaysAllowDoubleBooking = alwaysAllowDoubleBooking;
            ReservationTrn = reservationTrn;
        }
    }
}
