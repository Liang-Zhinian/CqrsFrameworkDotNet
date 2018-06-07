using System;
using CqrsFramework.Domain;

namespace MAR.Domain.Models
{
    public class Contact: ValueObject<Contact>
    {
        public EmailAddress Email { get; set; }
        public EmailAddress Email2 { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }

        public Contact(EmailAddress email, EmailAddress email2, string mobilePhone, string homePhone, string workPhone)
        {
            Email = email;
            Email2 = email2;
            MobilePhone = mobilePhone;
            HomePhone = homePhone;
            WorkPhone = workPhone;
        }
    }
}
