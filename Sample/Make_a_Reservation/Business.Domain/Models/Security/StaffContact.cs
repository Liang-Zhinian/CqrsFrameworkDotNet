using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class StaffContact : BaseObject
    {
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
