﻿using System;
namespace SaaSEqt.eShop.Services.Business.API.Requests
{
    public class ProvisionSiteRequest
    {
        public ProvisionSiteRequest()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TenantId { get; set; }
    }
}
