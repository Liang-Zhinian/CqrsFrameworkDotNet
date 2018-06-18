using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Domain.ReadModel.Security
{
    public class Staff
    {
        
        
        [Key]
        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public bool IsEnabled { get { return Enablement.Enabled; } private set { } }

        //[NotMapped]
        public Enablement Enablement { get; private set; }

        public PersonalInfo PersonalInfo { get; private set; }

        public PostalAddress PostalAddress { get; private set; }


        public ICollection<StaffLoginLocation> StaffLoginLocations { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Tenant Tenant { get; private set; }
    }
}
