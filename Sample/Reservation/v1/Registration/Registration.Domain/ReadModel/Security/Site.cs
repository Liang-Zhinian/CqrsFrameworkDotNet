using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration.Domain.ReadModel.Security
{
    public class Site
    {
        private Site()
        {
        }

        public Site(Guid id, string name, string description, Guid tenantId)
        {
            Id = id;
            Name = name;
            Description = description;
            TenantId = tenantId;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public byte[] Logo { get; set; }

        public string PageColor1 { get; set; }

        public string PageColor2 { get; set; }

        public string PageColor3 { get; set; }

        public string PageColor4 { get; set; }

        public string ContactName { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("PrimaryTelephone")]
        public string PrimaryTelephone { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("SecondaryTelephone")]
        public string SecondaryTelephone { get; set; }

        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
