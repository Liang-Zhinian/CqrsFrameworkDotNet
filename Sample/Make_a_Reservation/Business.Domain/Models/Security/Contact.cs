using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models.Security
{
    public class Contact : BaseObject
    {
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
    }
}
