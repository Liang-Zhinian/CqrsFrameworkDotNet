using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Infra.Data.ReadModel.Security
{
    public class Staff
    {
        [Key]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public bool IsMale { get; set; }

        public string Bio { get; set; }

        public string ImageUrl { get; set; }

        public virtual StaffLoginCredential LoginCredential { get; set; }

        public virtual StaffAddress Address { get; set; }

        public virtual StaffContact Contact { get; set; }

        public bool CanLoginAllLocations { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public string TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
