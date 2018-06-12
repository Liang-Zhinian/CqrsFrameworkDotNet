using System;
using System.ComponentModel.DataAnnotations;
using Business.Infra.Data.ReadModel.Security;

namespace Business.Infra.Data.ReadModel
{
    public class BaseObject<TKeyType>
	{
        [Key]
        public TKeyType Id { get; set; }

        public string TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
