using System;
namespace CqrsFramework.Domain
{
    public class Person
    {
        private Name _name;
        private Contact _contact;
        private Address _address;
        private Profile _profile;
        private string _jobTitle;
        /// Appointment staff status (Readonly)
        private bool _appointmentTrn;
        /// Independent contractor status (Readonly)
        private bool _independentContractor;
        /// Overlap booking status (Readonly)
        private bool _alwaysAllowDoubleBooking;
        /// Class teacher status (Readonly)
        private bool _reservationTrn;
        private Gender _gender;

        public Person()
        {
        }
    }
}
