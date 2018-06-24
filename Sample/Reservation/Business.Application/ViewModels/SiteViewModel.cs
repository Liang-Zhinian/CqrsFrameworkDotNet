using System;
namespace Business.Application.ViewModels
{
    public class SiteViewModel
    {
        public SiteViewModel()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public byte[] Logo { get; set; }

        public string PageColor1 { get; set; }

        public string PageColor2 { get; set; }

        public string PageColor3 { get; set; }

        public string PageColor4 { get; set; }

        public string ContactName { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public string TenantId { get; set; }
    }
}
