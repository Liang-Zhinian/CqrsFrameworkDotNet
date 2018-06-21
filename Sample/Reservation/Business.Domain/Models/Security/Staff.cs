using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CqrsFramework.Domain;
using Infrastructure.Utils;
using SaaSEqt.IdentityAccess.Domain.Models;

namespace Business.Domain.Models.Security
{
    public class Staff : AggregateRoot
    {
        public Staff(TenantId tenantId, bool isMale, string image, string bio, bool canLoginAllLocations)
        {
            Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            this.IsMale = isMale;
            this.ImageUrl = image;
            this.Bio = bio;
            this.CanLoginAllLocations = canLoginAllLocations;
        }

        public bool IsMale { get; private set; }

        public string Bio { get; private set; }

        public string ImageUrl { get; private set; }

        public bool CanLoginAllLocations { get; private set; }

        public TenantId TenantId { get; private set; }

        public virtual User User { get; private set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; private set; }

    }
}
