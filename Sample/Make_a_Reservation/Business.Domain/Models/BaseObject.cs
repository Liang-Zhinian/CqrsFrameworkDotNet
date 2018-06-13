using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.Security;
using CqrsFramework.Domain;

namespace Business.Domain.Models
{
    public class BaseObject : AggregateRoot
	{
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
