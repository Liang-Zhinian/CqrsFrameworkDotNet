using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Registration.Domain.Properties;

namespace Registration.Domain.ReadModel.Security
{
    public class Staff
    {
        
        
        [Key]
        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public bool IsEnabled { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public bool IsMale { get; private set; }

        public string Bio { get; private set; }

        public byte[] Image { get; private set; }

        public bool CanLoginAllLocations { get; private set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; private set; }

        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Tenant Tenant { get; private set; }
    }
}
