using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class StaffAddress : BaseObject
    {

        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }

        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
