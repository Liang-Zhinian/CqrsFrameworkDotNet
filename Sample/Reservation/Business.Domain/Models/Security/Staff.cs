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
        public Staff(Guid tenantId, Guid userId, bool isMale, string image, string bio, bool canLoginAllLocations)
        {
            Id = Guid.NewGuid();
            this.TenantId = tenantId;
            this.UserId = userId;
            this.IsMale = isMale;
            this.Image = image;
            this.Bio = bio;
            this.CanLoginAllLocations = canLoginAllLocations;
        }

        public Guid UserId { get; private set; }
        //public virtual User User { get; private set; }

        public bool IsMale { get; private set; }

        public string Bio { get; private set; }

        public string Image { get; private set; }

        public bool CanLoginAllLocations { get; private set; }

        public Guid TenantId { get; private set; }
        public string TenantId_Id { get; private set; }

        public virtual ICollection<StaffLoginLocation> StaffLoginLocations { get; private set; }

    }
}
