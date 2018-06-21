using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business.Domain.Models.Security;
using CqrsFramework.Domain;
using Infrastructure.Utils;
using SaaSEqt.IdentityAccess.Domain.Models;

namespace Business.Domain.Models
{
    public abstract class BaseObject : AggregateRoot
	{
        public Guid TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }

        protected BaseObject()
        {
            Id = GuidUtil.NewSequentialId();
        }

        protected BaseObject(Guid tenantId)
            :this()
        {
            TenantId = tenantId;
        }
    }
}
