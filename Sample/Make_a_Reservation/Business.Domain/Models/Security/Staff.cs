using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Events.Security.Staffs;

namespace Business.Domain.Models.Security
{
    public class Staff : BaseObject
    {
        public bool IsMale { get; set; }

        public string Bio { get; set; }

        public string ImageUrl { get; set; }

        public bool CanLoginAllLocations { get; set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public Staff(Guid tenantId) : base(tenantId)
        {
        }

        protected Staff()
        {
        }
    }
}
