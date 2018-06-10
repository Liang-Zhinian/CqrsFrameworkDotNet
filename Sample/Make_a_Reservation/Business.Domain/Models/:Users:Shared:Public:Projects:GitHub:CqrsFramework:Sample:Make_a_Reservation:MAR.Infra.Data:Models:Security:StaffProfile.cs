using System;
namespace MAR.Infra.Data.Models.Security
{
    public class StaffProfile
    {
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public Contact Contact { get; set; }
        public Address Address { get; set; }

        public StaffProfile()
        {
        }
    }
}
