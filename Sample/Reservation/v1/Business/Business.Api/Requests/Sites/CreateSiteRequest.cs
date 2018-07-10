using System;
using Microsoft.AspNetCore.Http;

namespace Business.Api.Requests.Sites
{
    public class CreateSiteRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        //public IFormFile Logo { get; set; }

        public string ContactName { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public string TenantId { get; set; }

        public CreateSiteRequest()
        {
        }
    }
}
