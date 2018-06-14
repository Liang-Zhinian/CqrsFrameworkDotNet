using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.Security;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace Business.Domain.Models
{
    public class BaseObject : AggregateRoot
	{
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public BaseObject()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public BaseObject(Guid tenantId)
            :this()
        {
            TenantId = tenantId;
        }
    }
}
