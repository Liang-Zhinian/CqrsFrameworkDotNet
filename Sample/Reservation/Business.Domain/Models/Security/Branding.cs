using System;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class Branding
    {
        public Guid Id { get; private set; }
        public string Logo { get; private set; }
        public string PageColor1 { get; private set; }
        public string PageColor2 { get; private set; }
        public string PageColor3 { get; private set; }
        public string PageColor4 { get; private set; }

        public Guid TenantId { get; private set; }
        public string TenantId_Id { get; private set; }

        public Branding(Guid tenantId, string logo, string pageColor1, string pageColor2, string pageColor3, string pageColor4)
        {
            Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            this.Logo = logo;
            this.PageColor1 = pageColor1;
            this.PageColor2 = pageColor2;
            this.PageColor3 = pageColor3;
            this.PageColor4 = pageColor4;
        }
    }
}
