using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class TenantAddress : BaseObject
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
