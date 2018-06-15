using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Domain.ReadModel.Security
{
    public class Staff
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public bool IsMale { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }

        public StaffLoginCredential LoginCredential { get; set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
