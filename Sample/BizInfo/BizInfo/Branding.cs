using System;
using System.ComponentModel.DataAnnotations;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace SaaSEqt.BizInfo
{
    public class Branding : AggregateRoot
    {
        public string LogoURL { get; set; }
        public string PageColor1 { get; set; }
        public string PageColor2 { get; set; }
        public string PageColor3 { get; set; }
        public string PageColor4 { get; set; }
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public Branding()
        {
            Id = GuidUtil.NewSequentialId();
        }

        public Branding(Guid tenantId) : this()
        {
            TenantId = tenantId;
        }
    }
}
