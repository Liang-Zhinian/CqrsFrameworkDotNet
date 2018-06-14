using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class TenantContact : BaseObject
    {
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public TenantContact(Guid tenantId) : base(tenantId)
        {
            Id = GuidUtil.NewSequentialId();
        }
    }
}
