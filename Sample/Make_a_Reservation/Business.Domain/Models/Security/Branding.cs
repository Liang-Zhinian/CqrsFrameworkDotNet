using System;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class Branding : BaseObject
    {

        public string LogoURL { get; set; }
        public string PageColor1 { get; set; }
        public string PageColor2 { get; set; }
        public string PageColor3 { get; set; }
        public string PageColor4 { get; set; }

        public Branding(Guid tenantId) : base(tenantId)
        {
            Id = GuidUtil.NewSequentialId();
        }
    }
}
