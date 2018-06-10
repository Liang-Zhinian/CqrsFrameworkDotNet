using System;
using CqrsFramework.Domain;

namespace MAR.Domain.Models.ValueObjects
{
    public class Contact: ValueObject<Contact>
    {
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public Contact(string email, string email2, string phone, string phone2, string phone3)
        {
            Email = email;
            Email2 = email2;
            Phone = phone;
            Phone2 = phone2;
            Phone3 = phone3;
        }
    }
}
