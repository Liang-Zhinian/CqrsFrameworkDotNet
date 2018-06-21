using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SaaSEqt.IdentityAccess.Domain.Models;

namespace Business.Domain.Models.Security
{
    public class Staff : BaseObject
    {
        public bool IsMale { get; set; }

        public string Bio { get; set; }

        public string ImageUrl { get; set; }

        public bool CanLoginAllLocations { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public Staff(Guid tenantId) : base(tenantId)
        {
        }

        protected Staff()
        {
        }
    }
}
