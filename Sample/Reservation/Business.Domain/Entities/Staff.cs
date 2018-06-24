using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;
using Infrastructure.Utils;
using SaaSEqt.IdentityAccess.Domain.Entities;

namespace Business.Domain.Entities
{
    public class Staff : AggregateRoot
    {

        private Staff() { }

        public Staff(TenantId tenantId, Guid siteId, Guid userId, bool isMale, string image, string bio, bool canLoginAllLocations)
        {
            Id = userId;
            this.TenantId = tenantId;
            this.SiteId = siteId;
            this.IsMale = isMale;
            this.Image = image;
            this.Bio = bio;
            this.CanLoginAllLocations = canLoginAllLocations;
        }

        public bool IsMale { get; private set; }

        public string Bio { get; private set; }

        public string Image { get; private set; }

        public bool CanLoginAllLocations { get; private set; }

        public TenantId TenantId { get; private set; }
        public Guid SiteId { get; private set; }
        public virtual Site Site { get; private set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; private set; }

    }
}
