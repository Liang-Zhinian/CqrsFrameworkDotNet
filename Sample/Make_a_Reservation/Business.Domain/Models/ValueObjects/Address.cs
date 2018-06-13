using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models.ValueObjects
{
    public class Address:ValueObject<Address>
    {
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }
    }
}
